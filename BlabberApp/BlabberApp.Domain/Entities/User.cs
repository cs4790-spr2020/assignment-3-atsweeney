using System;
using System.Net.Mail;

namespace BlabberApp.Domain.Entities
{
    public class User : BaseEntity
    {
        //Properties
        public DateTime RegisterDTTM { get; set; }

        public DateTime LastLoginDTTM { get; set; }

        public string Email {get; private set; }


        //Methods
        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
            {
                throw new FormatException("Invalid email");
            }

            try 
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid email");
            }

            this.Email = email;
        }
    }
}