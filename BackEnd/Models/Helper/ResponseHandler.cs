namespace assignment_tess.Models.Helper
{
    public class ResponseHandler
    {
        public MetaData metaData { get; set; }
        public object response { get; set; }
    }
    public class MetaData
    {
        public int code { get; set; } = 400;
        public string message { get; set; } = "Terjadi Kesalahan. Cobalah Beberapa Saat Lagi.";
    }
}
