using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace group.Models
{
    public class ViewModel
    {
        //Contact
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
            [Required]
            public string PM { get; set; }
        [Required]
        public int Status { get; set; }
        //Member
        [Required]
        public string Name { get; set; }
        [Required]
        public string MemberEmail { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string linkedin { get; set; }
        public string Dribble { get; set; }
        public string Telegram { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Bio { get; set; }
        //News
        [Required]
        public string NewsImage { get; set; }
        [Required]
        [AllowHtml]
        public string Descr { get; set; }
        //Product
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDesc { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public string CustomerImage { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Comment { get; set; }
        //ProductMember
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public HttpPostedFileBase file { get; set; }
        public HttpPostedFileBase file2 { get; set; }

    }
}