using System.ComponentModel.DataAnnotations;

namespace CarExchange.Infrastructure.Data.Models
{
    public class Image
    {

        public string Id = Guid.NewGuid().ToString();

        public List<byte[]>? Images { get; set; }

        public Image()
        {
            Images = new List<byte[]>();
        }
    }
}