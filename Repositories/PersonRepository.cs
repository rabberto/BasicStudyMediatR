using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicStudyMediatR.Application.Models;

namespace BasicStudyMediatR.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private static Dictionary<int, Person> person = new Dictionary<int, Person>();

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Task.Run(() => person.Values.ToList());
        }

        public async Task<Person> Get(int id)
        {
            return await Task.Run(() => person.GetValueOrDefault(id));
        }

        public async Task<Person> Add(Person person)
        {
            return await Task.Run(() =>
            {
                var id = PersonRepository.person.Count() + 1;
                person.Id = id;
                PersonRepository.person.Add(id, person);
                return person;
            });
        }

        public async Task<Person> Edit(Person person)
        {
            return await Task.Run(() =>
            {
                PersonRepository.person.Remove(person.Id);
                PersonRepository.person.Add(person.Id, person);
                return person;
            });
        }

        public async Task<bool> Delete(int id)
        {
            await Task.Run(() => person.Remove(id));
            return true;
        }
    }
}