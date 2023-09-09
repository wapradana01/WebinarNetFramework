using Microsoft.AspNetCore.Mvc;
using WebApiApps.Model;
using WebApiApps.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiApps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockItemRepository _repository;

        public StockController(StockItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<StockItem> GetAll() => _repository.GetAll();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(StockItem item)
        {
            _repository.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StockItem updatedItem)
        {
            _repository.Update(id, updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
