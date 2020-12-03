using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Address
    {
        public int AddressID { get; set; }
        public String AddressHousename { get; set; }
        public String AddressStreetName { get; set; }
        public int AddressHouseNumber { get; set; }
        public int AddressFlatNumber { get; set; }
        public int AddressPostCode { get; set; }

        public virtual Street street { get; set; }
        public virtual PostCode postCode { get; set; }
        public virtual ICollection<User> users { get; set; }

        public Address() { }
        public Address(String Street, int HouseNumber, int Postcode)
        {
            this.AddressStreetName = Street;
            this.AddressHouseNumber = HouseNumber;
            this.AddressPostCode = Postcode;
        }
        public Address(String Street, int HouseNumber, int FlatNumber, int Postcode)
        {
            this.AddressStreetName = Street;
            this.AddressHouseNumber = HouseNumber;
            this.AddressFlatNumber = FlatNumber;
            this.AddressPostCode = Postcode;
        }
        public Address(String HouseName, String Street, int Postcode)
        {
            this.AddressHousename = HouseName;
            this.AddressStreetName = Street;
            this.AddressPostCode = Postcode;
        }
        public Address(String HouseName, String Street, int HouseNumber, int Postcode)
        {
            this.AddressHousename = HouseName;
            this.AddressStreetName = Street;
            this.AddressHouseNumber = HouseNumber;
            this.AddressPostCode = Postcode;
        }
        public Address(String HouseName, String Street, int HouseNumber, int FlatNumber, int Postcode)
        {
            this.AddressHousename = HouseName;
            this.AddressStreetName = Street;
            this.AddressHouseNumber = HouseNumber;
            this.AddressFlatNumber = FlatNumber;
            this.AddressPostCode = Postcode;
        }
    }
}
