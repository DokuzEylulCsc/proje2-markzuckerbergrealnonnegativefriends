using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    static class Factory
    {
        //Kullanicinin talep ettiği otel tipini donucek
        public static Otel GetOtel(int tip)
        {
            switch (tip)
            {
                case 1://Hotel


                    Console.WriteLine(Environment.NewLine + "Otel Adi:");
                    string otelAdi = Console.ReadLine();

                    Console.WriteLine(Environment.NewLine + "Otelin bulundugu sehir:");
                    string otelSehri = Console.ReadLine();

                    Console.WriteLine(Environment.NewLine + "Yildiz Sayisi:");
                    double yildizSayisi = double.Parse(Console.ReadLine());

                    return new Hotel(otelAdi, otelSehri, yildizSayisi);


                    break;

                case 2://TatilKoyu


                    Console.WriteLine(Environment.NewLine + "Otel Adi:");
                    string OtelAdi = Console.ReadLine();

                    Console.WriteLine(Environment.NewLine + "Otelin bulundugu sehir:");
                    string OtelSehri = Console.ReadLine();

                    

                    return new TatilKoyu(OtelAdi, OtelSehri);


                    break;

                case 3://Pansiyon


                    Console.WriteLine(Environment.NewLine + "Otel Adi:");
                    string oteladi = Console.ReadLine();

                    Console.WriteLine(Environment.NewLine + "Otelin bulundugu sehir:");
                    string otelsehri = Console.ReadLine();

                    

                    return new Pansiyon(oteladi, otelsehri);


                    break;


                default:
                    return null;
            }
        }
    }
}
