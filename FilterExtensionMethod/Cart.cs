namespace FilterExtensionMethod
{
    public class Cart
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Cart(string name, string color, int year)
        {
            Name = name;
            Color = color;
            Year = year;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
