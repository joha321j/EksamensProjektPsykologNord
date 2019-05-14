using System;
using System.Globalization;

namespace ApplicationClassLibrary
{
    public static class InputValidator
    {
        public static void EnsureValidPhoneNumber(string clientPhoneNumber)
        { 
            IntValidator(clientPhoneNumber, "telefonnummer");
        }

        public static void EnsureValidSsn(string clientSsn)
        {
            IntValidator(clientSsn, "CPR-nummer");
        }

        public static void EnsureValidZip(string clientAddress)
        {
            string[] tempStrings = clientAddress.Split(';');
            if (tempStrings.Length > 1)
            {
                IntValidator(tempStrings[1], "postnummer");
            }
            else
            {
                throw new InvalidInputException("En kunde skal have et postnummer.");
            }
        }

        /// <summary>
        /// Tries to parse the input as an int, if it fails it throws an expection.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputType"></param>
        private static void IntValidator(string input, string inputType)
        {
            input = input.Trim();
            if (input!= string.Empty)
            {
                foreach (char c in input)
                {
                    if (!int.TryParse(c.ToString(), out _))
                    {
                        throw new InvalidInputException($"{input} er ikke et gyldigt {inputType}.");
                    }
                }
            }
            else
            {
                throw new InvalidInputException($"En kunde skal have et {inputType}");
            }

            
        }

        public static DateTime ConvertShortTimeStringToDateTime(string timeString)
        {
            if (!DateTime.TryParse(timeString, out var dateTime))
            {
                throw new InvalidInputException("Der skete en fejl med datoen.");
            }

            return dateTime;
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}