namespace IM.Encryt.Models.Entities
{
    public enum EncryptionVersion
    {
        Legacy = 1,
        Modern = 2
    }

    public class EncryptRequest
    {
        public string Key { get; set; }

        public string Text { get; set; }

        public EncryptionVersion Version
        {
            get;
            set;
        } = EncryptionVersion.Modern;
    }

    public class EncryptResponse
    {
        public string Result { get; set; }
    }
}
