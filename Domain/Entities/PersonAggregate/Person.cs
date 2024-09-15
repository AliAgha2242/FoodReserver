using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.AddressAggreagte;
using Domain.Entities.Base;
using Domain.Entities.ReserveAggregate;

namespace Domain.Entities.PersonAggregate
{
    public class Person : AggregateRoot
    {
        public string PersonName { get; private set; }
        public string HashPassword { get; private set; }
        public string PasswordSalt { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Reserve> Reserves { get; private set; }
        public ICollection<Address> Addresses { get; private set; }


        // Ef Core Ctor
        public Person() { }

        private Person(string personName, string hashPassword, string fullName, string email,
            string phoneNumber,string passwordSalt)
        {
            PersonName = personName;
            HashPassword = hashPassword;
            PasswordSalt = passwordSalt;
            FullName = fullName;
            Email = email;
            IsActive = true;
            CreationDate = DateTime.Now;
            PhoneNumber = phoneNumber;
        }

        public static Person Create(string personName, string hashPassword, string fullName, string email,
            string phoneNumber,string passwordSalt)
        {
            return new Person(personName,hashPassword,fullName,email,phoneNumber,passwordSalt);
        }



        public void RemovePerson()
        {
            this.IsActive = false;
        }

        public void RestorePerson()
        {
            this.IsActive = true;
        }
        public void ResetPassword(string hashPassword)
        {
            HashPassword = hashPassword;
        }

        public void EditPerson(string personName, string hashPassword, string fullName, string email,string phoneNumber)
        {
            PersonName = personName;
            HashPassword = hashPassword;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
}
