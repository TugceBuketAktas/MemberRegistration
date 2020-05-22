using System.ComponentModel.DataAnnotations;

namespace MemberRegistration.Models
{
    public class UserRegistrationModel
    {
        public string UserFullname { get; set; }
        public string UserUsername { get; set; }
        public string UserEmail { get; set; }
        public string UserPasswd { get; set; }
        public string UserJob { get; set; }
        public string UserPhone { get; set; }
        public string UserCity { get; set; }
        public string UserNeighborhood { get; set; }

    }
}
