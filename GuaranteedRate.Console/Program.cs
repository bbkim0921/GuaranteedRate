using System;
using System.Collections.Generic;
using System.Linq;
using GuaranteedRate.Data;

namespace GuaranteedRate
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var users = userService.LoadUsers();
            displayResult(users.OrderBy(x => x.FavoriteColor).ThenBy(x => x.LastName), "Output 1 - sorted by favorite color then by last name ascending");
            displayResult(users.OrderBy(x => x.DateOfBirth), "Output 2 - sorted by birth date, ascending");
            displayResult(users.OrderByDescending(x => x.LastName), "Output 3 - sorted by last name, descending");
            Console.ReadLine();
        }

        private static void displayResult(IEnumerable<UserDto> users, string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-15} {4,10}", "Last Name", "First Name", "Email", "Favorite Color", "Date of Birth");
            foreach (var user in users)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-15} {4,10}", user.LastName, user.FirstName, user.Email, user.FavoriteColor, user.DateOfBirth);
            }
            Console.WriteLine();
        }
    }
}
