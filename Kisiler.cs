using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    //Kişiler abstract class ından türetilmiş classlar
    abstract class Kisiler
    {
        
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string ID { get; set; }       

        public string Sifre { get; set; }
    }

    class Musteri:Kisiler
    {
        
        public Musteri(string ad,string soyad,string id,string sifre)
        {
            base.Ad = ad;
            base.Soyad = soyad;
            base.ID = id;
            base.Sifre = sifre;
        }
    }

    class Yonetici:Kisiler
    {

        //SINGLETON
        private static Yonetici boss=null;

        public static Yonetici Yeni(string ad,string soyad,string id,string sifre)
        {
               if (boss == null)
               {
                   boss = new Yonetici(ad,soyad,id,sifre);
                   
               }
               return boss;
            

        }
        
        private Yonetici(string ad, string soyad, string id,string sifre)
        {
            base.Ad = ad;
            base.Soyad = soyad;
            base.ID = id;
            base.Sifre = sifre;

            
        }
    }
}
