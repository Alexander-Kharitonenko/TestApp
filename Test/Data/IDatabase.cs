using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data
{
    public interface IDatabase
    {
        public Task<ConcurrentDictionary<Guid, string>> GetAlltems();
        public Task<bool> AddNewItems(string index);
        public Task<bool> RemoveByIndex(Guid index);
        public Task<bool> UpdateByIndex(Guid index , string newName, string comparisonName);

    }
}
