using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoCTemplate
{
    public class DataManager:IDataManager<string>
    {
        IDataContainer<string> _DataContainer;

        public DataManager(IDataContainer<string> dataContainer)
        {
            Console.WriteLine("     -- DataManager() --");
            _DataContainer = dataContainer;
        }

        
        public async Task<bool> Load()
        {
            var l = new List<string> { "aa", "bb", "cc" };
            var result = await _DataContainer.Init(l);
            return result;
        }

        public IEnumerable<string> Pull()
        {
            return _DataContainer.Data;
        }

        public async Task<bool> Put(IEnumerable<string> list)
        {
            var result = await _DataContainer.Put(list);
            return result;
        }
         
        public bool Add(string value)
        {
            return _DataContainer.Add(value);
        }
       
    }
}
