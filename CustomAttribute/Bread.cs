namespace CustomAttribute
{
    public class Bread
    {
            protected string _name;
            protected int _price;
            protected string _description = "Description";

        [Tab]
        public string Name { get { return _name; } }

        [Tab]
        [Tab]
        [Tab]
        [Tab]
        public int Price
            {
                get { return _price; }
                set
                {
                    if (value > 0) _price = value;
                }
            }

        [Tab]
        public string Description { get { return _description; } }

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

        protected Bread(BreadType name, int price)
            {
                _price = price;
                _name = name.ToString();
            }

            internal Bread(BreadType name, int price, int taxes)
            {
                _price = price * taxes;
                _name = name.ToString();
            }

            [Obsolete("Use Print(int quantity). This will be removed on version 1.2")]
            public virtual void Print()
            {
                Console.WriteLine($"TITLE: {this._name}");
            }

            public void Print(int quantity)
            {
                Console.WriteLine($"{quantity} {this._name}s has a value of {this._price * quantity}$");
                String.Format("{0} {1}s has a value of {2}$", quantity, this._name, this._price * quantity);
            }

            public static string[] GetBreadTypes()
            {
                string[] types = { BreadType.Baguette.ToString(), BreadType.Hamburger.ToString() };
                return types;
            }
        }

        public enum BreadType
        {
            Baguette,
            Hamburger,
            White
        }
}
