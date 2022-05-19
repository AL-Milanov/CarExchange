namespace CarExchange.Core.Models
{
    public class ImageVM
    {
        public ICollection<byte[]> Images { get; set; }

        public ImageVM()
        {
            Images = new List<byte[]>();
        }
    }
}
