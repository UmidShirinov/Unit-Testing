﻿using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
		private readonly IToDoItemService _toDoItemService;


		public ToDoController(IToDoItemService toDoItemService)
		{
			_toDoItemService = toDoItemService;
		}


		[HttpGet]
		public IActionResult GetAll() => Ok(_toDoItemService.GetAll());

		[HttpGet("{id}")]
		public IActionResult GetById(int id) => Ok(_toDoItemService.GetById(id));

		[HttpPost]
		public IActionResult Create(CreateToDoItemDto dto)
		{
			var newItem = _toDoItemService.Add(dto);

			return CreatedAtAction(nameof(GetById), new { Id = newItem.Id }, newItem);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_toDoItemService.Remove(id);
			return NoContent();
		}

		[HttpPut("{id}/complete")]
		public IActionResult MarkAsCompleted(int id)
		{
			_toDoItemService.MarkAsCompleted(id);
			return NoContent();
		}
	}
}