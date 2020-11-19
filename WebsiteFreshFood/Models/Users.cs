namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Active { get; set; }

        public Users() { }

        public Users(int userID, string userName, string passWord, string email, string sdt, string role, string active)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Password = passWord;
            this.Email = email;
            this.SDT = sdt;
            this.Role = role;
            this.Active = active;
        }
    }
}