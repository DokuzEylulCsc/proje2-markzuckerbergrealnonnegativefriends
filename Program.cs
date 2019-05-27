using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Proje22019
{
    class Program
    {
        static void Main(string[] args)
        {
            //PROGRAM BAŞLATILDIĞINDA MUSTERİLER VE OTELLER LİSTELERİ OLUŞTURULUP DATABASE DEKİ VERİLERİ ÇEKECEK

            List<Musteri> Musteriler = new List<Musteri>();

            string[] gelen;
            string line;
            FileStream akis;
            StreamReader Okuma;
            string Yol = "Musteriler.txt";
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis);
            line = Okuma.ReadLine();

            while (line != null)
            {
                gelen = Regex.Split(line, @"\s+");
                Musteri yeni = new Musteri(gelen[0], gelen[1], gelen[2]);
                Musteriler.Add(yeni);
                yeni = null;
                line = Okuma.ReadLine();
            }
            akis.Close();




            List<Otel> Oteller = new List<Otel>();

            string[] Gelen;
            string Line;
            FileStream Akis;
            StreamReader okuma;
            string yol = "Oteller.txt";
            Akis = new FileStream(yol, FileMode.Open, FileAccess.Read);
            okuma = new StreamReader(Akis);
            Line = okuma.ReadLine();

            while (Line != null)
            {
                Gelen = Regex.Split(Line, @"\s+");
                if (Gelen[3] == "Hotel")
                {
                    Hotel yeni = new Hotel(Gelen[0], Gelen[1], double.Parse(Gelen[2]));
                    Oteller.Add(yeni);
                }
                else if (Gelen[3] == "TatilKoyu")
                {
                    TatilKoyu yeni = new TatilKoyu(Gelen[0], Gelen[1]);
                    Oteller.Add(yeni);
                }
                else if (Gelen[3] == "Pansiyon")
                {
                    Pansiyon yeni = new Pansiyon(Gelen[0], Gelen[1]);
                    Oteller.Add(yeni);
                }




                Line = okuma.ReadLine();
            }
            Akis.Close();
            //----------------------------------------------------------------------------------------------------

            //2 vıew 2 adet controller

            //Boylece musteri ve yonetici farklı view pencerelerine bağlanıcak (musteri kontrolcusu yoneticinin görebileceği view ı göremieyecek)
            GorunumMusteri gm = new GorunumMusteri();
            GorunumYonetici gy = new GorunumYonetici();

            ControllerMusteri C = new ControllerMusteri(gm);
            ControllerYonetici Y = new ControllerYonetici(gy);

            //  MVC kullanılacak (3 farklı model in kullanabileceği bir yapı olucak




            //CONSOLE İŞLEMLERİNİN BAŞLADIĞI YER
            Console.WriteLine("Otel Rezervasyon Sistemine Hosgeldiniz");
            Console.WriteLine("1-Kayit Ol");
            Console.WriteLine("2-Giris Yap");
            
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:// KAYIT KISMI
                    string isim;
                    string soyisim;
                    string id;

                    Console.WriteLine("Isminiz: ");
                    isim = Console.ReadLine();
                    Console.WriteLine("SoyIsminiz: ");
                    soyisim = Console.ReadLine();
                    Console.WriteLine("ID(T.C No): ");
                    id = Console.ReadLine();



                    break;


                case 2://GİRİŞ KISMI
                    Console.WriteLine("1-Musteri Girisi");
                    Console.WriteLine("2-Yonetici Girisi");
                    

                    switch(int.Parse(Console.ReadLine()))
                    {
                        case 1://MUSTERİ GİRİŞİ
                            string ID;
                            Console.WriteLine("Lutfen ID nizi giriniz:");
                            ID = Console.ReadLine();
                            bool control = false;//ID sisteme kayıtlımı???

                            //MusteriDosyaOku metodu bir musteri listesi dönücek

                            foreach(Musteri m in Musteriler)
                            {
                                if(m.ID==ID)
                                {
                                    control = true;//ID bulundu
                                    Console.WriteLine(m.Ad + " " + m.Soyad + " sisteme Hosgeldiniz"+Environment.NewLine);
                                    Console.WriteLine("1-Otel Ara"+Environment.NewLine+"2-Rezervasyon yap"+Environment.NewLine+
                                        "3-Guncel rezervasyonumu/larimi iptal et"+Environment.NewLine+
                                        "4-Rezervasyonlarimi goruntule");

                                    switch(int.Parse(Console.ReadLine()))
                                    {
                                        case 1:
                                            string sehir;
                                            string yildizS;
                                            
                                            Console.WriteLine("Sehir:");
                                            sehir=Console.ReadLine();
                                            Console.WriteLine("Yildiz:");
                                            yildizS = Console.ReadLine();

                                            C.UygunOteller(sehir, yildizS,Oteller);//Controller ın UygunOteller metoduna gidicek

                                            
                                            
                                            

                                            break;
                                        case 2:
                                            break;
                                        case 3:
                                            break;

                                    }
                                    

                                    
                                }
                            }
                            if(control==false)
                            {
                                Console.WriteLine(ID + " ID li herhangi bir kullanici yok!");
                                goto case 1;//case 1 i tekrarlar
                            }
                            //kullanıcı ıd sini girdikten sonra dosya okuma işlemi yapılacak sonra ordan gelen
                            //list içinde o ıd de biri varsa sisteme sorunsuz giriş yapıcak
                            //yoksa exception handling yapılacak


                            break;//...

                        case 2://YONETİCİ GİRİŞİ
                            break;
                    }
                    break;

            }
            
        }
    }
}
