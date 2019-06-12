using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proje22019
{
    //RunTime da zorunlu olarak gelmesi gereken verileri çekicek 
    //Amac: Main metodunda gereksiz yer kaplamamak
    class BaslangicDosyaIslemleri
    {
        public static List<Musteri> VeriTabanindakiMusteriler()
        {
            List<Musteri> Musteriler = new List<Musteri>();
            try
            {

                

                string[] gelen;
                string line;
                FileStream akis;
                StreamReader Okuma;
                string Yol = "Tummusteriler.txt";
                akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
                Okuma = new StreamReader(akis);
                line = Okuma.ReadLine();

                while (line != null)
                {
                    gelen = Regex.Split(line, @"\s+");
                    Musteri yeni = new Musteri(gelen[0], gelen[1], gelen[2], gelen[3]);
                    Musteriler.Add(yeni);
                    yeni = null;

                    line = Okuma.ReadLine();
                }
                akis.Close();

                

            }

             catch (System.IO.FileLoadException)
            {
                Console.WriteLine("VeriTabanindakiMusteriler: Musterilerin bulundugu dosya yuklenemedi");
                LogKayıt.LogKaydedici("VeriTabanindakiMusteriler: Musterilerin bulundugu dosya yuklenemedi");
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("VeriTabanindakiMusteriler: Musterilerin bulundugu dosya bulunamadi");
                LogKayıt.LogKaydedici("VeriTabanindakiMusteriler: Musterilerin bulundugu dosya bulunamadi");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("VeriTabanindakiMusteriler: metodda belirlenemyen bir IOException i olustu!!!");
                LogKayıt.LogKaydedici("VeriTabanindakiMusteriler: metodda belirlenemyen bir IOException i olustu!!!");
            }
            catch (Exception)
            {
                Console.WriteLine("VeriTabanindakiMusteriler: Unknown Exception");
                LogKayıt.LogKaydedici("VeriTabanindakiMusteriler: Unknown Exception");


            }
            return Musteriler;


        }

        public static List<Otel> VeriTabanindakiOteller()
        {
            List<Otel> Oteller = new List<Otel>();
            try
            {
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
                Gelen = null;
                Akis.Close();
            }
        
             catch (System.IO.FileLoadException)
            {
                Console.WriteLine("VeriTabanindakiOteller: Otellerin bulundugu dosya yuklenemedi");
                LogKayıt.LogKaydedici("VeriTabanindakiOteller: Otellerin bulundugu dosya yuklenemedi");
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("VeriTabanindakiOteller: Otellerin bulundugu dosya bulunamadi");
                LogKayıt.LogKaydedici("VeriTabanindakiOteller: Otellerin bulundugu dosya bulunamadi");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("VeriTabanindakiOteller: metodda belirlenemyen bir IOException i olustu!!!");
                LogKayıt.LogKaydedici("VeriTabanindakiOteller: metodda belirlenemyen bir IOException i olustu!!!");
            }
            catch (Exception)
            {
                Console.WriteLine("VeriTabanindakiOteller: Unknown Exception");
                LogKayıt.LogKaydedici("VeriTabanindakiOteller: Unknown Exception");


            }

            return Oteller;
        }

        public static void VeriTabanindakiOdalar(List<Otel> Oteller)
        {
            try
            {
                string[] Gelen;
                string Line;
                FileStream Akis;
                StreamReader okuma;
                string yol = "Odalar.txt";
                Akis = new FileStream(yol, FileMode.Open, FileAccess.Read);
                okuma = new StreamReader(Akis);
                Line = okuma.ReadLine();

                while (Line != null)
                {
                    Gelen = Regex.Split(Line, @"\s+");

                    foreach (Otel o in Oteller)
                    {
                        if (o.OtelAdi == Gelen[0])
                        {
                            if (Gelen[1] == "KralDairesi")
                            {
                                o.Odalar.Add(new KralDairesi(o, bool.Parse(Gelen[2]), bool.Parse(Gelen[3]),
                                    bool.Parse(Gelen[4]), bool.Parse(Gelen[5]),
                                    bool.Parse(Gelen[6]),
                                    bool.Parse(Gelen[7]),
                                    double.Parse(Gelen[8]),
                                    double.Parse(Gelen[9]), double.Parse(Gelen[10])));
                                
                            }
                            if (Gelen[1] == "LuxOda")
                            {
                                o.Odalar.Add(new LuxOda(o, bool.Parse(Gelen[2]), bool.Parse(Gelen[3]),
                                    bool.Parse(Gelen[4]), bool.Parse(Gelen[5]),
                                    bool.Parse(Gelen[6]),
                                    bool.Parse(Gelen[7]),
                                    double.Parse(Gelen[8]),
                                    double.Parse(Gelen[9]), double.Parse(Gelen[10])));
                            }
                            if (Gelen[1] == "StandartOda")
                            {
                                o.Odalar.Add(new StandartOda(o, bool.Parse(Gelen[2]), bool.Parse(Gelen[3]),
                                    bool.Parse(Gelen[4]), bool.Parse(Gelen[5]),
                                    bool.Parse(Gelen[6]),
                                    bool.Parse(Gelen[7]),
                                    double.Parse(Gelen[8]),
                                    double.Parse(Gelen[9]), double.Parse(Gelen[10])));
                            }
                        }

                    }




                    Line = okuma.ReadLine();
                }
                Gelen = null;
                Akis.Close();
            }

            //Hatalar catch edilince Log kaydı yapılacak
            catch (System.IO.FileLoadException)
            {
                Console.WriteLine("VeriTabanindakiOdalar: odalarin bulundugu dosya yuklenemedi");
                LogKayıt.LogKaydedici("VeriTabanindakiOdalar: odalarin bulundugu dosya yuklenemedi");
            }
            catch (FileNotFoundException)
            {
                
                Console.WriteLine("VeriTabanindakiOdalar: odalarin bulundugu dosya bulunamadi");
                LogKayıt.LogKaydedici("VeriTabanindakiOdalar: odalarin bulundugu dosya bulunamadi");
            }
            catch(System.IO.IOException)
            {
                Console.WriteLine("VeriTabanindakiOdalar: metodda belirlenemyen bir IOException i olustu!!!");
                LogKayıt.LogKaydedici("VeriTabanindakiOdalar: metodda belirlenemyen bir IOException i olustu!!!");
            }
            catch(Exception)
            {
                Console.WriteLine("VeriTabanindakiOdalar: Unknown Exception");
                LogKayıt.LogKaydedici("VeriTabanindakiOdalar: Unknown Exception");
                

            }

            
            
            

        }

        public static List<Rezervasyon> VeriTabanindakiRezervasyonlar()
        {
            List<Rezervasyon> Rezervasyonlar = new List<Rezervasyon>();
            try
            {
                string[] Gelen;
                string Line;
                FileStream Akis;
                StreamReader okuma;
                string yol = "Rezervasyonlar.txt";
                Akis = new FileStream(yol, FileMode.Open, FileAccess.Read);
                okuma = new StreamReader(Akis);
                Line = okuma.ReadLine();




                while (Line != null)
                {

                    Gelen = Regex.Split(Line, @"\s+");

                    Rezervasyonlar.Add(new Rezervasyon(DateTime.Parse(Gelen[8]), DateTime.Parse(Gelen[10]),
                        DateTime.Parse(Gelen[6]), Gelen[4], Gelen[5], Gelen[3], Gelen[0],
                        Gelen[1], Gelen[2]));


                    Line = okuma.ReadLine();

                }


                Akis.Close();
            }

            catch (System.IO.FileLoadException)
            {
                Console.WriteLine("VeriTabanindakiRezervasyonlar: Rezervasyonların bulundugu dosya yuklenemedi");
                LogKayıt.LogKaydedici("VeriTabanindakiRezervasyonlar: Rezervasyonların bulundugu dosya yuklenemedi");
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("VeriTabanindakiRezervasyonlar: Rezervasyonların bulundugu dosya bulunamadi");
                LogKayıt.LogKaydedici("VeriTabanindakiRezervasyonlar: Rezervasyonların bulundugu dosya bulunamadi");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("VeriTabanindakiRezervasyonlar: metodda belirlenemyen bir IOException i olustu!!!");
                LogKayıt.LogKaydedici("VeriTabanindakiRezervasyonlar: metodda belirlenemyen bir IOException i olustu!!!");
            }
            catch (Exception)
            {
                Console.WriteLine("VeriTabanindakiRezervasyonlar: Unknown Exception");
                LogKayıt.LogKaydedici("VeriTabanindakiRezervasyonlar: Unknown Exception");


            }
            return Rezervasyonlar;
        }
    }
}
