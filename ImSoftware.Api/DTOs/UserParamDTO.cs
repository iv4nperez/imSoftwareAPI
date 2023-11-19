using System.ComponentModel.DataAnnotations;

namespace ImSoftware.Api.DTOs
{
    public class UserParamDTO
    {


        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Please enter valid integer Number")]
        public int UserAge { get; set; }
    }
}
