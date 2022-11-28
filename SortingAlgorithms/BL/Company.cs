using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.BL
{
    public class Company
    {
        private int index;
        private string id;
        private string name;
        private string website;
        private string country;
        private string description;
        private int foundedYear;
        private string industry;
        private int noOfEmployees;

        public int Index { get => index; set => index = value; }
        public int NoOfEmployees { get => noOfEmployees; set => noOfEmployees = value; }
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Website { get => website; set => website = value; }
        public string Country { get => country; set => country = value; }
        public string Description { get => description; set => description = value; }
        public int FoundedYear { get => foundedYear; set => foundedYear = value; }
        public string Industry { get => industry; set => industry = value; }

        public Company(int index, string id, string name, string website, string country, string description, int foundedYear, string industry, int noOfEmployees)
        {
            this.Index = index;
            this.Id = id;
            this.Name = name;
            this.Website = website;
            this.Country = country;
            this.Description = description;
            this.FoundedYear = foundedYear;
            this.Industry = industry;
            this.NoOfEmployees = noOfEmployees;
        }
        public Company()
        {
        }
    }
}
