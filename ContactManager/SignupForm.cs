using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager
{
    public class SignupForm
    {
        public bool Signup(string firstName, string lastName, string emailAddress)
        {

            var dataAccess = new DataAccess();

            var saved = dataAccess.SaveRecord(firstName, lastName, emailAddress);
            return saved;
        }
    }
}
