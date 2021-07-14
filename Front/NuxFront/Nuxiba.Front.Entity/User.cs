﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nuxiba.Front.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
