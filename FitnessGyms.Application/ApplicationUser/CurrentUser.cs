﻿using System.Data;

namespace FitnessGyms.Application.FitnessGym
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
