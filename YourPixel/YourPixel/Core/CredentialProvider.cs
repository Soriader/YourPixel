using CredentialManagement;
using Microsoft.Identity.Client;

namespace YourPixel.Core
{
    public static class CredentialProvider
    {
        public static Credential GetCredential(string target)
        {
            var cred = new Credential {Target = target};

            if (!cred.Load())
            {
                return null;
            }

            return cred;
        } 

        public static bool SetCredential(string target, string userName, string password, PersistanceType persistance)
        {
            return new Credential {Target = target, Username = userName, Password = password, PersistanceType = persistance }.Save();
        }
    }
}
