using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.DistrictManager
{
    public class DistrictManager : IDistrictManager
    {
        private readonly Dictionary<int, Country> countriesById =
            new Dictionary<int, Country>();

        private readonly Dictionary<int, District> districtsById =
            new Dictionary<int, District>();

        private readonly Dictionary<Country, HashSet<District>> countriesWithDistricts = 
            new Dictionary<Country, HashSet<District>>();

        private readonly HashSet<Country> allCountries = 
            new HashSet<Country>();

        private readonly HashSet<District> allDistricts = 
            new HashSet<District>();

        public void CreateDistrict(District district, Country country)
        {
            if (!this.countriesWithDistricts.ContainsKey(country))
            {
                throw new ArgumentException("Country is not present in the records!");
            }
            if (this.countriesWithDistricts[country].Contains(district))
            {
                throw new ArgumentException("District is already present in the records!");
            }

            this.districtsById[district.Id] = district;
            this.countriesWithDistricts[country].Add(district);
            this.allDistricts.Add(district);
        }

        public void CreateCountry(Country country)
        {
            if (this.countriesById.ContainsKey(country.Id))
            {
                throw new ArgumentException("There is already a country with this Id!");
            }

            this.countriesById[country.Id] = country;
            this.countriesWithDistricts[country] = new HashSet<District>();
            this.allCountries.Add(country);
        }

        public bool Contains(District district) => this.districtsById.ContainsKey(district.Id);

        public bool Contains(Country country) => this.countriesById.ContainsKey(country.Id);

        public Country RemoveCountry(int id)
        {
            if (!this.countriesById.ContainsKey(id))
            {
                throw new ArgumentException("There is no country with the given Id!");
            }

            var country = this.countriesById[id];
            this.countriesById.Remove(id);

            foreach (var dist in this.countriesWithDistricts[country])
            {
                allDistricts.Remove(dist);
                this.districtsById.Remove(dist.Id);
            }

            this.countriesWithDistricts.Remove(country);
            this.allCountries.Remove(country);

            return country;
        }

        public District RemoveDistrict(int id)
        {
            if (!this.districtsById.ContainsKey(id))
            {
                throw new ArgumentException("There is no district with the given Id!");
            }

            var district = this.districtsById[id];
            this.districtsById.Remove(id);
            this.allDistricts.Remove(district);

            return district;
        }

        public int CountCountries() => this.countriesById.Count;

        public int CountDistricts() => this.districtsById.Count;

        public IEnumerable<District> GetDistricts(Country country)
        {
            if (!this.Contains(country))
            {
                throw new ArgumentException("Country is not present in the records!");
            }

            return this.countriesWithDistricts[country];
        }

        public IEnumerable<District> GetDistrictsOrderedBySize() => this.allDistricts.OrderBy(d => d.SqMeters);

        public IEnumerable<Country> GetCountriesOrderedByPopulationThenByNameDesc() =>
            this.allCountries.OrderBy(c => c.Population)
                .ThenByDescending(c => c.Name);

        public Dictionary<Country, HashSet<District>> GetCountriesAndDistrictsOrderedByDistrictsCountDescThenByCountryPopulationAsc()
        {
             this.countriesWithDistricts
                .OrderByDescending(kvp => this.countriesWithDistricts[kvp.Key].Count)
                .ThenBy(kvp => kvp.Key.Population);

            return this.countriesWithDistricts;
        }
    }
}