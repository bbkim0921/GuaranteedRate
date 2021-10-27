using GuaranteedRate.Data;
using Microsoft.AspNetCore.Mvc;

namespace GuaranteedRate.API.Controllers
{
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IUserService _userService;
        public RecordsController(IUserService userSerivce) => _userService = userSerivce;

        [HttpGet("api/records/color", Name = "GetRecordsSortedByColor")]
        public IActionResult GetRecordsSortedByColor()
        {
            var users = _userService.GetSortedUsers("favoriteColor");
            return Ok(users);
        }

        [HttpGet("api/records/birthdate", Name = "GetRecordsSortedByBirthdate")]
        public IActionResult GetRecordsSortedByBirthdate()
        {
            var users = _userService.GetSortedUsers("dateOfBirth");
            return Ok(users);
        }

        [HttpGet("api/records/name", Name = "GetRecordsSortedByName")]
        public IActionResult GetRecordsSortedByName()
        {
            var users = _userService.GetSortedUsers("name");
            return Ok(users);
        }

        [HttpPost("api/records", Name = "AddRecord")]
        public ActionResult<UserDto> AddRecord(string record)
        {
            var delimiter = _userService.FindDelimiter(record);
            var userDto = _userService.ParseUserData(record, delimiter);
            var newUser = _userService.AddUser(userDto);
            return Ok(newUser);
        }
    }
}
