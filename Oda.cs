using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    abstract class Oda
    {
        public bool dolumu { get; set; }

        public bool klima { get; set; }
        public bool TV { get; set; }
        public bool denizManzarası { get; set; }
        public bool miniBar { get; set; }
        public bool jakuzi { get; set; }
        public bool oyunKonsolu { get; set; }


        public double OdaNo { get; set; }
        public double Fiyat { get; set; }
        
    }
    class KralDairesi:Oda //herşey var
    {
        public KralDairesi(double odaNo,double yildizSayisi)
        {
            base.klima = true;
            base.miniBar = true;
            base.TV = true;
            base.denizManzarası = true;
            base.jakuzi = true;
            base.oyunKonsolu = true;
            
            if(yildizSayisi==5)
            {
                base.Fiyat = 1000;
            }
            else if (yildizSayisi == 4)
            {
                base.Fiyat = 800;
            }
            else if (yildizSayisi == 3)
            {
                base.Fiyat = 700;
            }
            else if (yildizSayisi == 2)
            {
                base.Fiyat = 600;
            }
            else if (yildizSayisi == 1)
            {
                base.Fiyat = 500;
            }


            base.dolumu = false;            
            base.OdaNo = odaNo;
        }
    }
    class LuxOda:Oda
    {
        public LuxOda(double odaNo,double yildizSayisi)
        {
            base.klima = true;
            base.miniBar = true;
            base.TV = true;
            base.denizManzarası = true;
            base.jakuzi = false;
            base.oyunKonsolu = false;
            if (yildizSayisi == 5)
            {
                base.Fiyat = 800;
            }
            else if (yildizSayisi == 4)
            {
                base.Fiyat = 700;
            }
            else if (yildizSayisi == 3)
            {
                base.Fiyat = 600;
            }
            else if (yildizSayisi == 2)
            {
                base.Fiyat = 500;
            }
            else if (yildizSayisi == 1)
            {
                base.Fiyat = 400;
            }


            base.dolumu = false;
            base.OdaNo = odaNo;
        }
    }
    class StandartOda:Oda
    {
        public StandartOda(double odaNo,double yildizSayisi)
        {
            base.klima = true;
            base.miniBar = true;
            base.TV = true;
            base.denizManzarası = false;
            base.jakuzi = false;
            base.oyunKonsolu = false;
            if (yildizSayisi == 5)
            {
                base.Fiyat = 600;
            }
            else if (yildizSayisi == 4)
            {
                base.Fiyat = 500;
            }
            else if (yildizSayisi == 3)
            {
                base.Fiyat = 400;
            }
            else if (yildizSayisi == 2)
            {
                base.Fiyat = 300;
            }
            else if (yildizSayisi == 1)
            {
                base.Fiyat = 200;
            }
            base.dolumu = false;
            base.OdaNo = odaNo;
        }
    }


}
