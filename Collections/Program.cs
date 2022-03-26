using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Entity {
        public int Id;
        public int ParentId;
        public string Name;
    }
    class Program
    {
        public static Dictionary<int, List<Entity>> ListToDict(List<Entity> entities)
        {
            IEnumerable<Entity> query = entities
                .OrderBy(x => x.ParentId);
            Dictionary<int, List<Entity>> peoples = new Dictionary<int, List<Entity>>();
            foreach (var people in query) {
                if (peoples.ContainsKey(people.ParentId))
                    peoples[people.ParentId].Add(people);
                else
                {
                    var entityList = new List<Entity>();
                    entityList.Add(people);
                    peoples[people.ParentId] = entityList;
                }
            }
            //Проверка
            foreach (var people in peoples)
            {
                foreach (var el in people.Value)
                {
                    Console.WriteLine($"Ключ: {people.Key}, Id: {el.Id}, ParentId: {el.ParentId}, Name: {el.Name}");
                }
            }
            return peoples;
        }
        static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity>()
            {
                new Entity {Id = 1, ParentId = 0, Name = "Root entity"},
                new Entity {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };
            Program.ListToDict(entities);
        }
    }
}
