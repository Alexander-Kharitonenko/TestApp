using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class ViewModel
    {
        public ConcurrentDictionary<Guid, string> AllItems { get; set; }
    }
}
