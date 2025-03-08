using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRadio.Logic
{
    public class RadioStation
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string IconPath { get; set; }
        public RadioStation(string name, string url, string iconPath)
        {
            this.Name = name;
            this.URL = url;
            this.IconPath = iconPath;
        }
    }
}
