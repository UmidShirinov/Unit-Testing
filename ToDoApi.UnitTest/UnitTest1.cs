using Application.Dtos;
using Application.Entities;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApi.Controllers;

namespace ToDoApi.UnitTest
{
	public class UnitTest1
	{
		private readonly Mock<IToDoItemService> _mockService;
		private readonly ToDoController _toDoController;
		public UnitTest1()
		{
			_mockService = new Mock<IToDoItemService>();
			_toDoController = new ToDoController(_mockService.Object);
		}
		[Fact]
		public void Create_ShouldReturnCreatedAtAction()
		{
			//Arrenge
			var newItem = new CreateToDoItemDto { Title = "Test task" };

			var createdItem = new ToDoItem { Id = 1, Title = newItem.Title, IsCompleted = false };

			_mockService.Setup(x => x.Add(newItem)).Returns(createdItem);

			//Act
			var result = _toDoController.Create(newItem);

			//Assert
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(201, objectResult.StatusCode);
			Assert.Equal(createdItem, objectResult.Value);
		}


		[Fact]
		public void GetById_ShouldReturnNotFound()
		{
			_mockService.Setup(x => x.GetById(1)).Returns((ToDoItem)null);

			var result = _toDoController.GetById(1);

			Assert.IsType<NotFoundResult>(result);

		}
	}
}

