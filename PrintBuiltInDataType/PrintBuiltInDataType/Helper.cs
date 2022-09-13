using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrintBuiltInDataType
{
    public class Helper
    {
        public  static void GetLoggerValueType(string typeName ="", string minValue="", string maxValue = "",string size = "", string valueType = "")
        {
            var report = new StringBuilder();
            report.AppendLine($"Type name = {typeName}.\n" +
                              $"Min value = {minValue}.\n" +
                              $"Max value = {maxValue}.\n" +
                              $"{valueType}.\n" +
                              $"Size = {$"Uses {size} bytes to store a value."}\n");
           Console.WriteLine(report.ToString());
        }
        public static void GetLoggerReferenceType(string typeName, string valueType)
        {
            var report = new StringBuilder();
            report.AppendLine($"Type name = {typeName}\n" +
                              $"{valueType}\n" 
                );  
            
            Console.WriteLine(report.ToString());
        }

        public static string valueType(string type)
        {
            switch (type)
            {
                case "int":
                case "bool":
                case "byte":
                case "char":
                case "float":
                case "double":
                case "decimal":
                case "long":
                case "short":
                    type = "Is value data type";
                    break;
                case "string":
                    type = "Is reference data type";
                    break;
            }
            return type;
        }
    }
}
