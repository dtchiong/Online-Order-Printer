using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Services {
    class CredentialManager {

        /**
         * Encrypts and saves the given userId and bearerToken to file
         */
        public static bool SaveCredentials(string userId, string bearerToken) {
            try {
                FileStream fileStream = new FileStream(FormContainer.UserDataPath, FileMode.Create);

                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(string.Concat(userId, " ", bearerToken));

                Debug.WriteLine($"Original data: {Encoding.UTF8.GetString(bytesToEncrypt)}");
                Debug.WriteLine("Encrypting and writing to disk...");

                int bytesWritten = EncryptDataToStream(bytesToEncrypt, DataProtectionScope.CurrentUser, fileStream);
                fileStream.Close();
                Debug.WriteLine($"{bytesWritten} bytes written!");

                return true;
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        /**
         * Retrieves the stored credentials as a tuple (userId, bearerToken) by decrypting it from file
         */
        public static (string, string) RetrieveCredentials() {
            try {
                FileStream fileStream = new FileStream(FormContainer.UserDataPath, FileMode.Open);
                byte[] decryptedData = DecryptDataFromStream(DataProtectionScope.CurrentUser, fileStream);
                string userCredentials = Encoding.UTF8.GetString(decryptedData);
                Debug.WriteLine($"Decrypted data: {userCredentials}");

                string[] credsArray = userCredentials.Split(' ');
                return (credsArray[0], credsArray[1]);
            } catch {
                return (null, null);
            }
        }

        /**
         * Deletes the credentials files
         */
        public static bool DeleteCredentials() {
            try {
                File.Delete(FormContainer.UserDataPath);
                return true;
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        private static int EncryptDataToStream(byte[] buffer, DataProtectionScope scope, FileStream fileStream) {
            byte[] encryptedData = ProtectedData.Protect(buffer, null, scope);

            int length = 0;

            if (fileStream.CanWrite && encryptedData != null) {
                fileStream.Write(encryptedData, 0, encryptedData.Length);
                length = encryptedData.Length;
            }
            return length;
        }

        private static byte[] DecryptDataFromStream(DataProtectionScope scope, FileStream fileStream) {
            byte[] inBuffer = new byte[fileStream.Length];
            byte[] outBuffer = null;

            if (fileStream.CanRead) {
                fileStream.Read(inBuffer, 0, (int)fileStream.Length);
                outBuffer = ProtectedData.Unprotect(inBuffer, null, scope);
            }
            return outBuffer;
        }
    }
}
