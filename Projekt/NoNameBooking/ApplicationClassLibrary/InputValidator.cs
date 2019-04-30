using System;

namespace ApplicationClassLibrary
{
    public static class InputValidator
    {
        public static void EnsureValidPhoneNumber(string clientPhoneNumber)
        { 
            IntValidator(clientPhoneNumber, "phone number");
        }

        public static void EnsureValidSsn(string clientSsn)
        {
            IntValidator(clientSsn, "SSN");
        }

        public static void EnsureValidZip(string clientAddress)
        {
            IntValidator(clientAddress, "Zip code");
        }

        private static void IntValidator(string input, string inputType)
        {
            foreach (char c in input)
            {
                if (!int.TryParse(c.ToString(), out _))
                {
                    throw new InvalidInputException($"{input} is not a valid {inputType}");
                }
            }
            
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}