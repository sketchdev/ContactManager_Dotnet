namespace ContactManager
{
    public class SpamService
    {
        public bool IsKnownSpam(string emailAddress)
        {
            if (emailAddress == "knownspam@spam.com") return true;
            return false;
        }
    }
}