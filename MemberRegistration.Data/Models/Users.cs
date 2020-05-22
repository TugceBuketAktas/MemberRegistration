using System;
using System.Collections.Generic;

namespace MemberRegistration.Data.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserFullname { get; set; }
        public string UserJob { get; set; }
        public string UserEmail { get; set; }
        public string UserUsername { get; set; }
        public string UserPasswd { get; set; }
        public bool UserPermission { get; set; }
        public string UserCity { get; set; }
        public string UserNeighborhood { get; set; }
        public string UserPhone { get; set; }
        public DateTime? UserRegistration { get; set; }
        public decimal? UserSalary { get; set; }
        public string UserUrl { get; set; }
    }
}
