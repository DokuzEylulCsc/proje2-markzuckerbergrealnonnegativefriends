using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    abstract class Kisiler
    {
        
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string ID { get; set; }       
    }

    class Musteri:Kisiler
    {
        
        public Musteri(string ad,string soyad,string id)
        {
            base.Ad = ad;
            base.Soyad = soyad;
            base.ID = id;
            
        }
    }

    class Yonetici:Kisiler
    {

        //SINGLETON
        private static Yonetici boss=null;

        public static Yonetici Yeni(string ad,string soyad,string id)
        {
               if (boss == null)
               {
                   boss = new Yonetici(ad,soyad,id);
                   
               }
               return boss;
            

        }
        
        private Yonetici(string ad, string soyad, string id)
        {
            base.Ad = ad;
            base.Soyad = soyad;
            base.ID = id;
            
        }
    }
}
