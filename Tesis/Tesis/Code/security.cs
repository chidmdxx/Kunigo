using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Tesis.Code
{
    public class Security
    {
        private string hashedPassword;
        private string saltValue;

        public string HashedPassword
        {
            get
            {
                return hashedPassword;
            }
        }
        public string SaltValue
        {
            get
            {
                return saltValue;
            }
            set
            {
                saltValue = value;
            }
        }
        public Security()
        {
            hashedPassword = null;
            saltValue = null;
        }
        public Security(string saltValue)
        {
            hashedPassword = null;
            this.saltValue = saltValue;
        }
        public void Work(string clearData)
        {
            HashAlgorithm hash = HashAlgorithm.Create("SHA256");
            if (saltValue == null)
            {
                saltValue = GenerateSaltValue();
            }
            hashedPassword = HashPassword(clearData, saltValue, hash);
        }
        private static string GenerateSaltValue()
        {
            StringBuilder builder = new StringBuilder();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] salt = new byte[App.SaltValueSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(salt);

            foreach (byte outputByte in salt)
                builder.Append(outputByte.ToString("x2").ToUpper());

            return builder.ToString();

        }
        private static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                byte[] binarySaltValue = new byte[App.SaltValueSize];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[App.SaltValueSize + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, App.SaltValueSize);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = saltValue;

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }


    }
}