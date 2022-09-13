## Class Members

-Create a program that manage the members of a class.
-The course have a name and the following members: manager, trainer and students.
-Each member will have name, last name, email, role, id (the id must be random and unique, not set by console)
-The course must be created with the name, trainer and manager(there can only be one manager).
-After creating the course, you can't modify the name, trainer nor manager value, just get their values.
-The students will be added after the course was created.
-When you prints the manager/trainer value, it prints all his data.
Example of output 1 (manager):
	--------------------
		Name = Orlando Campos
		Email = orlando.campos@fundacion-jala.org
		Rol = Manager
		ID = 0f8fad5b-d9cb-469f-a165-70867728950e
		
-You can print the list of the students by full name.

	Example of output 2 (students):
	--------------------
		Course = Backend
		Student 1 = Pepito Perez
		Student 2 = Menganita Juarez
		
HINT:
-You should have two structs (Member, Course)
-List might help you in the process
-All the course creation/print data should be done by console.