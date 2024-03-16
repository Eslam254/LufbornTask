﻿using System;
using NetDevPack.Domain;

namespace Store.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        protected Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}