namespace Hipicapp.Service.Mail.Models
{
    public class CreatedAccountEmailModel : EmailModel
    {
        public string FullName { get; set; }

        public string Url { get; set; }
    }
}