using System;

namespace Contact_List_Exercise.Models
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(string firstname, string lastname, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public Contact(int id, string firstname, string lastname, string email)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}