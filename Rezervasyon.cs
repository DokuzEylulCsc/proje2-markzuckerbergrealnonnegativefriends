using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje22019
{
    class Rezervasyon
    {
        public DateTime islemSaati { get; set; }
        public DateTime Baslangıc { get; set; }
        public DateTime Cikis { get; set; }
        public string otel { get; set; }
        public string odaNo { get; set; }
        public string sehir { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string id { get; set; }


        public Rezervasyon(DateTime b,DateTime c,DateTime iS,string otel,string odaNo,string sehir,string isim,string soyisim,string id)
        {
            //Rezervasyon yapılandırıcısı.
            this.Baslangıc = b;
            this.Cikis = c;
            this.islemSaati = iS;
            this.otel = otel;
            this.odaNo = odaNo;
            this.sehir = sehir;
            this.isim = isim;
            this.soyisim = soyisim;
            this.id = id;
        }
    }
}
