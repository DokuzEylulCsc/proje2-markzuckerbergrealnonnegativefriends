using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    //IKI FARKLI VIEW VAR
    class GorunumYonetici
    {
        public void KayitliMusteriler(List<Musteri> musteriler)
        {
            

            
            foreach(Musteri m in musteriler)
            {
                Console.WriteLine(m.Ad + " " + m.Soyad + " " + m.ID);
            }
        }

        public void VarolanOtelleriGoster()
        {
            throw new NotImplementedException();
        }

        public void Yoneticiler()
        {
            throw new NotImplementedException();
        }

        
    }
    class GorunumMusteri
    {
        public void UygunOtelleriGoster(List<Otel> o)
        {
            foreach (Otel otel in o)
            {
                if(otel is Hotel)
                {
                    Console.WriteLine(otel.OtelAdi + " " + otel.YildizSayisi + " " + otel.Sehir + " " +"(Hotel)");
                }
                if (otel is TatilKoyu)
                {
                    Console.WriteLine(otel.OtelAdi + " " + otel.YildizSayisi + " " + otel.Sehir + " " + "(TatilKoyu)");
                }
                if (otel is Pansiyon)
                {
                    Console.WriteLine(otel.OtelAdi + " " + otel.YildizSayisi + " " + otel.Sehir + " " + "(Pansiyon)");
                }

            }
        }

        public void KayitliRezervasyonlar(string ID)
        {
            string line;
            FileStream akis;
            StreamReader Okuma;

            string Yol = ID + ".txt";//Kisinin Rezervasyonlarının bulunduğu dosya
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis);

            line = Okuma.ReadLine();

            while (line != null)
            {
                line = Okuma.ReadLine();
            }
        }
    }
}
