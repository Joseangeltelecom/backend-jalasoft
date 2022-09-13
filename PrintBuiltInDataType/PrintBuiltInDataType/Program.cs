using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrintBuiltInDataType
{
    internal class Program

    {
        // bool, byte, char, float, double, decimal, int, long, short, string
        static void Main(string[] args)
        {
            string typeName, minValue, maxValue, size, valueType;
            var listOfTypes = new List<string> {"bool", "byte", "char", "loat", "double", "decimal", "int", "long","short", "string"};
            
            Console.WriteLine("Please Input any of following DataType to get more information:\n" +
                " bool\n byte\n char\n float\n double\n decimal\n int\n long\n short\n string\n");
           
            string myDataType = Console.ReadLine();
            bool exist = listOfTypes.Contains(myDataType);
            bool run = exist;

            while (exist == false) {
                Console.WriteLine("Please Input a valid DataType to get more information or press Ctrl + C to exit");
                myDataType = Console.ReadLine();
                exist = listOfTypes.Contains(myDataType);
                run = exist;
            }
         
                while (run)
                {
                    if (myDataType == "bool")
                    {
                        typeName = typeof(bool).ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(bool).ToString();

                        Helper.GetLoggerValueType(typeName, "N/A", "N/A", size, valueType);

                    }
                    else if (myDataType == "byte")
                    {
                        typeName = typeof(byte).ToString();
                        minValue = byte.MinValue.ToString();
                        maxValue = byte.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(byte).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);
                    }
                    else if (myDataType == "char")
                    {
                        typeName = typeof(char).ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(char).ToString();

                        Helper.GetLoggerValueType(typeName, "N/A", "N/A", size, valueType);
                    }
                    else if (myDataType == "float")
                    {
                        typeName = typeof(float).ToString();
                        minValue = float.MinValue.ToString();
                        maxValue = float.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(float).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);
                    }
                    else if (myDataType == "double")
                    {
                        typeName = typeof(double).ToString();
                        minValue = double.MinValue.ToString();
                        maxValue = double.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(double).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);
                    }
                    else if (myDataType == "decimal")
                    {
                        typeName = typeof(decimal).ToString();
                        minValue = decimal.MinValue.ToString();
                        maxValue = decimal.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(decimal).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);
                    }
                    else if (myDataType == "int")
                    {
                        typeName = typeof(int).ToString();
                        minValue = int.MinValue.ToString();
                        maxValue = int.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(int).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);

                    }
                    else if (myDataType == "long")
                    {
                        typeName = typeof(long).ToString();
                        minValue = long.MinValue.ToString();
                        maxValue = long.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(long).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);

                    }
                    else if (myDataType == "short")
                    {
                        typeName = typeof(short).ToString();
                        minValue = short.MinValue.ToString();
                        maxValue = short.MaxValue.ToString();
                        valueType = Helper.valueType(myDataType);
                        size = sizeof(short).ToString();

                        Helper.GetLoggerValueType(typeName, minValue, maxValue, size, valueType);

                    }
                    else if (myDataType == "string")
                    {
                        typeName = typeof(string).ToString();
                        valueType = Helper.valueType(myDataType);

                        Helper.GetLoggerReferenceType(typeName, valueType);
                    }
                    Console.WriteLine("Please Input another/valid a DataType to get more information or press Ctrl + C to exit");
                    myDataType = Console.ReadLine();

                }
            }

    }
}

