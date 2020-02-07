using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace JSON_Test
{
   //num1
        public class Profile
        {
            public string Full_name
            { get; set; }
            public string Birthday
            { get; set; }
            public List <string> Phones
            { get; set; }
        }
        public class Article
        {
            public int Id
            { get; set; }
            public string Title
            { get; set; }
            public string Published_at
            { get; set; }
        }
        public class User
        {
            public int Id
            { get; set; }
            public string Username
            { get; set; }
            public Profile Profile
            { get; set; }
            public List <Article> Articles
            { get; set; }
        }

    //num2
        public class Customer
        {
            public int Id
            { get; set; }
            public string Name
            { get; set; }
        }
        public class Items
        {
            public int Id
            { get; set; }
            public string Name
            { get; set; }
            public int Qty
            { get; set; }
            public int Price
            { get; set; }
        }
        public class Order
        {
            public string Order_id
            { get; set; }
            public string Created_at
            { get; set; }
            public Customer Customer
            { get; set; }
            public List <Items> Items
            { get; set; }
        }

    //num3
        public class Placement
        {
            public int Room_id
            { get; set; }
            public string Name
            { get; set; }
        }
        public class Inventory
        {
            public int Inventory_id
            { get; set; }
            public string Name
            { get; set; }
            public string Type
            { get; set; }
            public List <string> Tags
            {get;set;}
            public int Purchased_at
            { get; set; }
            public Placement Placement
            { get; set; }
        }

    class Program
    {
        static void Main(string[] args)
        {
            //Num1-Your tasks:
            var json1 = File.ReadAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/num1.json");

            var num1 = JsonConvert.DeserializeObject<List<User>>(json1);



            //Find users who doesn't have any phone numbers.
            List <string> NoPhone = new List<string>();
            foreach(var X in num1 )
            {
                if(X.Profile.Phones.Count==0)
                {
                    NoPhone.Add(X.Profile.Full_name);
                }
            }
            Console.WriteLine("users who doesn't have any phone numbers:");
            Console.Write(String.Join(", ", NoPhone));
            Console.WriteLine(" ");

            //Find users who have articles. //keluar duplikat
            List<string> HaveArticle = new List<string>();
            foreach (var X in num1)
            {
                foreach (var Y in X.Articles)
                {
                    
                    if ((Y.Title).Length != 0)
                    {

                        HaveArticle.Add(X.Profile.Full_name);
                    }
                }
                
            }
            var result = HaveArticle.Distinct();
            Console.WriteLine("users who have articles: ");
            Console.Write(String.Join(", ", result));
            Console.WriteLine(" ");

            //Find users who have "annis" on their name.
            List<string> Annis = new List<string>();
            foreach (var X in num1)
            {
                string S = X.Profile.Full_name;
                if ((S.ToLower()).Contains("annis"))
                {
                    Annis.Add(X.Profile.Full_name);
                }
            }
            Console.WriteLine("users who have \"annis\" on their name:");
            Console.Write(String.Join(", ", Annis));
            Console.WriteLine(" ");

            //Find users who have articles on year 2020.
            List<string> HaveArticle2020 = new List<string>();
            foreach (var X in num1)
            {
               
                foreach( var Y in X.Articles)
                {
                    if ((Y.Published_at).Substring(0, 4) == "2020")
                    {
                        HaveArticle2020.Add(Y.Title);
                    }
                }

            }
            Console.WriteLine("users who have articles on year 2020: ");
            Console.Write(String.Join(", ", HaveArticle2020));
            Console.WriteLine(" ");

            //Find users who are born on 1986.
            List<string> Born96 = new List<string>();
            foreach (var X in num1)
            {
                if ((X.Profile.Birthday).Substring(0, 4) == "1986")
                {
                    Born96.Add(X.Profile.Full_name);
                }
                
            }
            Console.WriteLine("users who are born on 1986:");
            Console.Write(String.Join(", ", Born96));
            Console.WriteLine(" ");

            //Find articles that contain "tips" on the title.
            List<string> TipsArticle = new List<string>();
            foreach (var X in num1)
            {
                foreach (var Y in X.Articles)
                {

                    if ((Y.Title).Contains("Tips"))
                    {

                        TipsArticle.Add(Y.Title);
                    }
                }

            }
            Console.WriteLine("articles that contain \"tips\" on the title: ");
            Console.Write(String.Join(", ", TipsArticle));
            Console.WriteLine(" ");

            //Find articles published before August 2019.
            List<string> pubAug = new List<string>();
            foreach (var X in num1)
            {
                foreach (var Y in X.Articles)
                {

                    int year = Convert.ToInt32((Y.Published_at).Substring(0,4));
                    int month = Convert.ToInt32((Y.Published_at).Substring(5, 2));
                    if (year==2019&&month<8)
                    {

                        pubAug.Add(Y.Title);
                    }
                    else if(year<2019)
                    {

                        pubAug.Add(Y.Title);
                    }
                }

            }
            Console.WriteLine("articles published before August 2019: ");
            Console.Write(String.Join(", ", pubAug));
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");







            //Num2-You need to do three things:
            var json2 = File.ReadAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/num2.json");

            var num2 = JsonConvert.DeserializeObject<List<Order>>(json2);

            //Find all purchases made in February.
            List<string> purFeb = new List<string>();
            foreach (var X in num2)
            {
                int month = Convert.ToInt32((X.Created_at).Substring(5, 2));
                if(month==2)
                {
                    purFeb.Add(X.Order_id);
                }
            }
            Console.WriteLine("all purchases made in February: ");
            Console.Write(String.Join(", ", purFeb));
            Console.WriteLine(" ");

            //Find all purchases made by Ari, and add grand total by sum all total price of items. The output should only a number.
            List<int> ariSum = new List<int>();
            
            foreach (var X in num2)
            {
                if(X.Customer.Name=="Ari")
                {
                    foreach(var Y in X.Items)
                    {
                        ariSum.Add((Y.Price)*(Y.Qty));
                    }
                }
                
            }
            int sum = 0;
            foreach( int buy in ariSum)
            {
                sum += buy;
            }
            Console.WriteLine("ari belanja: ");
            Console.Write(String.Join(", ", ariSum));
            Console.WriteLine(" ");
            Console.WriteLine($"total ari belanja: {sum}");
            
            Console.WriteLine(" ");

            //Find people who have purchases with grand total lower than 300000.The output is an array of people name.Duplicate name is not allowed.
            List<string> kaumHemat = new List<string>();
            List<string> BuyerName = new List<string>();
            foreach (var X in num2)
            {

                BuyerName.Add(X.Customer.Name);

            }
            var BuyName = BuyerName.Distinct();
            string[] buyName = BuyName.ToArray();
            int Names = BuyName.Count();
            int summ = 0;
            for (int i = 0; i < Names; i++)
            {
                foreach (var X in num2)
                {
                    if (X.Customer.Name == buyName[i])
                    {
                        foreach (var Y in X.Items)
                        {
                            summ += ((Y.Price) * (Y.Qty));
                        }

                    }
                }
                //Console.WriteLine(buyName[i]);
                //Console.WriteLine(summ);
                if (summ < 300000)
                {
                    kaumHemat.Add(buyName[i]);
                    summ = 0;
                }
                else
                {
                    summ = 0;
                }

            }

            Console.WriteLine("para kaum hemat who have purchases with grand total lower than 300000: ");
            Console.Write(String.Join(", ", kaumHemat));
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");





            //Num3-Your tasks:
            var json3 = File.ReadAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/num3.json");

            var num3 = JsonConvert.DeserializeObject<List<Inventory>>(json3);

            //Find items in Meeting Room, and save it to items.json.
            var MeetRoomItem = new List<Inventory>();
            foreach(var X in num3)
            {
                if(X.Placement.Name=="Meeting Room")
                {
                    MeetRoomItem.Add(X);
                }
            }
            var MeetRoomItemFile = JsonConvert.SerializeObject(MeetRoomItem);
            File.WriteAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/items.json", MeetRoomItemFile);
            //Console.WriteLine("items in Meeting Room: ");
            //Console.Write(String.Join(", ", MeetRoomItem));
            //Console.WriteLine(" ");


            //Find all electronic devices, and save it to electronic.json.
            var Electronics = new List<Inventory>();
            foreach (var X in num3)
            {
                if (X.Type == "electronic")
                {
                    Electronics.Add(X);
                }
            }
            var ElectronicsFile = JsonConvert.SerializeObject(Electronics);
            File.WriteAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/electronic.json", ElectronicsFile);
            //Console.WriteLine("all electronic devices: ");
            //Console.Write(String.Join(", ", Electronics));
            //Console.WriteLine(" ");



            //Find all furnitures, and save it to furnitures.json.
            var Furnitures = new List<Inventory>();
            foreach (var X in num3)
            {
                if (X.Type == "furniture")
                {
                    Furnitures.Add(X);
                }
            }
            var FurnitureFile = JsonConvert.SerializeObject(Furnitures);
            File.WriteAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/furnitures.json", FurnitureFile);
            //Console.WriteLine("all furnitures: ");
            //Console.Write(String.Join(", ", Furnitures));
            //Console.WriteLine(" ");

            //Find all items was purchased at 16 Januari 2020, and save it to purchased - at - 2020 - 01 - 16.json.
            var ItemJan = new List<Inventory>();

            foreach(var X in num3)
            {
                var timestamp = X.Purchased_at;
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(timestamp);
                if(date.Year==2020 && date.Month == 1 && date.Day == 16)
                {
                    ItemJan.Add(X);
                }
            }
            var ItemJanFile = JsonConvert.SerializeObject(ItemJan);
            File.WriteAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/purchased - at - 2020 - 01 - 16.json", ItemJanFile);
            //Console.WriteLine("all items was purchased at 16 Januari 2020: ");
            //Console.Write(String.Join(", ", ItemJan));
            //Console.WriteLine(" ");


            //Find all items with brown color, all-browns.json.
            var  Brown = new List<Inventory>();
            foreach (var X in num3)
            {
                for(int i=0;i<(X.Tags).Count();i++)
                {
                    if((X.Tags)[i]=="brown")
                    {
                        Brown.Add(X);
                    }
                }
            }
            var BrownFile = JsonConvert.SerializeObject(Brown);
            File.WriteAllText(@"/Users/user/Projects/JSON_Test/JSON_Test/all-browns.json", BrownFile);
            //Console.WriteLine("all brown items: ");
            //Console.Write(String.Join(", ", Brown));
            //Console.WriteLine(" ");

        }
    }
}
