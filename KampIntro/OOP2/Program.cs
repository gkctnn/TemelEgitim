using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            GercekMusteri musteri1 = new GercekMusteri
            {
                Id = 1,
                Adi = "Engin",
                Soyadi = "Demiroğ",
                TcNo = "22222222222",
                MusteriNo = "12345"
            };

            TuzelMusteri musteri2 = new TuzelMusteri
            {
                Id = 2,
                MusteriNo = "67890",
                SirketAdi = "Kodlama.io",
                VergiNo = "2222222222"
            };

            Musteri musteri3 = new GercekMusteri
            {
                Id = 3,
                Adi = "Gökçenur",
                Soyadi = "Zenginal",
                TcNo = "33333333333",
                MusteriNo = "23456"
            };

            Musteri musteri4 = new TuzelMusteri
            {
                Id = 4,
                MusteriNo = "78901",
                SirketAdi = "gkcnz",
                VergiNo = "3333333333"
            };

            MusteriManager musteriManager = new MusteriManager();
            musteriManager.Ekle(musteri1);
            musteriManager.Ekle(musteri2);
            musteriManager.Ekle(musteri3);
            musteriManager.Ekle(musteri4);
        }
    }
}
