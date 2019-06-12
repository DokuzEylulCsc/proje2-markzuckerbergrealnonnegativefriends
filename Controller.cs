using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proje22019
{
    //MUSTERI VE YONETICI CONTROLLER LARI FARKLI!!!!EK OLARAK VIEW SINIFLARIDA FARKLI CUNKU 
    class ControllerMusteri 
    {
        private GorunumMusteri view { get; set; }
        private Musteri m { get; set; }
        private List<Rezervasyon> Rezervasyonlar { get; set; }


        public ControllerMusteri(GorunumMusteri gm,Musteri m,List<Rezervasyon> Rezervasyonlar)
        {
            this.view = gm;
            this.m = m;
            this.Rezervasyonlar = Rezervasyonlar;
        }


        //Bosluk ve enter almaması lazım string oldugu icin alıyor yada bu sekilde kontrol edicez.
        //Artik ayni ID ile kayit olunamiyacak
        public void KayitOl(List<Musteri> a)
        {
            string isim = null;
            string soyisim = null;
            string id = null;
            string sifre = null;

            bool control = false;//ID baskasi tarafindan kullaniliyormu diye kontrol edicez

            try
            {
                Console.WriteLine("Isminiz: ");
                isim = Console.ReadLine();
                if (isim == " " || isim == "#" || isim == "  " || soyisim == " " || soyisim == "#" || soyisim == "  "
                 || id == " " || id == "#" || id == "  " || sifre == " " || isim == "#" || isim == "  ")
                {
                    Console.WriteLine("Giris diziniz dogru bicimde değil");
                    //Bunu böyle if le değilde try catch mantığıyla yapmamaız lazım
                }
                Console.WriteLine("SoyIsminiz: ");
                soyisim = Console.ReadLine();
                Console.WriteLine("ID(Unique Number): ");

                foreach(Musteri m in a)
                {
                    if(m.ID==Console.ReadLine())
                    {
                        control = true;
                        break;
                    }
                    
                }
                if(control==true)
                {
                    Console.WriteLine("Bu ID kullaniliyor! Farkli bir ID girin");

                    Console.WriteLine("ID(Unique Number): ");
                    id = Console.ReadLine();
                }
                else
                {
                    id = Console.ReadLine();
                    
                }

                Console.WriteLine("Şifreniz:");
                sifre = Console.ReadLine();
                if (isim == " " || isim =="#" || isim=="  " || soyisim==" " || soyisim=="#" || soyisim=="  "
                    || id == " " || id == "#" || id == "  " || sifre == " " || isim == "#" || isim == "  ")
                {
                    Console.WriteLine("Giris diziniz dogru bicimde değil");
                }
                else
                {
                    Musteri kayit = new Musteri(isim, soyisim, id, sifre);
                    a.Add(kayit);
                    StreamWriter yaz = new StreamWriter("Tummusteriler.txt");
                    foreach (Musteri x in a)
                    {
                        yaz.WriteLine(x.Ad + " " + x.Soyad + " " + x.ID + " " + x.Sifre);
                    }
                    yaz.Close();
                }
              


            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
               

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }


            control = false;

        }


        //Kişinin sisteme kayıtlı olan guncel rezervasyonlarını gösterir
        public void GecmisRezervasyonlarim()
        {
            List<Rezervasyon> GecmisRezervasyonlar = new List<Rezervasyon>();
            
            foreach (Rezervasyon r in this.Rezervasyonlar)
            {
                if ((r.id == m.ID) && r.Cikis < DateTime.Now)//Eski rezervasyonları göstericek
                {
                    GecmisRezervasyonlar.Add(r);
                }
            }
            this.view.GecmisRezervasyonlar(GecmisRezervasyonlar);
        }
        //Kişinin sisteme kayıtlı olan gecmis(çıkış tarihi datetime.now dan küçük olan) rezervasyonlarını gösterir
        public List<Rezervasyon> GuncelRezervasyonlarim()
        {
            List<Rezervasyon> GuncelRezervasyonlarim = new List<Rezervasyon>();

            foreach (Rezervasyon r in this.Rezervasyonlar)
            {
                if ((r.id == m.ID) && r.Baslangıc > DateTime.Now)//Eski rezervasyonları göstericek
                {
                    GuncelRezervasyonlarim.Add(r);
                }
            }
            this.view.GuncelRezervasyonlar(GuncelRezervasyonlarim);

            return GuncelRezervasyonlarim;//Rezervasyon iptalinde kullanılacak!!!
        }



        //REZERVASYON İŞLEMİ TAMAMLANIP ODALAR.TXT DOSYASI GÜNCELLENİCEK, EK OLARAK KİŞİNİN ID SİNE GÖRE BİR TXT DOSYASI AÇILIP
        //REZERVASYON BİLGİLERİ KAYIT EDİLECEK
        public void RezervasyonYap(Oda o,List<Otel> oteller,DateTime btarihi,DateTime ctarihi)//----------------------------------
        {
            foreach(Otel otel in oteller)
            {
                foreach(Oda oda in otel.Odalar)
                {
                    if(o.OdaNo==oda.OdaNo && o.oteli==otel)
                    {
                        

                        //Oda nın b tarihi ve c tarihi değişti bu değişikliğe göre tüm otellerin tüm odalari tekrar text e yazılacak

                        

                        Console.WriteLine("Rezervasyonunuz basariyla gerceklesti!");

                        //TAMAMLANAN REZERVASYON MÜŞTERİNİN REZERVASYONLARINA EKLENİYOR
                        Rezervasyon yeni = new Rezervasyon(btarihi, ctarihi, DateTime.Now, otel.OtelAdi, 
                            oda.OdaNo.ToString(), otel.Sehir, m.Ad, m.Soyad, m.ID);
                        this.Rezervasyonlar.Add(yeni);
                        
                    }
                }
            }
            




            //Kişinin adı soyadı ve ıd si adında bir dosya açılıp dosyaya kişinin tüm rezervasyon listesi yazılacak!!!!!!!!!!!!
            //------------------------------------------------------------------------------
            //ÇALIŞMIYOR??????????????

            string yol = "Rezervasyonlar.txt";           
            StreamWriter yaz1 = new StreamWriter(yol);


            //ODANIN BİR "Oteli" diye özelliğinin bulunmasi dogrumu??????????????????????????????????????????????????????????????????????
            //Doğru değilse nasıl yapılabilir???????????????????????????????????????????????????????????
           
            foreach(Rezervasyon r in Rezervasyonlar)
            {
                yaz1.WriteLine(r.isim + " " + r.soyisim + " " + r.id+" " + r.sehir + " " + r.otel + 
                    " " + r.odaNo + " " + r.islemSaati + " " + r.Baslangıc + " " + r.Cikis);

            }
            yaz1.Close();
            
            




        }

        //KİŞİNİN İSTEDİĞİ KRİTERLERDEKİ VE İSTEDİĞİ TARİHLER ARASINDA BOŞ OLAN ODALARI GÖSTERİCEK
        public void UygunOdalar(List<Otel> oteller,List<Rezervasyon> Rezervasyonlar)
        {

            string sehir;
            string yildizS;
            double fiyat1;
            double fiyat2;
            DateTime baslangicTarihi;
            DateTime cikisTarihi;

            Console.WriteLine(Environment.NewLine + "Oda seçeneklerini 'E' veya 'H' olarak tuslayiniz");

            Console.WriteLine(Environment.NewLine + "Sehir:");
            sehir = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Yildiz:");
            yildizS = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Klima:");
            string klima = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Minibar:");
            string minibar = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "TV:");
            string tv = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Deniz Manzarasi:");
            string denizmanzara = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Jakuzi:");
            string jakuzi = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Oyun Konsolu:");
            string oyunkonsol = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Kac kisilik:");
            double kisiSayisi = double.Parse(Console.ReadLine());


            bool klimalar = true;
            if (klima == "E" || klima == "e" || klima == "Evet" || klima == "evet")
            {
                klimalar = true;
            }
            else if (klima == "H" || klima == "h" || klima == "Hayır" || klima == "hayır")
            {
                klimalar = false;
            }
            bool minibarlar = true;
            if (minibar == "E" || minibar == "e" || minibar == "Evet" || minibar == "evet")
            {
                minibarlar = true;
            }
            else if (minibar == "H" || minibar == "h" || minibar == "Hayır" || minibar == "hayır")
            {
                minibarlar = false;
            }
            bool tvler = true;
            if (tv == "E" || tv == "e" || tv == "Evet" || tv == "evet")
            {
                tvler = true;
            }
            else if (tv == "H" || tv == "h" || tv == "Hayır" || tv == "hayır")
            {
                tvler = false;
            }
            bool denizmanzarasi = true;
            if (denizmanzara == "E" || denizmanzara == "e" || denizmanzara == "Evet" || denizmanzara == "evet")
            {
                denizmanzarasi = true;
            }
            else if (denizmanzara == "H" || denizmanzara == "h" || denizmanzara == "Hayır" || denizmanzara == "hayır")
            {
                denizmanzarasi = false;
            }
            bool jakuziler = true;
            if (jakuzi == "E" || jakuzi == "e" || jakuzi == "Evet" || jakuzi == "evet")
            {
                jakuziler = true;
            }
            else if (jakuzi == "H" || jakuzi == "h" || jakuzi == "Hayır" || jakuzi == "hayır")
            {
                jakuziler = false;
            }
            bool oyunkonsolları = true;
            if (oyunkonsol == "E" || oyunkonsol == "e" || oyunkonsol == "Evet" || oyunkonsol == "evet")
            {
                oyunkonsolları = true;
            }
            else if (oyunkonsol == "H" || oyunkonsol == "h" || oyunkonsol == "Hayır" || oyunkonsol == "hayır")
            {
                oyunkonsolları = false;
            }
            Console.WriteLine(Environment.NewLine + "Minimum Fiyat:");
            fiyat1 = double.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Maksimum Fiyat:");
            fiyat2 = double.Parse(Console.ReadLine());




            Console.WriteLine(Environment.NewLine + "Baslangic Tarihi:");
            baslangicTarihi = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine + "Cikis Tarihi:");
            cikisTarihi = DateTime.Parse(Console.ReadLine());


            //Date Time lar ile ilgili olusabilecek istisnalar;
            if ((cikisTarihi < baslangicTarihi))
            {
                LogKayıt.LogKaydedici("Uygun Odalar:Baslangic tarihi cikis tarihinden sonra olamaz!");
                throw new DateInputProblem("Baslangic tarihi cikis tarihinden sonra olamaz!");
                

            }
            else if (baslangicTarihi < DateTime.Now || cikisTarihi < DateTime.Now)
            {
                LogKayıt.LogKaydedici("Uygun Odalar: Gecmise rezervasyon yapılamaz!");
                throw new DateInputProblem("Gecmise rezervasyon yapılamaz!");
            }

            List<Oda> uygunOdalar = new List<Oda>();
            List<Oda> doluOdalar = new List<Oda>();
            

            foreach(Otel o in oteller)
            {
                if(o.Sehir==sehir && o.YildizSayisi==double.Parse(yildizS))
                {
                    foreach(Oda room in o.Odalar)
                    {
                        if(room.klima==klimalar && room.miniBar==minibarlar && room.TV==tvler
                            && room.denizManzarası==denizmanzarasi && room.jakuzi==jakuziler && room.oyunKonsolu==oyunkonsolları && room.Fiyat>=fiyat1
                            && room.Fiyat<= fiyat2 && room.Kisisayisi==kisiSayisi)                            
                        {
                            foreach(Rezervasyon r in Rezervasyonlar)
                            {
                                if((room.oteli.OtelAdi==r.otel) && (room.OdaNo==double.Parse(r.odaNo)))
                                {
                                    if((cikisTarihi<r.Baslangıc) && (baslangicTarihi>r.Cikis))
                                    {
                                        uygunOdalar.Add(room);
                                    }
                                    else
                                    {
                                        //Aynı odaya binlerce farklı tarihe rezervasyon olabilir doluOdalar da aynı oda binlerce yer kaplar!!!
                                        bool control = true;//Aynı dolu odayı tekrar tekrar doluOdalara eklemesin diye yaptık
                                        foreach(Oda x in doluOdalar)
                                        {
                                            if((room.oteli==x.oteli) && (room.OdaNo==x.OdaNo))
                                            {
                                                control = false;
                                            }
                                        }
                                        if(control==true)
                                        {
                                            doluOdalar.Add(room);
                                        }
                                        
                                    }
                                }
                            }
                            
                            
                        }
                    }
                }
            }
            if(uygunOdalar.Count==0)
            {
                if(doluOdalar.Count>=1)//ODALAR BULUNDU FAKAT BULUNAN ODALAR DOLU
                {
                    Console.WriteLine("Aradiginiz kriterlerdeki odalar bulundu fakat istediginiz tarihler arasinda dolular!:");
                    this.view.OdalariGoster(doluOdalar, false);

                }
                else if(doluOdalar.Count==0)
                {
                    Console.WriteLine("Aradiginiz kriterlere sahip oda bulunamadi!!");
                }
            }
            else{
                this.view.OdalariGoster(uygunOdalar,true);

                Console.WriteLine("Hangi odayi tercih edeceksiniz??");
                RezervasyonYap(uygunOdalar[int.Parse(Console.ReadLine())], oteller, baslangicTarihi, cikisTarihi);//Müşterinin tercih ettiği oda rezerve edilecek
            }

            

            
            
        }

        
        public void RezervasyonIptali()//Burda da bir try catch
        {
            List<Rezervasyon> guncelRezervasyonlar;
            guncelRezervasyonlar=this.GuncelRezervasyonlarim();
            
            Console.WriteLine(Environment.NewLine + "Hangi guncel rezervasyonunuzu iptal ediceksiniz?");

            Rezervasyon silinecekOlan = guncelRezervasyonlar[int.Parse(Console.ReadLine())-1];

            foreach(Rezervasyon r in this.Rezervasyonlar.ToList())
            {
                if((r.odaNo==silinecekOlan.odaNo) && (r.otel==silinecekOlan.otel))//İptal edilmesi istenilen rezervasyonu 
                    //ana rezervasyonlar listesinden bulup kaldıracak
                {
                    Rezervasyonlar.Remove(r);
                }
            }

            string yol = "Rezervasyonlar.txt";
            StreamWriter yaz1 = new StreamWriter(yol);


            

            foreach (Rezervasyon r in this.Rezervasyonlar.ToList())
            {
                yaz1.WriteLine(r.isim + " " + r.soyisim + " " + r.id + " " + r.sehir + " " + r.otel +
                    " " + r.odaNo + " " + r.islemSaati + " " + r.Baslangıc + " " + r.Cikis);

            }
            yaz1.Close();

            

            //Rezervasyonlar dosyasından son işlemi kaldırabiliyoruz ancak Odalar.txt de silinen rezervasyonla ilgisi olan odanın
            //son bilgileri o rezervasyona ait!!!!!

            //ÖNEMLİ:  Bir odanın birden çok btarihi ve ctarihi olabilir!!!!!!!!!!!!!!!!!!!!!!1
        }
    }






    class ControllerYonetici
    {
        private GorunumYonetici view { get; set; }
        public List<Otel> Oteller { get; set; }
        

        public ControllerYonetici(GorunumYonetici gy,List<Otel> Oteller)
        {
            this.view = gy;
            this.Oteller = Oteller;
        }


        public List<Otel> OtelEkle()
        {
            

            Console.WriteLine("Otel tipini giriniz");
            string oteltip = null;
            oteltip = Console.ReadLine();


            //  Factory Design Pattern
            if (oteltip == "Hotel")
            {
                var yeni = Factory.GetOtel(1);

                this.Oteller.Add(yeni);
            }
            else if (oteltip == "TatilKoyu")
            {
                var yeni = Factory.GetOtel(2);
                this.Oteller.Add(yeni);
            }
            else if (oteltip == "Pansiyon")
            {
                var yeni = Factory.GetOtel(3);
                this.Oteller.Add(yeni);
            }

            StreamWriter yaz = new StreamWriter("Oteller.txt");
            foreach (Otel x in this.Oteller)
            {
                yaz.WriteLine(x.Sehir + " " + x.OtelAdi + " " + x.YildizSayisi + " " + x.GetType().Name);
         
            }
            yaz.Close();

            Console.WriteLine("Oteliniz basariyla acildi");

            return this.Oteller;

        }


        public void OteleOdaEkle()
        {
            Tekrar10:
            Console.WriteLine(Environment.NewLine + "Hangi otele oda eklensin?");
            string otel = Console.ReadLine();
            bool control = false;
            foreach (Otel o in this.Oteller)
            {
                if (o.OtelAdi == otel)
                {
                    control = true;
                    Console.WriteLine("Oda tipini giriniz (Kral Dairesi, Lux Oda, Standart Oda)");
                    string odatip = null;
                    odatip = Console.ReadLine();
                    //bool klima,bool minibar,bool tv,bool denizmanzarasi,bool jakuzi,
                    //bool oyunkonsolu,double odano,double fiyat, DateTime btarihi, DateTime ctarihi

                    // if (BaslangicDosyaIslemleri.VeriTabanindakiOteller().Equals(otel))

                    if (odatip == "Kral Dairesi")
                    {
                        Console.WriteLine("Odada bulunmasını istediginiz özellikleri giriniz");
                        Console.WriteLine("Klima,Minibar,Tv,Denizmanzarasi,Jakuzi,Oyunkonsolu,OdaNo,Fiyat,Kisi Sayisi");

                        string klima = (Console.ReadLine());
                        string minibar = (Console.ReadLine());
                        string tv = (Console.ReadLine());
                        string denizmanzarasi = (Console.ReadLine()); ;
                        string jakuzi = (Console.ReadLine());
                        string oyunkonsolu = (Console.ReadLine());
                        double odano = double.Parse(Console.ReadLine());
                        double fiyat = double.Parse(Console.ReadLine());
                        DateTime btarihi = DateTime.Parse("10.10.1950");
                        DateTime ctarihi = DateTime.Parse("10.10.1950");
                        double kisisayisi = double.Parse(Console.ReadLine());
                        bool klimalar = false;
                        if (klima == "E" || klima == "e" || klima == "Evet" || klima == "evet")
                        {
                            klimalar = true;
                        }
                        else if (klima == "H" || klima == "h" || klima == "Hayır" || klima == "hayır")
                        {
                            klimalar = false;
                        }
                        bool minibarlar = false;
                        if (minibar == "E" || minibar == "e" || minibar == "Evet" || minibar == "evet")
                        {
                            minibarlar = true;
                        }
                        else if (minibar == "H" || minibar == "h" || minibar == "Hayır" || minibar == "hayır")
                        {
                            minibarlar = false;
                        }
                        bool tvler = false;
                        if (tv == "E" || tv == "e" || tv == "Evet" || tv == "evet")
                        {
                            tvler = true;
                        }
                        else if (tv == "H" || tv == "h" || tv == "Hayır" || tv == "hayır")
                        {
                            tvler = false;
                        }
                        bool denizmanzarasii = false;
                        if (denizmanzarasi == "E" || denizmanzarasi == "e" || denizmanzarasi == "Evet" || denizmanzarasi == "evet")
                        {
                            denizmanzarasii = true;
                        }
                        else if (denizmanzarasi == "H" || denizmanzarasi == "h" || denizmanzarasi == "Hayır" || denizmanzarasi == "hayır")
                        {
                            denizmanzarasii = false;
                        }
                        bool jakuziler = false;
                        if (jakuzi == "E" || jakuzi == "e" || jakuzi == "Evet" || jakuzi == "evet")
                        {
                            jakuziler = true;
                        }
                        else if (jakuzi == "H" || jakuzi == "h" || jakuzi == "Hayır" || jakuzi == "hayır")
                        {
                            jakuziler = false;
                        }
                        bool oyunkonsolları = false;
                        if (oyunkonsolu == "E" || oyunkonsolu == "e" || oyunkonsolu == "Evet" || oyunkonsolu == "evet")
                        {
                            oyunkonsolları = true;
                        }
                        else if (oyunkonsolu == "H" || oyunkonsolu == "h" || oyunkonsolu == "Hayır" || oyunkonsolu == "hayır")
                        {
                            oyunkonsolları = false;
                        }
                        o.Odalar.Add(new KralDairesi(o, klimalar, minibarlar, tvler, denizmanzarasii, jakuziler,
                            oyunkonsolları, odano, fiyat,kisisayisi));

                    }
                    if (odatip == "Lux Oda")
                    {
                        Console.WriteLine("Odada bulunmasını istediginiz özellikleri giriniz");
                        Console.WriteLine("Klima,Minibar,Tv,Denizmanzarasi,Jakuzi,Oyunkonsolu,OdaNo,Fiyat,Kisi Sayisi");
                        string klima = (Console.ReadLine());
                        string minibar = (Console.ReadLine());
                        string tv = (Console.ReadLine());
                        string denizmanzarasi = (Console.ReadLine()); ;
                        string jakuzi = (Console.ReadLine());
                        string oyunkonsolu = (Console.ReadLine());
                        double odano = double.Parse(Console.ReadLine());
                        double fiyat = double.Parse(Console.ReadLine());
                        DateTime btarihi = DateTime.Parse("10.10.1950");
                        DateTime ctarihi = DateTime.Parse("10.10.1950");
                        double kisisayisi = double.Parse(Console.ReadLine());
                        bool klimalar = false;
                        if (klima == "E" || klima == "e" || klima == "Evet" || klima == "evet")
                        {
                            klimalar = true;
                        }
                        else if (klima == "H" || klima == "h" || klima == "Hayır" || klima == "hayır")
                        {
                            klimalar = false;
                        }
                        bool minibarlar = false;
                        if (minibar == "E" || minibar == "e" || minibar == "Evet" || minibar == "evet")
                        {
                            minibarlar = true;
                        }
                        else if (minibar == "H" || minibar == "h" || minibar == "Hayır" || minibar == "hayır")
                        {
                            minibarlar = false;
                        }
                        bool tvler = false;
                        if (tv == "E" || tv == "e" || tv == "Evet" || tv == "evet")
                        {
                            tvler = true;
                        }
                        else if (tv == "H" || tv == "h" || tv == "Hayır" || tv == "hayır")
                        {
                            tvler = false;
                        }
                        bool denizmanzarasii = false;
                        if (denizmanzarasi == "E" || denizmanzarasi == "e" || denizmanzarasi == "Evet" || denizmanzarasi == "evet")
                        {
                            denizmanzarasii = true;
                        }
                        else if (denizmanzarasi == "H" || denizmanzarasi == "h" || denizmanzarasi == "Hayır" || denizmanzarasi == "hayır")
                        {
                            denizmanzarasii = false;
                        }
                        bool jakuziler = false;
                        if (jakuzi == "E" || jakuzi == "e" || jakuzi == "Evet" || jakuzi == "evet")
                        {
                            jakuziler = true;
                        }
                        else if (jakuzi == "H" || jakuzi == "h" || jakuzi == "Hayır" || jakuzi == "hayır")
                        {
                            jakuziler = false;
                        }
                        bool oyunkonsolları = false;
                        if (oyunkonsolu == "E" || oyunkonsolu == "e" || oyunkonsolu == "Evet" || oyunkonsolu == "evet")
                        {
                            oyunkonsolları = true;
                        }
                        else if (oyunkonsolu == "H" || oyunkonsolu == "h" || oyunkonsolu == "Hayır" || oyunkonsolu == "hayır")
                        {
                            oyunkonsolları = false;
                        }

                        o.Odalar.Add(new LuxOda(o, klimalar, minibarlar, tvler, denizmanzarasii,
                            jakuziler, oyunkonsolları, odano, fiyat,kisisayisi));

                    }

                    if (odatip == "Standart Oda")
                    {
                        Console.WriteLine("Odada bulunmasını istediginiz özellikleri giriniz");
                        Console.WriteLine("Klima,Minibar,Tv,Denizmanzarasi,Jakuzi,Oyunkonsolu,OdaNo,Fiyat,Kisi Sayisi");
                        string klima = (Console.ReadLine());
                        string minibar = (Console.ReadLine());
                        string tv = (Console.ReadLine());
                        string denizmanzarasi = (Console.ReadLine()); ;
                        string jakuzi = (Console.ReadLine());
                        string oyunkonsolu = (Console.ReadLine());
                        double odano = double.Parse(Console.ReadLine());
                        double fiyat = double.Parse(Console.ReadLine());
                        DateTime btarihi = DateTime.Parse("10.10.1950");
                        DateTime ctarihi = DateTime.Parse("10.10.1950");
                        double kisisayisi = double.Parse(Console.ReadLine());
                        bool klimalar = false;
                        if (klima == "E" || klima == "e" || klima == "Evet" || klima == "evet")
                        {
                            klimalar = true;
                        }
                        else if (klima == "H" || klima == "h" || klima == "Hayır" || klima == "hayır")
                        {
                            klimalar = false;
                        }
                        bool minibarlar = false;
                        if (minibar == "E" || minibar == "e" || minibar == "Evet" || minibar == "evet")
                        {
                            minibarlar = true;
                        }
                        else if (minibar == "H" || minibar == "h" || minibar == "Hayır" || minibar == "hayır")
                        {
                            minibarlar = false;
                        }
                        bool tvler = false;
                        if (tv == "E" || tv == "e" || tv == "Evet" || tv == "evet")
                        {
                            tvler = true;
                        }
                        else if (tv == "H" || tv == "h" || tv == "Hayır" || tv == "hayır")
                        {
                            tvler = false;
                        }
                        bool denizmanzarasii = false;
                        if (denizmanzarasi == "E" || denizmanzarasi == "e" || denizmanzarasi == "Evet" || denizmanzarasi == "evet")
                        {
                            denizmanzarasii = true;
                        }
                        else if (denizmanzarasi == "H" || denizmanzarasi == "h" || denizmanzarasi == "Hayır" || denizmanzarasi == "hayır")
                        {
                            denizmanzarasii = false;
                        }
                        bool jakuziler = false;
                        if (jakuzi == "E" || jakuzi == "e" || jakuzi == "Evet" || jakuzi == "evet")
                        {
                            jakuziler = true;
                        }
                        else if (jakuzi == "H" || jakuzi == "h" || jakuzi == "Hayır" || jakuzi == "hayır")
                        {
                            jakuziler = false;
                        }
                        bool oyunkonsolları = false;
                        if (oyunkonsolu == "E" || oyunkonsolu == "e" || oyunkonsolu == "Evet" || oyunkonsolu == "evet")
                        {
                            oyunkonsolları = true;
                        }
                        else if (oyunkonsolu == "H" || oyunkonsolu == "h" || oyunkonsolu == "Hayır" || oyunkonsolu == "hayır")
                        {
                            oyunkonsolları = false;
                        }

                        o.Odalar.Add(new StandartOda(o, klimalar, minibarlar, tvler, denizmanzarasii, 
                            jakuziler, oyunkonsolları, odano, fiyat,kisisayisi));

                    }

                    Console.WriteLine("Otelinize odanız basariyla eklendi");
                }
           
                
                
            }
            if (control == false)
            {
                  Console.WriteLine("Islem yapmak istediginiz otel bulunamadi! Lütfen tekrar giriniz:");
                   goto Tekrar10;
            }
            //bool klima,bool minibar,bool tv,bool denizmanzarasi,bool jakuzi,
            //bool oyunkonsolu,double odano,double fiyat, DateTime btarihi, DateTime ctarihi



            //try catch!!!!!!!!!
            StreamWriter yaz = new StreamWriter("Odalar.txt");

            foreach (Otel o in this.Oteller)
            {
                foreach (Oda x in o.Odalar)
                {

                    //wTinaztepew KD True True True True False True 540 2400 10.10.1950 10.10.1950
                    yaz.WriteLine(o.OtelAdi + " " + x.GetType().Name + " " + x.klima + " " + x.miniBar + " " + x.TV + " " + x.denizManzarası + " " + x.jakuzi + " " + x.oyunKonsolu + " "
                        + x.OdaNo + " " + x.Fiyat +" "+x.Kisisayisi);

                }
                
            }
            yaz.Close();


        }
        public void GenelDurum(List<Rezervasyon> Rezervasyonlar)
        {
            this.view.GenelDurum(this.Oteller,Rezervasyonlar);
        }

        
    }

    
}
