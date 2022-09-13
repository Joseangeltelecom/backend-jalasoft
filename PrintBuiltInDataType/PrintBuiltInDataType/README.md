## Instructions:

a) Create a new solution and project in C# (console application).
b) The application must read a string (that represents to the name of a built-in type) from command line and according to that you should print its details.
Inputs: bool, byte, char, float, double, decimal, int, long, short, string
	Example of input:
	-----------------
		If you enter the string "int", you should print all the information of a Int32 built-in type as is explained in step c.

c) Implement the code for printing the following information for each built-in type you found in your research.

	Example of output 1 ("int"):
	--------------------
		Type name = System.Int32
		Min value = -2147483648
		Max value = 2147483647
		Is value data type
		Size = Uses 4 bytes to store a value|

	Example of output 2 ("string"):
	--------------------
		Type name = System.String
		Is reference data type

Note: All the information should be retrieved and printed programatically (not hardcoding the outputs)

The following C# classes, methods and operators might help you for achieving your purpose:
------------------------------------------------------------------------------------------
Console.ReadLine
Console.WriteLine
typeof
sizeof

The following information is NOT needed to be printed for reference types:
	Min Value
	Max Value
	Size