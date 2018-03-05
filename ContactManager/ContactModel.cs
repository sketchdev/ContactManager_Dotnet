using System;
using System.Text.RegularExpressions;

namespace ContactManager
{
    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string WorkEmailAddress { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Mvp { get; set; }

        public string Salutation { get; set; }
        public string Suffix { get; set; }
        public string JobTitle { get; set; }


        public string HomeAddressLine1 { get; set; }
        public string HomeAddressLine2 { get; set; }
        public string HomeAddressCity { get; set; }
        public string HomeAddressState { get; set; }
        public int HomeAddressPostalCode { get; set; }

        public string WorkAddressLine1 { get; set; }
        public string WorkAddressLine2 { get; set; }
        public string WorkAddressCity { get; set; }
        public string WorkAddressState { get; set; }
        public int WorkAddressPostalCode { get; set; }

        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public bool IsValid(out string error)
        {

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                error = "First name empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                error = "Last name empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                error = "email empty";
                return false;
            }

            else if (!new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                  + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase)
                .Match(EmailAddress).Success)
            {
                error = "Email not valid";

                return false;
            }

            if (string.IsNullOrWhiteSpace(HomeAddressLine1))
            {
                error = "Home address line 1 empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(HomeAddressCity))
            {
                error = "Home address line 2 empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(HomeAddressState))
            {
                error = "Home address state empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(HomeAddressPostalCode.ToString()))
            {
                error = "Home address postal empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(WorkAddressLine1))
            {
                error = "Work address line 1 empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(WorkAddressCity))
            {
                error = "Work address city empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(WorkAddressState))
            {
                error = "Work address state empty";
                return false;
            }
            if (string.IsNullOrWhiteSpace(HomeAddressPostalCode.ToString()))
            {
                error = "Work address postal empty";
                return false;
            }


            /// We can no longer use the USPSManager because of framework isues.

            //try
            //{
            //    USPSManager m = new USPSManager("602COLLE2630", true);
            //    Address a = new Address();
            //    a.Address2 = HomeAddressLine1;
            //    a.City = HomeAddressCity;
            //    a.State = HomeAddressState;
            //    a.Zip = HomeAddressPostalCode.ToString();

            //    Address validatedAddress = m.ValidateAddress(a);
            //}
            //catch (USPSManagerException err)
            //{
            //    error = "USPS Validation error: " + err.ToString();
            //    return false;
            //}


            error = "";

            return true;
        }

    }
}
