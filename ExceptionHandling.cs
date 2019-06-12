using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Proje22019
{
    static class LogKayıt
    {
        //Exception lar detayları ile birlikte Hatalar.txt ye yazılacak
        public static void LogKaydedici(string message)
        {
            string path ="Hatalar.txt";
            

            

            File.AppendAllText(path, message+"    Tarih:"+DateTime.Now + Environment.NewLine);
            
        }
    }

    //Tarih ile ilgili oluşabilecek hatalar
    class DateInputProblem:ApplicationException
    {
        public DateInputProblem(string message)
        {
            Console.WriteLine(message);
 
        }

    }
}
