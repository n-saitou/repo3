using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Address> addresses = ReadCSV(@"C:\Users\n_sai\Downloads\personal_infomation.csv");
            ResistAddresses(addresses);
        }


        static List<Address> ReadCSV(string path)
        {
            var results = new List<Address>();
            var encode = new System.Text.UTF8Encoding(false);

            using (var reader = new System.IO.StreamReader(path, encode))
            {
                var csv = new CsvHelper.CsvReader(reader);
                var isSkip = true;
                while (csv.Read())
                {
                    if (isSkip)
                    {
                        isSkip = false;
                        continue;
                    }

                    var address = new Address
                    {
                        Name = csv.GetField<string>(0),
                        Kana = csv.GetField<string>(1),
                        Telephone = csv.GetField<string>(2),
                        Mail = csv.GetField<string>(3),
                        ZipCode = csv.GetField<string>(4).Replace("-", ""),
                        Prefecture = csv.GetField<string>(5),
                        StreetAddress = $"{csv.GetField<string>(6)}{csv.GetField<string>(7)}{csv.GetField<string>(8)}"
                    };

                    results.Add(address);
                }
            }

            return results;
        }

        static void ResistAddresses(List<Address> addresses)
        {
            using (var db = new AddressBookInfoEntities())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }

    }
}
