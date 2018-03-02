using System;
using System.Text.RegularExpressions;

namespace ContactManager
{
    public class DataAccess
    {
        DatabaseConnection _connection;

        public DataAccess()
        {
            var servername = "(local)";
            var timeout = 30;
            var datasetName = "Accounts";

            var connection = new DatabaseConnection(servername, timeout, datasetName);
            _connection = connection;
        }

        public bool SaveRecord(string firstName, string lastName, string emailAddress)
        {
            if (firstName.Length <= 10)
            {
                if (!Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


            if (lastName.Contains("-"))
            {
                var lastNameParts = lastName.Split('-');
                for (int i = 0; i < lastNameParts.Length; i++)
                {
                    if (!Regex.IsMatch(lastNameParts[i], @"^[a-zA-Z]+$"))
                    {
                        return false;
                    }
                }
            }

            else if (lastName.Length <= 20)
            {
                if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // From the RFC822 Spec
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
              + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var match = regex.Match(emailAddress);

            if (!match.Success) return false;

            // config.featureToggles.RequireSpamPass
            if (new SpamService().IsKnownSpam(emailAddress)) return false;

            // config.featureToggles.RequireMxContactablePass
            if (!new MxDomainService().DoesMxDomainRespond(emailAddress)) return false;


            //var isUnique = new ContactModel().IsUnique(emailAddress);
            //if (!isUnique) return false;

            //finish saving the record here.
            return true;
        }

    }

    public class DatabaseConnection
    {
        string _serverName;
        int _timeout;
        string _datasetname;

        public DatabaseConnection(string servername, int timeout, string datasetName)
        {
            _serverName = servername;
            _timeout = timeout;
            _datasetname = datasetName;
        }
    }
}
