using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    //MUSTERI VE YONETICI CONTROLLER LARI FARKLI!!!!EK OLARAK VIEW SINIFLARIDA FARKLI CUNKU 
    class ControllerMusteri 
    {
        private GorunumMusteri view { get; set; }


        public ControllerMusteri(GorunumMusteri gm)
        {
            this.view = gm;
        }

        public void KayitOl(Musteri m)//Tamamlanmadı
        {
            string line;
            FileStream akis;
            StreamReader Okuma;

            string Yol = "Oteller.txt";
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis);

            line = Okuma.ReadLine();

            while (line != null)
            {
                line = Okuma.ReadLine();
            }
        }
        public void Rezervasyonlarim(string ID)
        {
            this.view.KayitliRezervasyonlar(ID);
        }

        public void RezervasyonYap()
        {
            throw new NotImplementedException();
        }

        public void UygunOteller(string sehir, string yildizSayisi,List<Otel> oteller)
        {
            
            List<Otel> uygun = new List<Otel>();

            

            foreach(Otel o in oteller)
            {
                if(o.Sehir==sehir && o.YildizSayisi==double.Parse(yildizSayisi))
                {
                    uygun.Add(o);
                }
            }
            if(uygun.Count==0)
            {
                Console.WriteLine("Aradiginiz kriterlerde otel bulunamadi");
            }
            else{
                this.view.UygunOtelleriGoster(uygun);
            }
            

            
        }
    }

    class ControllerYonetici
    {
        private GorunumYonetici view { get; set; }


        public ControllerYonetici(GorunumYonetici gy)
        {
            this.view = gy;
        }


        public void OtelEkle()
        {

        }
        public void OteleOdaEkle(Otel o)
        {

        }
        public void GenelDurum(List<Musteri> musteriler)
        {
            

            this.view.KayitliMusteriler(musteriler);
            this.view.VarolanOtelleriGoster();
            this.view.Yoneticiler();

        }
    }

    
}
