using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlanAssistant
{
    public class FileDownloader
    {
        public string Address { get; set; }
        public string Path { get; set; }

        public void DownloadFile()
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(Address, Path);
            }
        }
    }
}
