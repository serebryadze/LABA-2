using System;
using System.Collections.Generic;
using System.Text;

namespace ТпЛр2.Models
{
    public class Items : Ware
    {
        string _category, _name;
        int _price, _healthiness;
        public string Category; 
        public string Name; 
        public int Price;
        public int Healthiness;
        public Items ()
        {
            _category = Category;
            _name = Name;
            _price = Price;
            _healthiness = Healthiness;
        }
        public string category { get => _category; set => _category = value; }
        public string name { get => _name; set => _name = value; }
        public int price { get => _price; set => _price = value; }
        public int healthiness { get => _healthiness; set => _healthiness = value; }
    }
}
