using System;
using System.Collections.Generic;
using System.Text;

namespace ТпЛр2.Models
{
    public interface Ware
    {
        string category { get; set; }
        string name { get; set; }
        int price { get; set; }
        int healthiness { get; set; }
    }
}
