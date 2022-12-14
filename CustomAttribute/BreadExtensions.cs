using System.Reflection;

namespace CustomAttribute
{
    public static class BreadExtensions
    {
        public static void Write(this Bread bread)
        {
            var breadProperties = bread.GetType().GetProperties();
            foreach (var property in breadProperties)
            {
                string propertyLabel = GetPropertyAttribute(bread, property.Name);
                Console.WriteLine(propertyLabel + property.GetValue(bread));
            }
        }

        private static string GetPropertyAttribute(Bread bread, string propertyName)
        {
                PropertyInfo nameProperty = bread.GetType().GetProperty(propertyName);
                TabAttribute[] myAttributes = (TabAttribute[])Attribute.GetCustomAttributes(nameProperty, typeof(TabAttribute));

                     string tabs = "";
                    foreach (var attribute in  myAttributes)
                    {
                        if (attribute != null)
                        {
                            tabs += attribute.Tab;
                        }
                    }
                    return tabs;
        }
    }
}