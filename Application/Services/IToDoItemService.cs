using Application.Dtos;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public interface IToDoItemService
	{
		IEnumerable<ToDoItem> GetAll();
		ToDoItem GetById(int id);
		ToDoItem Add(CreateToDoItemDto itemDto);
		void Remove(int id);
		void MarkAsCompleted(int id);
	}
}
