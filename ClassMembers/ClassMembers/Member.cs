using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace ClassMembers
{
    internal struct Member
    {
        public string _name;
        public string _lastname;
        public string _email;
        public Role _role;
        public Guid _id;
        public Member(string name, string lastname, string email,Role role) {

                _name = name;
                _lastname = lastname;
                _email = email;
                _role = role;
                _id = IdGenerator();
        } // Member constructor
        static public Guid IdGenerator()
        {
            return Guid.NewGuid();
        } // Generate a random and unic ID.
        public void GetMemberData()
        {
            var print = new StringBuilder();
            print.AppendLine($"\nThe {_role.ToString().ToUpper()} data is: ");
            print.AppendLine($"\nName = {_name + _lastname}");
            print.AppendLine($"Email = {_email}");
            print.AppendLine($"Rol = {_role}");
            print.AppendLine($"ID = {_id}");

            Console.WriteLine(print.ToString());
        } // Show a Member data.
    }
}
