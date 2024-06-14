
using Xunit;
using Moq;
using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_application_2.Tests
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private static List<User> _userlist = new List<User>();

        public UserControllerTests()
        {
            // Setup the static userlist for testing purposes
            UserController.userlist = _userlist;
            _controller = new UserController();
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfUsers()
        {
            // Arrange
            _userlist.Add(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Details_WithValidId_ReturnsUser()
        {
            // Arrange
            var testUser = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
            _userlist.Add(testUser);

            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<User>(viewResult.Model);
            Assert.Equal(testUser.Id, model.Id);
            Assert.Equal(testUser.Name, model.Name);
            Assert.Equal(testUser.Email, model.Email);
        }

        [Fact]
        public void Details_WithInvalidId_ReturnsHttpNotFound()
        {
            // Act
            var result = _controller.Details(999); // Assuming 999 is an ID that doesn't exist

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }

        // Additional tests for Create, Edit, and Delete actions can be implemented similarly

        [Fact]
        public void Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var newUser = new User { Id = 2, Name = "New User", Email = "newuser@example.com" };

            // Act
            var result = _controller.Create(newUser);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            Assert.Contains(_userlist, u => u.Id == newUser.Id);
        }

        [Fact]
        public void Edit_Get_ValidId_ReturnsViewWithUser()
        {
            // Arrange
            var existingUser = new User { Id = 1, Name = "Existing User", Email = "existing@example.com" };
            _userlist.Add(existingUser);

            // Act
            var result = _controller.Edit(existingUser.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<User>(viewResult.Model);
            Assert.Equal(existingUser.Id, model.Id);
        }

        [Fact]
        public void Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var existingUser = new User { Id = 1, Name = "Existing User", Email = "existing@example.com" };
            _userlist.Add(existingUser);
            var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };

            // Act
            var result = _controller.Edit(updatedUser.Id, updatedUser);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            var userInList = _userlist.FirstOrDefault(u => u.Id == updatedUser.Id);
            Assert.NotNull(userInList);
            Assert.Equal(updatedUser.Name, userInList.Name);
        }

        [Fact]
        public void Delete_Get_ValidId_ReturnsViewWithUser()
        {
            // Arrange
            var userToDelete = new User { Id = 3, Name = "Delete Me", Email = "delete@example.com" };
            _userlist.Add(userToDelete);

            // Act
            var result = _controller.Delete(userToDelete.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<User>(viewResult.Model);
            Assert.Equal(userToDelete.Id, model.Id);
        }

        [Fact]
        public void DeleteConfirmed_Post_ValidId_RemovesUserAndRedirects()
        {
            // Arrange
            var userToDelete = new User { Id = 3, Name = "Delete Me", Email = "delete@example.com" };
            _userlist.Add(userToDelete);

            // Act
            var result = _controller.Delete(userToDelete.Id, new FormCollection());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            Assert.DoesNotContain(_userlist, u => u.Id == userToDelete.Id);
        }

        [Fact]
        // Cleanup after tests
        public void Dispose()
        {
            _userlist.Clear();
        }
    }
}