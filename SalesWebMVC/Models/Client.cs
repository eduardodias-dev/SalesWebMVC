using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Client
    {
        public Client() { }
        public Client(int id, string name, string email, DateTime birthDate, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

    }
}
