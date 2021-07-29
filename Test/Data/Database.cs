using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data
{
    public class Database : IDatabase
    {
        public ConcurrentDictionary<Guid, string> Items = new ConcurrentDictionary<Guid, string>();

        public Database() 
        {
            Items.TryAdd(Guid.NewGuid(), "BMV");
            Items.TryAdd(Guid.NewGuid(), "Lada");
            Items.TryAdd(Guid.NewGuid(), "Audi");
        }

        public async Task<bool> AddNewItems(string index)
        { 
            bool result =   Items.TryAdd(Guid.NewGuid(), index);
            return result;
        }

        public async Task<ConcurrentDictionary<Guid, string>> GetAlltems()
        {
            return Items;
        }

        public async Task<bool> RemoveByIndex(Guid index)
        {
            string value;
            bool result = Items.TryRemove(index, out value);
            return result;
        }

        public async Task<bool> UpdateByIndex(Guid index, string newName , string comparisonName)
        {
            bool result = Items.TryUpdate(index, newName, comparisonName);
            return result;
        }
    }
}
