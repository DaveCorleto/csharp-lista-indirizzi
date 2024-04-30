using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Indirizzo
    {
        //sovrascrivere ili metodo toString  

        string name;
        string surname;
        string street;
        string city;
        string province;
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
    }



}
