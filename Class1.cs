using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Indirizzo
    {
        //sovrascrivere il metodo toString  

        string name { get; set; }
        string surname { get; set; }
        string street { get; set; }
        string city { get; set; }
        string province { get; set; }
        int zip;
        
        public Indirizzo (string name, string surname, string street, string city, string province, int zip)
        {
            this.name = name;
            this.surname = surname;
            this.street = street;
            this.city = city;
            this.province = province;
            this.zip = zip;
        }
        public override string ToString()
        {
            return $"{name} {surname}, {street}, {zip} {city} ({province})";
        }

    }



}
