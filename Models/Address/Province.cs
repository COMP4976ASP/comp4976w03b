using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace w03b.Models.Address
{
    public class Province
    {
        [Key]
        [DisplayName("Province Code")]
        public string ProvinceCode { get; set; }

        [DisplayName("Province")]
        public string ProvinceName { get; set; }

        public List<City> Cities { get; set; }
    }
}