using IM.Encryt.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace IM.Encryt.Models.Models;

public static class EncryptHelper
{
    private const int IvSize = 16;

    // RSA singleton
    private static readonly RSA _rsa = RSA.Create(2048);

    #region RSA

    /// <summary>
    /// Public key Base64
    /// </summary>
    public static string PublicKey =>
        Convert.ToBase64String(
            _rsa.ExportSubjectPublicKeyInfo());

    public static string EncryptRsa(
        string plainText,
        string publicKeyBase64)
    {
        using RSA rsa = RSA.Create();

        rsa.ImportSubjectPublicKeyInfo(
            Convert.FromBase64String(publicKeyBase64),
            out _);

        byte[] encrypted =
            rsa.Encrypt(
                Encoding.UTF8.GetBytes(plainText),
                RSAEncryptionPadding.OaepSHA256);

        return Convert.ToBase64String(encrypted);
    }

    public static string DecryptRsa(
        string cipherText)
    {
        byte[] decrypted =
            _rsa.Decrypt(
                Convert.FromBase64String(cipherText),
                RSAEncryptionPadding.OaepSHA256);

        return Encoding.UTF8.GetString(decrypted);
    }

    #endregion

    #region PUBLIC AES

    public static string Encrypt(
        string plainText,
        string secretKey,
        EncryptionVersion version = EncryptionVersion.Modern)
    {
        return version switch
        {
            EncryptionVersion.Legacy =>
                EncryptLegacy(plainText, secretKey),

            EncryptionVersion.Modern =>
                EncryptModern(plainText, secretKey),

            _ => throw new NotSupportedException()
        };
    }

    public static string Decrypt(
        string cipherText,
        string secretKey,
        EncryptionVersion? version = null)
    {
        if (version == null)
        {
            return TryDecryptAuto(
                cipherText,
                secretKey);
        }

        return version switch
        {
            EncryptionVersion.Legacy =>
                DecryptLegacy(cipherText, secretKey),

            EncryptionVersion.Modern =>
                DecryptModern(cipherText, secretKey),

            _ => throw new NotSupportedException()
        };
    }

    #endregion

    #region MODERN AES

    private static string EncryptModern(
        string plainText,
        string secretKey)
    {
        byte[] key =
            SHA256.HashData(
                Encoding.UTF8.GetBytes(secretKey));

        using Aes aes = Aes.Create();

        aes.Key = key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        aes.GenerateIV();

        using ICryptoTransform encryptor =
            aes.CreateEncryptor();

        byte[] plainBytes =
            Encoding.UTF8.GetBytes(plainText);

        byte[] encryptedBytes =
            encryptor.TransformFinalBlock(
                plainBytes,
                0,
                plainBytes.Length);

        byte[] result =
            new byte[aes.IV.Length + encryptedBytes.Length];

        Buffer.BlockCopy(
            aes.IV,
            0,
            result,
            0,
            aes.IV.Length);

        Buffer.BlockCopy(
            encryptedBytes,
            0,
            result,
            aes.IV.Length,
            encryptedBytes.Length);

        return Convert.ToBase64String(result);
    }

    private static string DecryptModern(
        string cipherText,
        string secretKey)
    {
        byte[] fullCipher =
            Convert.FromBase64String(cipherText);

        byte[] iv = new byte[IvSize];

        byte[] cipher =
            new byte[fullCipher.Length - IvSize];

        Buffer.BlockCopy(
            fullCipher,
            0,
            iv,
            0,
            IvSize);

        Buffer.BlockCopy(
            fullCipher,
            IvSize,
            cipher,
            0,
            cipher.Length);

        byte[] key =
            SHA256.HashData(
                Encoding.UTF8.GetBytes(secretKey));

        using Aes aes = Aes.Create();

        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using ICryptoTransform decryptor =
            aes.CreateDecryptor();

        byte[] decrypted =
            decryptor.TransformFinalBlock(
                cipher,
                0,
                cipher.Length);

        return Encoding.UTF8.GetString(decrypted);
    }

    #endregion

    #region LEGACY AES

    private static string EncryptLegacy(
        string plainText,
        string secretKey)
    {
        string iv = GenerateLegacyIV();

        byte[] keyBytes =
            Encoding.UTF8.GetBytes(
                Sha256(secretKey)[..32]);

        byte[] ivBytes =
            Encoding.UTF8.GetBytes(iv);

        using Aes aes = Aes.Create();

        aes.Key = keyBytes;
        aes.IV = ivBytes;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using ICryptoTransform encryptor =
            aes.CreateEncryptor();

        byte[] plainBytes =
            Encoding.UTF8.GetBytes(plainText);

        byte[] encrypted =
            encryptor.TransformFinalBlock(
                plainBytes,
                0,
                plainBytes.Length);

        return iv + Convert.ToBase64String(encrypted);
    }

    private static string DecryptLegacy(
        string cipherText,
        string secretKey)
    {
        string iv = cipherText[..16];

        string cipher = cipherText[16..];

        byte[] keyBytes =
            Encoding.UTF8.GetBytes(
                Sha256(secretKey)[..32]);

        byte[] ivBytes =
            Encoding.UTF8.GetBytes(iv);

        using Aes aes = Aes.Create();

        aes.Key = keyBytes;
        aes.IV = ivBytes;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using ICryptoTransform decryptor =
            aes.CreateDecryptor();

        byte[] cipherBytes =
            Convert.FromBase64String(cipher);

        byte[] decrypted =
            decryptor.TransformFinalBlock(
                cipherBytes,
                0,
                cipherBytes.Length);

        return Encoding.UTF8.GetString(decrypted);
    }

    #endregion

    #region AUTO DETECT

    private static string TryDecryptAuto(
        string cipherText,
        string secretKey)
    {
        bool looksLegacy =
            cipherText.Length > 16 &&
            cipherText[..16]
                .All(char.IsLetterOrDigit);

        if (looksLegacy)
        {
            try
            {
                return DecryptLegacy(
                    cipherText,
                    secretKey);
            }
            catch
            {
            }
        }

        return DecryptModern(
            cipherText,
            secretKey);
    }

    #endregion

    #region HELPERS

    private static string GenerateLegacyIV()
    {
        const string chars =
            "abcdefghijklmnopqrstuvwxyz0123456789";

        return new string(
            Enumerable.Range(0, 16)
            .Select(_ =>
                chars[
                    RandomNumberGenerator.GetInt32(
                        chars.Length)])
            .ToArray());
    }

    public static string Sha256(
        string text)
    {
        byte[] hash =
            SHA256.HashData(
                Encoding.UTF8.GetBytes(text));

        return Convert.ToHexString(hash)
            .ToLowerInvariant();
    }

    #endregion
}