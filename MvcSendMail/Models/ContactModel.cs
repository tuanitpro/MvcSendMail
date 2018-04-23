/* FileName: ContactModel.cs
Project Name: MvcSendMail
Date Created: 9/15/2014PM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/
using System.ComponentModel.DataAnnotations;
namespace MvcSendMail.Models
{
    /// <summary>
    /// Contact Model
    /// Chứa các thuộc tính của form liên hệ
    /// </summary>
    public class ContactModel
    {
        [Display(Name = "Tên của bạn")]
        [Required(ErrorMessage = "Tên không được trống")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng")]
        public string Email { get; set; }

        [Display(Name = "Chủ đề")]
        [Required(ErrorMessage = "Chủ đề không được trống")]
        public string Subject { get; set; }

        [Display(Name = "Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}