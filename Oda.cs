using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    //Oda abstract class ından türetilmiş 3 farklı oda tipi
    abstract class Oda
    {
        public bool dolumu { get; set; }
        public Otel oteli { get; set; }
        public bool klima { get; set; }
        public bool TV { get; set; }
        public bool denizManzarası { get; set; }
        public bool miniBar { get; set; }
        public bool jakuzi { get; set; }
        public bool oyunKonsolu { get; set; }

        

        public double OdaNo { get; set; }//ÖZGÜN
        public double Fiyat { get; set; }

        public double Kisisayisi { get; set; }
        
    }
    class KralDairesi:Oda //herşey var
    {
        public KralDairesi(Otel oteli,bool klima, bool minibar, bool tv, bool denizmanzarasi, bool jakuzi,
            bool oyunkonsolu,double odano, double fiyat,double kisisayisi)
        {
            base.klima = klima;
            base.miniBar = minibar;
            base.TV = tv;
            base.denizManzarası = denizmanzarasi;
            base.jakuzi = jakuzi;
            base.oyunKonsolu = oyunkonsolu;
            
            base.OdaNo = odano;
            base.Fiyat = fiyat;
            base.oteli = oteli;

            
            base.Kisisayisi = kisisayisi;
        }
    }
    class LuxOda:Oda
    {
        public LuxOda(Otel oteli,bool klima,bool minibar,bool tv,bool denizmanzarasi,bool jakuzi,
            bool oyunkonsolu,double odano,double fiyat,double kisisayisi)
        {
            base.klima = klima;
            base.miniBar = minibar;
            base.TV = tv;
            base.denizManzarası = denizmanzarasi;
            base.jakuzi = jakuzi;
            base.oyunKonsolu = oyunkonsolu;
            
            base.OdaNo = odano;
            base.Fiyat = fiyat;
            base.oteli = oteli;

            
            base.Kisisayisi = kisisayisi;
        }
    }
    class StandartOda:Oda
    {
        public StandartOda(Otel oteli,bool klima, bool minibar, bool tv, bool denizmanzarasi, bool jakuzi,
            bool oyunkonsolu, double odano, double fiyat,double kisisayisi)
        {
            base.klima = klima;
            base.miniBar = minibar;
            base.TV = tv;
            base.denizManzarası = denizmanzarasi;
            base.jakuzi = jakuzi;
            base.oyunKonsolu = oyunkonsolu;
            
            base.OdaNo = odano;
            base.Fiyat = fiyat;
            base.oteli = oteli;

            
            base.Kisisayisi = kisisayisi;
        }
    }


}
