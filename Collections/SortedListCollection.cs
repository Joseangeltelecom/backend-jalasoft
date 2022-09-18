using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
   public static class SortedListCollection
   {
       public static void PrintSortedList()
       {
           SortedList<int, string> students = new SortedList<int, string>(new ReverseComparer());
           students.Add(30, "Juanito");
           students.Add(92, "Mengita");
           students.Add(50, "Pepito");

           foreach (KeyValuePair<int, string> student in students)
           {
               Console.WriteLine($"{student.Key} {student.Value}");
           }
       }
   }




}


