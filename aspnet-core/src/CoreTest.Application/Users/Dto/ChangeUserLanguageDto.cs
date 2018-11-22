using System.ComponentModel.DataAnnotations;

namespace CoreTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}