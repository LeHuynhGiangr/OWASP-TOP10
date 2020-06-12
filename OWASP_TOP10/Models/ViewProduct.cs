using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWASP_TOP10.Models
{
    public class ViewProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
    }
}
