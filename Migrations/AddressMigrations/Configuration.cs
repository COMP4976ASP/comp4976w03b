namespace w03b.Migrations.AddressMigrations
{
    using Data;
    using Models.Address;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<w03b.Data.AddressContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AddressMigrations";
        }

        protected override void Seed(w03b.Data.AddressContext context)
        {

            context.Provinces.AddOrUpdate(p => p.ProvinceName, getProvinces());
            context.SaveChanges();
            context.Cities.AddOrUpdate(c => new { c.CityName, c.Population }, getCities(context));
            context.SaveChanges();
        }


        private Province[] getProvinces()
        {
            var provinces = new List<Province>
            {
                new Province() { ProvinceCode = "BC", ProvinceName = "British Columbia"},
                new Province() { ProvinceCode = "AB", ProvinceName = "Alberta" },
                new Province() { ProvinceCode = "OT", ProvinceName = "Ottawa" },
            };
            return provinces.ToArray();
        }

        private City[] getCities(AddressContext context)
        {
            var cities = new List<City>
            {
                //British Columbia
                new Models.Address.City()
                {
                    CityName="Surrey",
                    Population = 300000,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode,
                },

                new Models.Address.City()
                {
                    CityName="Vancouver",
                    Population = 603502,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode,
                },

                new Models.Address.City()
                {
                    CityName="Burnaby",
                    Population = 223220,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode,
                },

                //Alberta
                new Models.Address.City()
                {
                    CityName="Edmonton",
                    Population = 812200,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode,
                },

                new Models.Address.City()
                {
                    CityName="Calgary",
                    Population = 1097000,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode,

                },

                new Models.Address.City()
                {
                   CityName="Medicine Hat",
                    Population = 60000,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode,

                },

                //Ottawa
                new Models.Address.City()
                {
                    CityName = "Windsor ",
                    Population = 210890,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="OT").ProvinceCode,

                },

                new Models.Address.City()
                {
                    CityName = "Ottawa",
                    Population = 883391,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="OT").ProvinceCode,

                },

                new Models.Address.City()
                {
                    CityName = "Toronto",
                    Population = 2615000,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="OT").ProvinceCode,

                },
            };

            return cities.ToArray();
        }
    }
}