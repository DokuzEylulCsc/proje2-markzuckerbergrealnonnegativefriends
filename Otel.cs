using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    abstract class Otel
    {
        public string Sehir { get; set; }
        public string OtelAdi { get; set; }
        public double YildizSayisi { get; set; }
        private double[] fiyatAraligi = new double[2];
        
        public double[] FiyatAraligi
        {
            get
            {
                return fiyatAraligi;
            }
            set
            {
                fiyatAraligi = value;
            }
        }

        List<Oda> odalar = new List<Oda>();

        public List<Oda> Odalar
        {
            get
            {
                return odalar;
            }
            set
            {
                odalar = value;
            }
        }



    }

    class Hotel:Otel
    {
        public Hotel(string sehir,string otelAdi,double yildizSayisi)
        {
            base.OtelAdi = otelAdi;
            base.Sehir = sehir;
            base.YildizSayisi = yildizSayisi;

            if(yildizSayisi==5)
            {
                base.FiyatAraligi[0] = 600;
                base.FiyatAraligi[1] = 1000;
            }
            if (yildizSayisi == 4)
            {
                base.FiyatAraligi[0] = 500;
                base.FiyatAraligi[1] = 800;
            }
            if (yildizSayisi == 3)
            {
                base.FiyatAraligi[0] = 400;
                base.FiyatAraligi[1] = 700;
            }
            if (yildizSayisi == 2)
            {
                base.FiyatAraligi[0] = 300;
                base.FiyatAraligi[1] = 600;
            }
            if (yildizSayisi == 1)
            {
                base.FiyatAraligi[0] = 200;
                base.FiyatAraligi[1] = 500;
            }
        }
    }

    class TatilKoyu:Otel
    {
        public TatilKoyu(string sehir, string otelAdi)
        {
            base.OtelAdi = otelAdi;
            base.Sehir = sehir;
            base.YildizSayisi = 3;

            base.FiyatAraligi[0] = 400;
            base.FiyatAraligi[1] = 700;
        }
    }

    class Pansiyon:Otel
    {
        public Pansiyon(string sehir, string otelAdi)
        {
            base.OtelAdi = otelAdi;
            base.Sehir = sehir;
            base.YildizSayisi = 1;

            base.FiyatAraligi[0] = 200;
            base.FiyatAraligi[1] = 500;
        }
    }
}
