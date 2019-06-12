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
            
            //Yönetici ıd=123 yönetici sifre=123
            //Yönetici singleton yapildi






            //PROGRAM BAŞLATILDIĞINDA MUSTERİLER ve OTELLER LİSTELERİ OLUŞTURULUP DATABASE DEKİ VERİLERİ ÇEKECEK
            //BU İŞLEMLER MAİNDE GEREKSİZ YER KAPLAMAMASI İÇİN BaslangicDosyaIslemleri ADLI SINIFIN STATIC METODLARINDA YAPILACAKTIR

            Yonetici boss = Yonetici.Yeni("Burak","Gomec","123","123");




            List<Musteri> Musteriler = new List<Musteri>();
            List<Otel> Oteller = new List<Otel>();
            List<Rezervasyon> Rezervasyonlar = new List<Rezervasyon>();

            Musteriler = BaslangicDosyaIslemleri.VeriTabanindakiMusteriler();
            Oteller = BaslangicDosyaIslemleri.VeriTabanindakiOteller();
            BaslangicDosyaIslemleri.VeriTabanindakiOdalar(Oteller);//İlgili otellerin odalar listelerini dolduracak
            
            //Sisteme kayıtlı olan tüm rezervasyonlar bu list e dönücek
            Rezervasyonlar = BaslangicDosyaIslemleri.VeriTabanindakiRezervasyonlar();

            
            

            

          

            //2 vıew 2 adet controller

            //Boylece musteri ve yonetici farklı view pencerelerine bağlanıcak (musteri kontrolcusu yoneticinin görebileceği view ı göremieyecek)
            GorunumMusteri gm = new GorunumMusteri();
            GorunumYonetici gy = new GorunumYonetici();

            ControllerMusteri C;
            ControllerYonetici Y;

            //  MVC kullanılacak (3 farklı model in kullanabileceği bir yapı olucak


            Tekrar: //goto tekrarı icin
            
            //CONSOLE İŞLEMLERİNİN BAŞLADIĞI YER ( ANA YAPI )
            try
            {
            
                Console.WriteLine(Environment.NewLine+"Otel Rezervasyon Sistemine Hosgeldiniz");
                Console.WriteLine(Environment.NewLine + "1-Kayit Ol");
                Console.WriteLine("2-Giris Yap");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:// KAYIT KISMI

                        C = new ControllerMusteri(gm, null, Rezervasyonlar);
                        C.KayitOl(Musteriler);

                        goto case 2;

                    case 2://GİRİŞ KISMI
                        Tekrar3:
                        Console.WriteLine(Environment.NewLine + "1-Musteri Girisi");
                        Console.WriteLine("2-Yonetici Girisi");


                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1://MUSTERİ GİRİŞİ
                                string ID;
                                Console.WriteLine(Environment.NewLine + "Lutfen ID nizi giriniz:");
                                ID = Console.ReadLine();
                                bool control = false;//ID sisteme kayıtlımı???
                                Console.WriteLine(Environment.NewLine + "Lutfen Sifrenizi giriniz:");
                                string sifre = Console.ReadLine();



                                //MusteriDosyaOku metodu bir musteri listesi dönücek

                                foreach (Musteri m in Musteriler)
                                {
                                    if (m.ID == ID && m.Sifre == sifre)
                                    {
                                        

                                        control = true;
                                        C = new ControllerMusteri(gm, m, Rezervasyonlar);//MÜŞTERİYE AİT BİR CONTROLLER AÇILDI
                                        Tekrar4:
                                        Console.WriteLine(m.Ad + " " + m.Soyad + " sisteme Hosgeldiniz" + Environment.NewLine);
                                        Console.WriteLine("1-Otel Ara" + Environment.NewLine +
                                            "2-Guncel rezervasyonumu/larimi iptal et" + Environment.NewLine +
                                            "3-Guncel Rezervasyonlarimi goruntule"+Environment.NewLine+"4-Gecmis Rezervasyonlarimi goruntule");

                                        switch (int.Parse(Console.ReadLine()))
                                        {
                                            case 1:
                                                


                                                C.UygunOdalar(Oteller,Rezervasyonlar);
                                                //başlangıçtaki rezervasyonlar listesinin değiştirilmiş hali şuan kontrollerda





                                                goto Tekrar4;//Rezervasyon yaptı peki başka bir isteği varmı?






                                                break;


                                            case 2://Rezervasyon İptali

                                                C.RezervasyonIptali();

                                                goto Tekrar4;

                                                break;


                                            case 3:
                                                C.GuncelRezervasyonlarim();
                                                goto Tekrar4
                                                    ;

                                                break;

                                            case 4:

                                                C.GecmisRezervasyonlarim();
                                                goto Tekrar4;

                                                break;

                                            default:
                                                Console.WriteLine("Yanlıs tuş girdiniz tekrar tuşlayiniz\n");
                                                goto Tekrar4;

                                                
                                        }//switch



                                    }
                                    else if (m.ID == ID && m.Sifre != sifre)
                                    {
                                        Console.WriteLine(Environment.NewLine + "Hatali sifre!!!!");
                                        goto case 1;

                                    }



                                }
                                if (control == false)
                                {
                                    Console.WriteLine(Environment.NewLine + "Kullanici bulunamadi");
                                    goto case 1;
                                }

                                //kullanıcı ıd sini girdikten sonra dosya okuma işlemi yapılacak sonra ordan gelen
                                //list içinde o ıd de biri varsa sisteme sorunsuz giriş yapıcak
                                //yoksa exception handling yapılacak


                                break;//...

                            case 2://YONETİCİ GİRİŞİ
                                Console.WriteLine(Environment.NewLine + "ID:");
                                string id = Console.ReadLine();
                                Console.WriteLine(Environment.NewLine + "Sifre:");
                                string parola = Console.ReadLine();

                                if (boss.ID == id && boss.Sifre == parola)
                                {


                                    Y = new ControllerYonetici(gy, Oteller);

                                Tekrar2:
                                    Console.WriteLine(Environment.NewLine + "1-Otel ekle" + Environment.NewLine +
                                        "2-Istedigin bir otele oda ekle"+Environment.NewLine+"3-Otellerin Genel Durumlari");
                                  
                                    switch (int.Parse(Console.ReadLine()))
                                    {

                                        case 1:
                                            //Oteller listesi degisti
                                            Oteller = Y.OtelEkle();

                                            break;

                                        case 2:

                                            Y.OteleOdaEkle();

                                            break;

                                        default:
                                            Y.GenelDurum(Rezervasyonlar);
                                            goto Tekrar2;
                                           


                                    }
                                }
                                else if (boss.ID == id && boss.Sifre != parola)
                                {
                                    Console.WriteLine(Environment.NewLine + "Hatali sifre Boss!!!");
                                    goto case 2;
                                }
                                else if (boss.ID != id)
                                {
                                    Console.WriteLine(Environment.NewLine + "Yanlis ID");
                                    goto case 2;
                                }



                                break;


                            default:
                                
                                goto Tekrar3;

                        }
                        break;

                    default://Ana switch case icin default
                        Console.WriteLine("Yanlıs tuş girdiniz tekrar tuşlayiniz\n");
                        goto Tekrar;





                }
            }
            catch (FormatException)
            {
                //Tekrar en basa dönülüyor hatalı bir giriste
                Console.WriteLine("Giris dizisini sayi olarak tuslayiniz(Bosluk ve enter girmeyiniz)\n");
                goto Tekrar;

            }
        }
    }
}
