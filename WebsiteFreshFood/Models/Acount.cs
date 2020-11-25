namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Acount
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string DangNhap { get; set; }

        public Acount() { }

        public Acount(string userName, string passWord, string dangNhap)
        {
            this.UserName = userName;
            this.Password = passWord;
            this.DangNhap = dangNhap;
        }
    }
}