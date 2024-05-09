using ApiUsers.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "Иван Иванов Иванович", Age = 30, Email = "ivanov@gmail.com", PhoneNumber = "+7134567890"},
            new User { Id = 2, Name = "Ольга Ольгавна Ольгавнова", Age = 25, Email = "Olgavna@mail.ru", PhoneNumber = "+7986543210"},
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get(int page = 1, int pageSize = 10, string sortBy = "Id", string sortOrder = "asc", int? minAge = null, int? maxAge = null)
        {
            var filteredUsers = users.AsQueryable();

            // Фильтрация по возрасту, если заданы minAge и maxAge
            if (minAge.HasValue)
            {
                filteredUsers = filteredUsers.Where(u => u.Age >= minAge);
            }
            if (maxAge.HasValue)
            {
                filteredUsers = filteredUsers.Where(u => u.Age <= maxAge);
            }

            // Сортировка
            if (sortBy == "Имя")
            {
                filteredUsers = sortOrder == "asc" ? filteredUsers.OrderBy(u => u.Name) : filteredUsers.OrderByDescending(u => u.Name);
            }
            else if (sortBy == "Возраст")
            {
                filteredUsers = sortOrder == "asc" ? filteredUsers.OrderBy(u => u.Age) : filteredUsers.OrderByDescending(u => u.Age);
            }
            else
            {
                filteredUsers = sortOrder == "asc" ? filteredUsers.OrderBy(u => u.Id) : filteredUsers.OrderByDescending(u => u.Id);
            }

            // Пагинация
            var paginatedUsers = filteredUsers.Skip((page - 1) * pageSize).Take(pageSize);

            return Ok(paginatedUsers);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Age = user.Age;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Dictionary<string, object> fields)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            foreach (var field in fields)
            {
                if (field.Key == "Имя" && field.Value is string name)
                {
                    user.Name = name;
                }
                else if (field.Key == "Возраст" && field.Value is int age)
                {
                    user.Age = age;
                }
                else if (field.Key == "Почта" && field.Value is string email)
                {
                    user.Email = email;
                }
                else if (field.Key == "Номер телефона" && field.Value is string phoneNumber)
                {
                    user.PhoneNumber = phoneNumber;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return NoContent();
        }
    }
}