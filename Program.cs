using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using System;
using System.Collections.Generic;
using System.IO;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Coding\\csharp-lista-indirizzi\\addresses.csv";
            string path2 = "C:\\Coding\\csharp-lista-indirizzi\\addresses2.csv";

            List <Indirizzo> indirizziestrapolati = LeggiDalFileCsv(path);

            foreach (var indirizzo in indirizziestrapolati)
            {
                Console.WriteLine(indirizzo.ToString());
            }

            ScriviInTesto(indirizziestrapolati, path2);
        }

        static List<Indirizzo> LeggiDalFileCsv(string path)
        {
            List<Indirizzo> indirizzi = new List<Indirizzo>();
            int i = 0;

            try
            {
                using (var stream = new StreamReader(path))
                {
                    while (!stream.EndOfStream)
                    {
                        var linea = stream.ReadLine();
                        //if (linea == null)
                        //{
                        //    throw new ArgomentNullException
                        //    {
                        //        Console.WriteLine("L'argomento passato è null");
                        //    }
                        //}


                        if (i == 0) // Salto la prima riga 
                        {
                            i++;
                            continue;
                        }

                        // Ora i inizia da 1 dopo aver saltato la prima riga
                        var dati = linea.Split(',');
                        
                        if (dati.Length >= 6) 
                        {
                            string name = dati[0].Trim();
                            string surname = dati[1].Trim();
                            string street = dati[2].Trim();
                            string city = dati[3].Trim();
                            string province = dati[4].Trim();

                            
                            int zip = 0;
                            if (dati.Length > 5 && !string.IsNullOrWhiteSpace(dati[5]))
                            {
                                if (!int.TryParse(dati[5].Trim(), out zip))
                                {
                                    Console.WriteLine("Lo ZIP code non è valido. Il valore di ZIP sarà impostato a 0.");
                                }
                            }

                            Indirizzo indirizzo = new Indirizzo(name, surname, street, city, province, zip);
                            indirizzi.Add(indirizzo);
                        }
                        else
                        {
                            // Gestione errori se la linea non contiene abbastanza elementi
                            Console.WriteLine("La linea non contiene abbastanza elementi per un indirizzo completo.");
                        }

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura del file: {ex.Message}");
            }

            return indirizzi;
        }

        static void ScriviInTesto(List<Indirizzo> indirizzi, string path)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(path))
                {
                    foreach (var indirizzo in indirizzi)
                    {
                        stream.WriteLine(indirizzo.ToString());
                    }
                }

                Console.WriteLine($"Indirizzi scritti correttamente nel file: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la scrittura nel file: {ex.Message}");
            }
        }
    }
}





