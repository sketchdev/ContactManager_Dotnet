namespace ContactManager
{
    public class SignupForm
    {
        public bool Signup(string firstName, string lastName, string emailAddress)
        {
            return new DataAccess().SaveRecord(firstName, lastName, emailAddress);
        }
    }
}
