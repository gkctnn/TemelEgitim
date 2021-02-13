using System;
using System.Collections.Generic;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            //IhtiyacKrediManager ihtiyacKrediManager = new IhtiyacKrediManager();
            //ihtiyacKrediManager.Hesapla();

            //TasitKrediManager tasitKrediManager = new TasitKrediManager();
            //tasitKrediManager.Hesapla();

            //KonutKrediManager konutKrediManager = new KonutKrediManager();
            //konutKrediManager.Hesapla();

            //IKrediManager ihtiyacKrediManager2 = new IhtiyacKrediManager();
            //ihtiyacKrediManager2.Hesapla();

            //IKrediManager tasitKrediManager2 = new TasitKrediManager();
            //tasitKrediManager2.Hesapla();

            //IKrediManager konutKrediManager2 = new KonutKrediManager();
            //konutKrediManager2.Hesapla();

            IKrediManager ihtiyacKrediManager2 = new IhtiyacKrediManager();
            IKrediManager tasitKrediManager2 = new TasitKrediManager();
            IKrediManager konutKrediManager2 = new KonutKrediManager();
            IKrediManager esnafKrediManager2 = new EsnafKrediManager();

            ILoggerService databaseLoggerService = new DatabaseLoggerService();
            ILoggerService fileLoggerService = new FileLoggerService();

            List<IKrediManager> krediManagers = new List<IKrediManager>()
            {
                ihtiyacKrediManager2,
                tasitKrediManager2,
                konutKrediManager2
            };

            List<ILoggerService> loggerServices = new List<ILoggerService>()
            {
                databaseLoggerService,
                fileLoggerService
            };

            BasvuruManager basvuruManager = new BasvuruManager();
            basvuruManager.BasvuruYap(esnafKrediManager2, loggerServices);

            
            basvuruManager.KrediOnBilgilendirmesiYap(krediManagers);
        }
    }
}
