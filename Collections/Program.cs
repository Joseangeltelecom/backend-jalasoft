using Collections;

namespace Backend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // first case:
            string value = "Today I will finish my homework on time";
            StackCollection.ReverseString(value);
            Console.WriteLine("");
            // second case:
            SortedListCollection.PrintSortedList();
        }
    }
}








