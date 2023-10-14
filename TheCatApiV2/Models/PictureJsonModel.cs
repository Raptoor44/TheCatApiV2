using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PictureJsonModel
    {
        public class Breed
        {
            public string? id { get; set; }
        }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public List<Breed> breeds { get; set; }
    }
}
