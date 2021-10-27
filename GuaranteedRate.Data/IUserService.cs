using System.Collections.Generic;

namespace GuaranteedRate.Data
{
    public interface IUserService
    {
        List<UserDto> GetSortedUsers(string sortBy);
        List<UserDto> LoadUsers();
        List<UserDto> ParseFile(string filePath);
        UserDto ParseUserData(string line, char delimiter);
        char FindDelimiter(string line);
        UserDto AddUser(UserDto userDto);
    }
}