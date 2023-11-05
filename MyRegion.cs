using System;
using System.Collections.Generic;
using System.Text;
using XF_GoldenStore.Model;

namespace XF_GoldenStore.ModelServices
{
    public class MyRegion
    {
        public List<Zone> GetZone()
        {
            return new List<Zone>
            {
                new Zone{Id=1,Name="Qassim"},
                new Zone{Id=2,Name="Riyadh"},
                new Zone{Id=3, Name="Madinah"},
                new Zone{Id=4, Name="Asir"},
                new Zone{Id=5, Name="Tabuk"}
            };
        }
        public List<City> GetCity()
        {
            return new List<City>
            {
                new City{Id=1,Name="Buraydah", ZId=1},
                new City{Id=2,Name="Unizah", ZId=1},
                new City{Id=3,Name="Alrass", ZId=1},
                new City{Id=4,Name="Albakiriya", ZId=1},
                new City{Id=5,Name="Al bandaria", ZId=1},

                new City{Id=6,Name="Riyadh", ZId=2},
                new City{Id=7,Name="Deraih", ZId=2},
                new City{Id=8,Name="Mjmah", ZId=2},
                new City{Id=9,Name="Romah", ZId=2},

                new City{Id=10,Name="Khaiber", ZId=3},
                new City{Id=11,Name="Alhanakiya", ZId=3},
                new City{Id=12,Name="Yanbu", ZId=3},
                new City{Id=13,Name="Mahd Al-Dhahab", ZId=3},
                new City{Id=14,Name="Uqlat Al Suqour", ZId=3},

                new City{Id=15,Name="Abha", ZId=4},
                new City{Id=16,Name="Al Bahah", ZId=4},
                new City{Id=17,Name="Mahayil Asir", ZId=4},
                new City{Id=18,Name="Tanomah", ZId=4},
                new City{Id=19,Name="Al Namas", ZId=4},

                 new City{Id=20,Name="AlUla", ZId=5},
                new City{Id=21,Name="Sharma", ZId=45},
                new City{Id=22,Name="Dhaba", ZId=5},
                new City{Id=23,Name="Shaqri", ZId=5},
                new City{Id=24,Name="Al-Muwaileh", ZId=5},
            };
        }
    }
   
}
