using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikelLager
{
    public class ItemsProperties : IEquatable<ItemsProperties>, IComparable<ItemsProperties>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ItemsProperties objAsPart = obj as ItemsProperties;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return ID;
        }
        public bool Equals(ItemsProperties other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }

        // this Method returns a new Item to List
        public override string ToString()
        {
            return "ID: " + ID + "\n" + "Name: " + Name + "\n" + "Country: " + Country + "\n" + "Price: " + Price + " " + Currency;
        }
        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }
     
        public int CompareTo(ItemsProperties comparePart)
        {
            if (comparePart == null)
                return 1;
            else
                return this.ID.CompareTo(comparePart.ID);
        }

      
    }
}