using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    class Musteri
    {
        public int Id { get; set; }
        private string _musteriNo;
        public string MusteriNo
        {
            get
            {
                return "M" + _musteriNo;
            }
            set
            {
                _musteriNo = value;
            }
        }
    }
}
