using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Debug.WriteLine("Dosyaya loglandı");
        }
    }
}
