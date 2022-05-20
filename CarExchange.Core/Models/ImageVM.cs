namespace CarExchange.Core.Models
{
    public class ImageVM
    {
        public List<byte[]> Images { get; set; }

        public ImageVM()
        {
            Images = new List<byte[]>();
        }
    }
}
