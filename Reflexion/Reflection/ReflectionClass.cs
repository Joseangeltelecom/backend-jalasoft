using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

namespace Reflection
{
    internal class ReflectionClass
    {
        private static string _breadTypeFromConfig = "Reflection.Bread";
        internal static void First()
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); // El asembly que se esta ejecutando actualmente
            Module[] modules = assembly.GetModules();
            List<Type> types = modules[0].GetTypes().ToList();

            foreach (Module module in modules)
            {
                Console.WriteLine("Module " + module); 
                foreach (Type type in module.GetTypes())
                { 
                    types.Add(type);
                    Console.WriteLine("Type " + type);
                }
            }

            Type breadType = assembly.GetType("Reflection.Bread");
            ConstructorInfo[] breadConstructors = breadType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (ConstructorInfo constructor in breadConstructors)
            {
                Console.WriteLine(constructor + "Public: " + constructor.IsPublic);
            }

            //object baguette1 = breadConstructors[0].Invoke(null);
            object baguette2 = breadConstructors[1].Invoke(new object[] { 4});
            object baguette3 = breadConstructors[2].Invoke(new object[] { 4, 7 });

            //object baguette4 = Activator.CreateInstance(breadType); // Crear un tipo form 1
            object baguette4 = Activator.CreateInstance("Reflection", _breadTypeFromConfig).Unwrap(); // Crear un tipo form 2
            //Bread bread4 = Activator.CreateInstance("Reflection", _breadTypeFromConfig, true, BindingFlags.Instance | BindingFlags.Public, new object[] { 8}, null, null).Unwrap() as Bread; // Crear un tipo form 2
            Bread bread5 = Activator.CreateInstance(breadType, new object[] { 8}) as Bread;
            Bread bread6 = Activator.CreateInstance(breadType, BindingFlags.Instance | BindingFlags.Public, null, new object[] { 10}, null) as Bread;
            var priceProperty = bread6.GetType().GetProperty("Price");
            priceProperty.SetValue(bread6, 1);

        }
    }
}
