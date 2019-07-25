using Eureka_Bank_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Repository
{
    public class MyRepository
    {
        public static ObservableCollection<Person> PeopleRepository { get; set; }
        public static ObservableCollection<string> Sexes { get; set; }
        public static ObservableCollection<string> Currencies { get; set; }
        public static ObservableCollection<Address> AddressTypes { get; set; }
        public static ObservableCollection<Address> Cities { get; set; }
        public static ObservableCollection<Address> Regions { get; set; }
        public static ObservableCollection<Address> Countries { get; set; }
        public static ObservableCollection<WorkPlace> Legals { get; set; }
        public static ObservableCollection<WorkPlace> Areas { get; set; }
        public static ObservableCollection<string> Procurings { get; set; } //təminatların adlarının siyahısı
        public static ObservableCollection<string> TypesOfBuilding { get; set; }
        public static ObservableCollection<string> TypesOfOwnerShip { get; set; }
        public static ObservableCollection<string> YesNo { get; set; }
        public static ObservableCollection<string> TypesOfDeposit { get; set; }
        public static ObservableCollection<string> Banks { get; set; }
        public static ObservableCollection<Product> LoanProducts  { get; set; }
        public static ObservableCollection<Promotion> Promotions { get; set; }
        public static ObservableCollection<int> Periods { get; set; }

        static MyRepository()
        {
            Periods = new ObservableCollection<int>
            {
                3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24
            };

            Promotions = new ObservableCollection<Promotion>
            {
                new Promotion
                {
                    Name="8 Mart kampaniyası"
                },
                new Promotion
                {
                    Name="Ad günü kampaniyası"
                }
            };

            LoanProducts = new ObservableCollection<Product>()
            {
                new Product
                {
                    Name="Nağd kredit"
                },
            };

            Banks = new ObservableCollection<string>
            {
                 "AFB Bank",
                "Bank of Baku",
                "Əmrah Bank",
                "Nikoyl Bank",
                "Muğan Bank",
                "Beynəlxalq Bank",
                "Kapital Bank",
                "Express Bank",
                "BTB Bank",
                "VTB Bank",
                "Ziraat Bank",
                "Bank Respublika",
                "UniBank",
                "Rabitə Bank"
            };

            TypesOfDeposit = new ObservableCollection<string>
            {
                "Nağd pul girovu",
                "Əmanət girovu"
            };

            YesNo = new ObservableCollection<string>
            {
                "Bəli",
                "Xeyr"
            };

            TypesOfBuilding = new ObservableCollection<string>
            {
                "Həyət evi",
                "Mənzil",
                "Qaraj",
                "Obyekt",
                "Anbar",
                "Torpaq"
            };
            TypesOfOwnerShip = new ObservableCollection<string>
            {
                "Paylı",
                "Xüsusi",
                "Birgə"
            };

            Currencies = new ObservableCollection<string>
            {
                "AZN",
                "USD",
                "RUB",
                "EUR"
            };

            Procurings = new ObservableCollection<string>
            {
               "Zaminlik",
               "Əşya girovu",
               "Avtomobil girovu",
               "Daşınmaz əmlak girovu",
               "Zinyət əşyası",
               "Nağd pul girovu",
               "Dövriyyə vəsaiti"
            };
            Areas = new ObservableCollection<WorkPlace>
            {
                new WorkPlace
                {
                    Area="Maliyyə"
                },
                new WorkPlace
                {
                    Area="IT"
                },
                new WorkPlace
                {
                    Area="Logistika"
                },
                new WorkPlace
                {
                    Area="Hüquq"
                }

            };
            Legals = new ObservableCollection<WorkPlace>
            {
                new WorkPlace
                {
                    Legal="Bəli"
                },
                new WorkPlace
                {
                    Legal="Xeyr"
                }
            };

            Countries = new ObservableCollection<Address>
            {
                new Address{ Country= "Azərbaycan" },
                new Address{ Country= "Rusiya" },
                new Address{ Country= "Gürcüstan" },
                new Address{ Country= "Türkiyə" },
                new Address{ Country= "Qazaxstan" }
            };

            Sexes = new ObservableCollection<string>
            {
                "Kişi",
                "Qadın"
            };

            AddressTypes = new ObservableCollection<Address>
            {
                  new Address{ AdressType= "Faktiki" },
                new Address{AdressType= "Huquqi" }
            };

            Cities = new ObservableCollection<Address>
            {
                new Address{City= "Bakı" },
                new Address{City= "Sumqayıt" },
                new Address{City= "Xırdalan" },
                new Address{City= "Gəncə" },
                new Address{City= "Ağstafa" },
                new Address{City= "Daşkəsən" },
                 new Address{City= "Gədəbəy" },
                new Address{City= "Goranboy" },

                new Address{City= "Qazax" },

                new Address{City= "Şəmkir" },
                new Address{City= "Tovuz" },
                new Address{City= "Balakən" }
            };

            Regions = new ObservableCollection<Address>
            {
                new Address{Region= "Binəqədi" },
                new Address{Region= "Qaradağ" },
                new Address{Region= "Xəzər" },
                new Address{Region= "Səbail" },
                new Address{Region= "Sabunçu" },
                new Address{Region= "Suraxanı" },
                new Address{Region= "Pirallahı" },
                new Address{Region= "Sumqayıt" },
                new Address{Region= "Abşeron" },
                new Address{Region= "Xırdalan" },
                new Address{Region= "Quba" },
                new Address{Region= "Qusar" },
               new Address{Region= "Samux" },
               new Address{Region= "Göygöl" },
                new Address{Region= "Nəsimi" },
                new Address{Region= "Nərimanov" },
                new Address{Region= "Oğuz" },
                new Address{Region= "Yardımlı" },
                new Address{Region= "Beyləqan" },
                new Address{Region= "Hacıqabul" },
                new Address{Region= "Ağdam" },
            };

            PeopleRepository = new ObservableCollection<Person>()
            {
                    new Person
                {
                    Name="Kamran",
                    Surname="Aliyev",
                    Father_name="Asif",
                    ClientCode=12345,
                    FinCode="2QDGMZ0",
                    FullName="Aliyev Kamran Asif",
                    Id=1
                },
                     new Person
            {
                Name="Kamran",
                Surname="Aliyev",
                Father_name="Murad",
                ClientCode=123456,
                FinCode="2QDGMZ0",
                FullName="Aliyev Kamran Murad",
                Id=2
            },
             new Person
            {
                Name="Kamran",
                Surname="Babayev",
                Father_name="Murad",
                ClientCode=56984,
                FinCode="2QDGMZ0",
                FullName="Aliyev Kamran Murad",
                Id=3
            },
            new Person
            {
                Name="Kamal",
                Surname="Quliyev",
                Father_name="Ömər",
                ClientCode=52145,
                FinCode="3DFDS0D",
                FullName="Quliyev Kamal Ömər",
                Id=4
            },
            new Person
            {
                Name="Arif",
                Surname="Aliyev",
                Father_name="Mehman",
                ClientCode=963257,
                FinCode="2D5S3F2",
                FullName="ALiyev Arif Mehman",
                Id=5
                
            },
            new Person
            {
                Name="Orxan",
                Surname="Zeynalov",
                Father_name="Asif",
                ClientCode=257412,
                FinCode="963DRF6",
                FullName="Zeynalov Orxan Asif",
                Id=6
            },
            new Person
            {
                Name="Kamran",
                Surname="Həsənov",
                Father_name="Malik",
                ClientCode=895412,
                FinCode="7DFS2S3",
                FullName="Həsənov Kamran Malik",
                Id=7
            }
            };

        }
    }
}
