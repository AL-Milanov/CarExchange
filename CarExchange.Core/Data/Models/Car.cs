using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExchange.Core.Data.Models
{
    public class Car
    {

        [Required]
        public string Id => Guid.NewGuid().ToString();


    }
}
