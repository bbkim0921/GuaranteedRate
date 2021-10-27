using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GuaranteedRate.Data
{
    public class UserService : IUserService
    {
        public List<UserDto> LoadUsers()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var users = new List<UserDto>();
            users.AddRange(ParseFile(Path.Combine(executableLocation, @"Files\SampleData1.txt")));
            users.AddRange(ParseFile(Path.Combine(executableLocation, @"Files\SampleData2.txt")));
            users.AddRange(ParseFile(Path.Combine(executableLocation, @"Files\SampleData3.txt")));
            return users;
        }

        public List<UserDto> GetSortedUsers(string sortBy)
        {
            var users = LoadUsers();
            switch(sortBy)
            {
                case "favoriteColor":
                    return users.OrderBy(x => x.FavoriteColor).ToList();
                case "dateOfBirth":
                    return users.OrderBy(x => x.DateOfBirth).ToList();
                case "name":
                    return users.OrderBy(x => x.LastName).ToList();
                default:
                    return users;
            }
        }

        public UserDto AddUser(UserDto userDto)
        {
            return userDto;
        }

        public List<UserDto> ParseFile(string filePath)
        {
            var lines = File.ReadLines(filePath);
            var delimiter = FindDelimiter(lines.First());
            var users = new List<UserDto>();

            foreach (var line in lines.Skip(1))
            {
                users.Add(ParseUserData(line, delimiter));
            }
            return users;
        }

        public UserDto ParseUserData(string line, char delimiter)
        {
            var parts = line.Split(delimiter).ToArray();
            return new UserDto
            {
                LastName = parts[0],
                FirstName = parts[1],
                Email = parts[2],
                FavoriteColor = parts[3],
                DateOfBirth = parts[4]
            };
        }

        public char FindDelimiter(string line)
        {
            if (line.IndexOf('|') > 0)
            {
                return '|';
            }
            else if (line.IndexOf(',') > 0)
            {
                return ',';
            }
            else return ' ';
        }
    }
}
