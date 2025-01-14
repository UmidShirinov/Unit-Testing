using Application.Dtos;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ToDoItemService : IToDoItemService
	{
		private readonly List<ToDoItem> _toDoItems = new();

		private int _idCounter = 1;
		public ToDoItem Add(CreateToDoItemDto itemDto)
		{
			var item = new ToDoItem()
			{
				Id = _idCounter++,
				Title = itemDto.Title,
				IsCompleted = false,

			};

			_toDoItems.Add(item);

			return item;
		}

		public IEnumerable<ToDoItem> GetAll()
		{
			return _toDoItems;
		}

		public ToDoItem GetById(int id)
		{
			var result = _toDoItems.FirstOrDefault(x => x.Id == id);

			return result;
		}

		public void MarkAsCompleted(int id)
		{
			var result = GetById(id);
			if (result != null)
			{
				result.IsCompleted = true;
			}
		}

		public void Remove(int id)
		{
			_toDoItems.Remove(GetById(id));
		}
	}
}
