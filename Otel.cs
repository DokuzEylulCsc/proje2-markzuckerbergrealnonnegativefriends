using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    //Otel abstract class ından türetilmiş oteller
    abstract class Otel
    {
        public string Sehir { get; set; }
        public string OtelAdi { get; set; }
        public double YildizSayisi { get; set; }
        

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

        List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();

        public List<Rezervasyon> Rezervasyonlar
        {
            get
            {
                return rezervasyonlar;
            }
            set
            {
                rezervasyonlar = value;
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

            
        }
    }

    class TatilKoyu:Otel
    {
        public TatilKoyu(string sehir, string otelAdi)
        {
            base.OtelAdi = otelAdi;
            base.Sehir = sehir;
            base.YildizSayisi = 3;

            
        }
    }

    class Pansiyon:Otel
    {
        public Pansiyon(string sehir, string otelAdi)
        {
            base.OtelAdi = otelAdi;
            base.Sehir = sehir;
            base.YildizSayisi = 1;

            
        }
    }
}
