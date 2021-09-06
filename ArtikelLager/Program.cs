using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikelLager
{
    class Program 
    {
        
       private string output;
       private bool emptyList;
       private List<ItemsProperties> items;

        public Program()
        {
            output = "";
            emptyList = false;
            items = new List<ItemsProperties>();
            ReadList();
        }
        //Methods
      
        void ADDItem()
        {
            bool isNumericInt = false;
            bool isNumericDouble = false;
            string id = "";
            string price = "";
            emptyList = false;

            Console.WriteLine("\nArtikel erstellen: \n\n");

            //make sure that the entry is Numeric

            while (isNumericInt == false)
            {

                Console.Write("ID: \n");
                

                try
                {
                    id = Console.ReadLine();
                    int checkIsNumeric = int.Parse(id);
                    isNumericInt = true;
                    
                    
                    if(DoubleID(checkIsNumeric) == true)
                    {
                        Console.WriteLine("ID ist schon vergeben.");
                        isNumericInt = false;
                       
                    }
                    
                   
                    

                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nBitte nur Zahlen eingeben !");
                }
            }

            Console.Write("Name: \n");
            string name = Console.ReadLine();
            Console.Write("Country: \n");
            string country = Console.ReadLine();

            // make sure that the entry is Numeric

            while (isNumericDouble == false)
            {
                Console.Write("Preis: \n");
                
                try
                {
                    price = Console.ReadLine();
                    double checkIsfloat = double.Parse(price);
                    isNumericDouble = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nBitte nur Zahlen eingeben z.B.: 10,50 oder 10 !");
                }
            }
            Console.Write("Währung: \n");
            string currency = Console.ReadLine();
           
            items.Add(new ItemsProperties()
            {
                ID = Convert.ToInt32(id),
                Name = name,
                Country = country,
                Price = Convert.ToDouble(price),
                Currency = currency
            });


            //Create an new File to Save the new Items
            using (StreamWriter newFile = new StreamWriter(@".\files.txt", true, System.Text.Encoding.ASCII))
            {
                
                 output = "ID: " + id + "\n" + "Name: " + name + "\n" + "Country: " + country + "\n" + "Price: " + price + " " + currency;
                
                    newFile.WriteLine(output);
                

            };
           
            Console.WriteLine("\n\nDer neue Artikel wurde hinzugefügt: \n\n{0}", output);
            Console.WriteLine("\n\nBeliebige Taste drücken.");
            Console.ReadKey();
            output = "";

        }

        void ShowList()
        {
            ReadList();
            //If the List is not Empty Sort by ID, else write that the list is Empty
            if (emptyList == false)
            {
                //Sort the List by ID
                items.Sort();
                GetList();
                RemoveFromList();
            }
                
           
            

        }
        void GetList()
        {
            //Show the List to Console.
            foreach (ItemsProperties aItem in items)
            {
                Console.WriteLine(aItem + "\n\n");
            }
           

          
            
        }
        void SortListByName()
        {
            ReadList();
            //If the List is not Empty Sort by Name, else write that the list is Empty
            if(emptyList == false)
            {
                items.Sort(delegate (ItemsProperties x, ItemsProperties y)
                {
                    if (x.Name == null && y.Name == null) return 0;
                    else if (x.Name == null) return -1;
                    else if (y.Name == null) return 1;
                    else return x.Name.CompareTo(y.Name);
                });
                Console.WriteLine("Artikel sortiert nach Name:\n\n");
                foreach (ItemsProperties aItems in items)
                {
                    Console.WriteLine(aItems + "\n\n");
                }
                Console.WriteLine("\n\n Beliebige Taste drücken.");
                Console.ReadKey();
                RemoveFromList();
            }
            
        }
      
        private  bool DoubleID(int id)
        {

            bool hit = false;

           for(int i = 0; i < items.Count; i++)
            {
                
               if( items[i].ID == id)
                {
                    hit = true;
                }
            }
            if (hit == true)
            
                return true;
            
            else
                return false;

        }
        void SortListByCountry()
        {
            ReadList();
            //If the List is not Empty Sort by Country, else write that the list is Empty
            if (emptyList == false)
            {
                items.Sort(delegate (ItemsProperties x, ItemsProperties y)
                {
                   if (x.Country == null && y.Country == null) return 0;
                   else if (x.Country == null) return -1;
                   else if (y.Country == null) return 1;
                   else return x.Country.CompareTo(y.Country);
                });
                Console.WriteLine("Artikel sortiert nach Land:\n\n");
                foreach (ItemsProperties aItems in items)
                {
                    Console.WriteLine(aItems + "\n\n");
                }
                Console.WriteLine("\n\n Beliebige Taste drücken.");
                Console.ReadKey();

                RemoveFromList();
            }
        }
       
        void SortListByPrice()
        {
            ReadList();
            //If the List is not Empty Sort by Price, else write that the list is Empty
            if (emptyList == false)
            {
                List<ItemsProperties> newList = items.OrderBy(items => items.Price).ToList();
                Console.WriteLine("Artikel sortiert nach Preis:\n\n");
                foreach (ItemsProperties aItems in newList)
                {
                    Console.WriteLine(aItems + "\n\n");
                }
                Console.WriteLine("\n\n Beliebige Taste drücken.");
                Console.ReadKey();
                RemoveFromList();
            }
           

        }
        void SortByCurrency()
        {
            ReadList();
            //If the List is not Empty Sort by Currency, else write that the list is Empty
            if (emptyList == false)
            {
                items.Sort(delegate (ItemsProperties x, ItemsProperties y)
                {
                    if (x.Currency == null && y.Currency == null) return 0;
                    else if (x.Currency == null) return -1;
                    else if (y.Currency == null) return 1;
                    else return x.Currency.CompareTo(y.Currency);
                });
                Console.WriteLine("Artikel sortiert nach Waehrung:\n\n");
                foreach (ItemsProperties aItems in items)
                {
                    Console.WriteLine(aItems + "\n\n");
                }
                Console.WriteLine("\n\n Beliebige Taste drücken.");
                Console.ReadKey();

                RemoveFromList();
            }
           
        }
       
        void RemoveFromList()
        {
            bool isNumeric = false;
            int _id = 0;
            //If the List is not Empty Remove item, else write that the list is Empty
            if (emptyList == false)

            {
                Console.WriteLine("(c) Artikel Löschen");
                string clear = Console.ReadLine();
                switch (clear)
                {
                    case "c":
                        Console.WriteLine("\nWelcher Artikel soll gelöscht werden ?\n\n");
                        while (isNumeric == false)
                        {
                            bool hit = false;
                            Console.Write("ID eingeben: ");

                            try
                            {
                                _id = Convert.ToInt32(Console.ReadLine());

                                int checkIsNumeric = int.Parse(Convert.ToString(_id));
                                for (int i = 0; i < items.Count; i++)
                                {
                                    if (items[i].ID == checkIsNumeric)
                                        hit = true;
                                }
                                if(hit == false)
                                {
                                    Console.WriteLine("Diese ID ist nicht vorhanden.");
                                    isNumeric = false;
                                }
                                else
                                isNumeric = true;
                               
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nBitte nur Zahlen eingeben !");
                            }
                        }
                        Console.WriteLine("Sind Sie wirklich Sicher das der Artikel mit der ID: {0} gelöscht werden soll ?\n\n(1) Ja\n(2) Nein", _id);
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                items.Remove(new ItemsProperties() { ID = _id });

                                using (StreamWriter newFile = new StreamWriter(@".\files.txt", false, System.Text.Encoding.ASCII))
                                {
                                    //overrides the file without the removed Item
                                    foreach (ItemsProperties aItem in items)
                                    {
                                        newFile.WriteLine(aItem);
                                    }



                                };
                                ReadList();

                                GetList();
                                RemoveFromList();

                                break;
                            case 2:
                                ReadList();

                                GetList();
                                RemoveFromList();
                                break;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Zurück zum Hauptmenue");
                Console.ReadKey();
            }
           
        }
        void ReadList()
    {
           
            if (File.Exists(@".\files.txt"))
            {
                int count = 0;
                bool isEmpty = true;
                //Clear all items from list to write new
                items.Clear();
                using (StreamReader read = new StreamReader(@".\files.txt"))
                {
                    string rows = "";
                    string[] _ID = null;
                    string[] _Name = null;
                    string[] _Country = null;
                    string[] _Price = null;
                   

                    while (read.EndOfStream == false)
                    {
                        isEmpty = false;
                        rows = read.ReadLine();
                        switch (rows.Substring(0, 2))
                        {
                            case "ID":
                                _ID = rows.Split(':');
                                count++;
                                break;
                            case "Na":
                                _Name = rows.Split(':');
                                count++;
                                break;
                            case "Co":
                                _Country = rows.Split(':');
                                count++;
                                break;
                            //At Price the Currency is include at Split Array position 3
                            case "Pr":
                                _Price = rows.Split(':', ' ');
                                count++;
                                break;


                        }

                       
                        //If count has value 4 the Item is complete for Add to list,
                        //then set count value to 0 to read the next 4 rows to get the next Item
                        if (count == 4)
                        {
                            count = 0;
                            items.Add(new ItemsProperties()
                            {
                                ID = Convert.ToInt32(_ID[1]),
                                Name = _Name[1],
                                Country = _Country[1],
                                Price = Convert.ToDouble(_Price[2]),
                                Currency = _Price[3]
                            });
                        }

                    }
                };
                Console.Clear();
                if (isEmpty == true)
                {
                    emptyList = true;
                    Console.WriteLine("Keine Artikel gefunden.");
                    Console.ReadKey();
                }
            }
            else
                Console.WriteLine("Es wurde noch kein Artikel angelegt.");
    }

       

        static void Main(string[] args)
        {

            Program instance = new Program();

            string options;


            //The Selections Menue
            do
            {
                Console.WriteLine("Artikel Lager: \n\n");
                Console.WriteLine("(1) Bestand Sortieren nach ID\n(2) Bestand Sortieren nach Name\n(3) Bestand Sortieren nach Land\n(4) Bestand Sortieren nach Preis\n(5) Bestand Sortieren nach Waehrung\n(6) Artikel Hinzufügen\n(7) Beenden");
                Console.WriteLine("\n\n" + instance.output);
               options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                      instance.ShowList();

                        break;
                    case "2":
                        instance.SortListByName();
                        break;
                    case "3":
                        instance.SortListByCountry();
                        break;
                    case "4":
                        instance.SortListByPrice();
                        break;
                    case "5":
                        instance.SortByCurrency();
                        break;
                    case "6":
                        instance.ADDItem();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                   


                }
                Console.Clear();

                // So long optinons unequal with 7 Clear the Console and Show new to set another selection
            } while (options != "7");

            
        }

      
    }
}

