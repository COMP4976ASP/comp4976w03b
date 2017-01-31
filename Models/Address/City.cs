using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace w03b.Models.Address
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }
        public int Population { get; set; }

        public string ProvinceCode { get; set; }
        public Province Province { get; set; }
    }
}