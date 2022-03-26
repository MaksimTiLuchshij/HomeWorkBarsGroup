using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Entity {
        public int Id;
        public int ParentId;
        public string Name;

        public Entity(int Id, int ParentId, string Name) {
            this.Id = Id;
            this.ParentId = ParentId;
            this.Name = Name;
        }
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
            var people1 = new Entity(1, 0, "Root entity");
            var people2 = new Entity(2, 1, "Child of 1 entity");
            var people3 = new Entity(3, 1, "Child of 1 entity");
            var people4 = new Entity(4, 2, "Child of 2 entity");
            var people5 = new Entity(5, 4, "Child of 4 entity");

            List<Entity> entities = new List<Entity>();
            entities.Add(people1);
            entities.Add(people2);
            entities.Add(people3);
            entities.Add(people4);
            entities.Add(people5);
            Program.ListToDict(entities);
        }
    }
}
