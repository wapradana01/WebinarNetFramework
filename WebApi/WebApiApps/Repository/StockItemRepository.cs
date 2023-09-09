using WebApiApps.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WebApiApps.Repository
{
    public class StockItemRepository
    {
        private readonly string _jsonFilePath = "StockItems.json";

        public IEnumerable<StockItem> GetAll()
        {
            var jsonString = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<StockItem>>(jsonString) ?? new List<StockItem>();
        }

        public StockItem GetById(int id)
        {
            var items = GetAll();
            return items.FirstOrDefault(item => item.Id == id);
        }

        public void Add(StockItem item)
        {
            var items = new List<StockItem>(GetAll());

            // Determine the next available Id
            int nextId = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;

            // Set the Id of the new item
            item.Id = nextId;

            items.Add(item);

            var jsonString = JsonSerializer.Serialize(items);
            File.WriteAllText(_jsonFilePath, jsonString);
        }

        public void Update(int id, StockItem updatedItem)
        {
            var items = new List<StockItem>(GetAll());
            var existingItem = items.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = updatedItem.Name;
                existingItem.Quantity = updatedItem.Quantity;
                existingItem.Price = updatedItem.Price;
                var jsonString = JsonSerializer.Serialize(items);
                File.WriteAllText(_jsonFilePath, jsonString);
            }
        }

        public void Delete(int id)
        {
            var items = new List<StockItem>(GetAll());
            var itemToDelete = items.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
                var jsonString = JsonSerializer.Serialize(items);
                File.WriteAllText(_jsonFilePath, jsonString);
            }
        }
    }
}
