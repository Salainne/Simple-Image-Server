using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    internal class Imagelist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ImageElement> Images { get; set; }
    }
}
