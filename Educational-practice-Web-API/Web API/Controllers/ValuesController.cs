using System.Collections.Generic;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class ValuesController : ApiController
    {
        // Временное хранилище данных для примера
        private static readonly List<string> Values = new List<string> { "value1", "value2" };

        // GET api/values
        public IHttpActionResult Get()
        {
            // Возвращаем все значения
            return Ok(Values);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            // Проверяем, существует ли значение с указанным ID
            if (id < 0 || id >= Values.Count)
            {
                return NotFound(); // Возвращаем 404, если значение не найдено
            }

            // Возвращаем значение по ID
            return Ok(Values[id]);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] string value)
        {
            // Проверяем, что значение не пустое
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty."); // Возвращаем 400, если значение пустое
            }

            // Добавляем новое значение в список
            Values.Add(value);

            // Возвращаем 201 (Created) и URI нового ресурса
            return CreatedAtRoute("DefaultApi", new { id = Values.Count - 1 }, value);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody] string value)
        {
            // Проверяем, существует ли значение с указанным ID
            if (id < 0 || id >= Values.Count)
            {
                return NotFound(); // Возвращаем 404, если значение не найдено
            }

            // Проверяем, что значение не пустое
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty."); // Возвращаем 400, если значение пустое
            }

            // Обновляем значение по ID
            Values[id] = value;

            // Возвращаем 204 (No Content)
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            // Проверяем, существует ли значение с указанным ID
            if (id < 0 || id >= Values.Count)
            {
                return NotFound(); // Возвращаем 404, если значение не найдено
            }

            // Удаляем значение по ID
            Values.RemoveAt(id);

            // Возвращаем 204 (No Content)
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}