using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Models
{

    
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="max value")]
        public int DisplayOrder { get; set; }   

        public DateTime CreatedDate { get; set; }  = DateTime.Now;
        [Required]
        public DateTime BirthDate { get; set; }
        
        public HttpPostedFileBase
    }
}
