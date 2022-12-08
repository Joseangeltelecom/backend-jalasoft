using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    internal class Bread
    {
        public string _name;
        public int _price;
        public Bread(string name, int price)
        {
            _name = name;
            _price = price;
        }

        private Bread(string name)
        {
            _price = 3;
            _name = name;
        }

        public Bread()
        {
        }
    }
}
