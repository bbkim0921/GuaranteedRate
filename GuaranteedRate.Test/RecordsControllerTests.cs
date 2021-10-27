using System;
using System.Collections.Generic;
using System.Linq;
using GuaranteedRate.API.Controllers;
using GuaranteedRate.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GuaranteedRate.Test
{
    public class RecordsControllerTests
    {
        private readonly Mock<IUserService> _serviceStub = new Mock<IUserService>();
        [Fact]
        public void GetRecordsSortedByColor_ReturnsOk()
        {     
            var controller = new RecordsController(_serviceStub.Object);
            var result = controller.GetRecordsSortedByColor();
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetRecordsSortedByBirthdate_ReturnsOk()
        {
            var controller = new RecordsController(_serviceStub.Object);
            var result = controller.GetRecordsSortedByColor();
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetRecordsSortedByName_ReturnsOk()
        {
            var controller = new RecordsController(_serviceStub.Object);
            var result = controller.GetRecordsSortedByColor();
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void AddRecord_ReturnsCreatedRecord()
        {
            var expectedItem = new UserDto
            {
                LastName = "Kim",
                FirstName = "Bryan",
                Email = "bryankim@gmail.com",
                FavoriteColor = "white",
                DateOfBirth = "09/21/1982",
            };            
            
            var controller = new RecordsController(_serviceStub.Object);
            var result = controller.AddRecord("Kim|Bryan|bryankim@gmail.com|white|09/21/1982");

            var createdItem = (result.Result as CreatedAtActionResult).Value as UserDto;

            Assert.Equal(expectedItem, createdItem);
        }
    }
}
