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

        public void GenelDurum(List<Otel> Oteller,List<Rezervasyon> Rezervasyonlar)
        {

            Console.WriteLine(Environment.NewLine + "--------Genel Durum--------");

            List<Oda> doluOdalar = new List<Oda>();
            
            foreach(Otel o in Oteller)
            {
                bool control = true;
                foreach (Rezervasyon r in Rezervasyonlar)
                {
                    
                    if (r.otel==o.OtelAdi)
                    {
                        if(o.Odalar!=null)
                        {
                            foreach (Oda room in o.Odalar)
                            {
                                if (double.Parse(r.odaNo) == room.OdaNo)
                                {
                                    //Aynı dolu odayı tekrar tekrar doluOdalara eklemesin diye yaptık

                                    
                                    foreach (Oda x in doluOdalar)
                                    {
                                        if ((room.oteli == x.oteli) && (room.OdaNo == x.OdaNo))
                                        {
                                            control = false;
                                        }
                                    }
                                    if (control == true)
                                    {
                                        doluOdalar.Add(room);
                                    }
                                    

                                }
                            }
                        }
                        

                    }
                }
                Console.WriteLine(Environment.NewLine+o.OtelAdi + ";");

                Console.WriteLine(Environment.NewLine+"Dolu Odalar;");

                if(doluOdalar!=null)
                {
                    foreach (Oda oda in doluOdalar)
                    {
                        Console.WriteLine("OdaNo: " + oda.OdaNo + "   Kalan kisi sayisi sayisi: " + oda.Kisisayisi + "   Fiyat: " + oda.Fiyat);
                    }

                    Console.WriteLine(Environment.NewLine + "Toplam Dolu Oda Sayisi: " + doluOdalar.Count);
                    
                }
                doluOdalar.Clear();



            }
            
        }

        
    }



    class GorunumMusteri
    {
        public void OdalariGoster(List<Oda> o,bool control)
        {
            int i = 0;

            if(control==true)//Odalar boşsa bunu ekrana yazdırsın
            {
                Console.WriteLine(Environment.NewLine+"Aradiginiz kriterlerdeki boş odalar;"+Environment.NewLine);
            }
                      
            foreach (Oda oda in o)
            {
                Console.WriteLine(i.ToString() + "-" + oda.oteli.Sehir + " " + oda.oteli.OtelAdi +
                    " Yildiz:" + oda.oteli.YildizSayisi +
                    " OdaNo:" + oda.OdaNo
                    + " Fiyat:" + oda.Fiyat);

                i++;
            }
        }

        public void GecmisRezervasyonlar(List<Rezervasyon> GecmisRezervasyonlar)//Müşterinin kendi dosyasındaki rezervasyonları ekrana basıcak
        {
            int i = 1;
            if(GecmisRezervasyonlar.Count==0)
            {
                Console.WriteLine(Environment.NewLine + "Gecmis rezervasyonunuz bulunmamaktadir!");
            }
            foreach (Rezervasyon r in GecmisRezervasyonlar)
            {
                
                    Console.WriteLine(i + "  Sehir:" + r.sehir + "  Otel:" + r.otel + "  OdaNo:"
                        + r.odaNo + "  BaslangicTarihi:" + r.Baslangıc + "  CikisTarihi:" + r.Cikis);
                    i++;
                
            }
        }

        public void GuncelRezervasyonlar(List<Rezervasyon> GuncelRezervasyonlar)//Müşterinin kendi dosyasındaki rezervasyonları ekrana basıcak
        {
            int i = 1;
            foreach (Rezervasyon r in GuncelRezervasyonlar)
            {

                Console.WriteLine(i + "  Sehir:" + r.sehir + "  Otel:" + r.otel + "  OdaNo:"
                    + r.odaNo + "  BaslangicTarihi:" + r.Baslangıc + "  CikisTarihi:" + r.Cikis);
                i++;

            }
        }
    }
}
