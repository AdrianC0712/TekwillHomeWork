using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex2.Validarea_datelor_de_autentificare
{
    internal class Program
    {
        public class UsernameEmptyException : Exception
        {
            public UsernameEmptyException(string message) : base(message)
            {
            }
        }

        public class PasswordTooShortException : Exception
        {
            public PasswordTooShortException(string message) : base(message)
            {
            }
        }

        public class InvalidPasswordFormatException : Exception
        {
            public InvalidPasswordFormatException(string message) : base(message)
            {
            }
        }

        public class InvalidCredentialsException : Exception
        {
            public InvalidCredentialsException(string message) : base(message)
            {
            }
        }

        static Dictionary<string, string> userDatabase = new Dictionary<string, string>
    {
        { "admin", "P@ssw0rd" },
        { "user1", "Test123" },
        { "guest", "Guest99" }
    };
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Introduceti numele de utilizator: ");
                string username = Console.ReadLine();

                Console.Write("Introduceti parola: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new UsernameEmptyException("Eroare: Numele de utilizator nu poate fi gol.");
                }

                if (password.Length < 6)
                {
                    throw new PasswordTooShortException("Eroare: Parola trebuie sa aiba cel putin 6 caractere.");
                }

                if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                {
                    throw new InvalidPasswordFormatException("Eroare: Parola trebuie sa contina cel putin o litera mare, o litera mica si un numar.");
                }

                if (!userDatabase.ContainsKey(username) || userDatabase[username] != password)
                {
                    throw new InvalidCredentialsException("Eroare: Nume de utilizator sau parola incorecte.");
                }

                Console.WriteLine("\nAutentificare reusita! Bun venit, " + username + "!");
            }
            catch (UsernameEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PasswordTooShortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidPasswordFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidCredentialsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare neasteptata: {ex.Message}");
            }
        }
    }
}
