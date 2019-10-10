using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCTemplate
{
    public class Processor:IProcessor
    {
        IDataManager<string> _DataManager;
        public Processor(IDataManager<string> dataManager)
        {
            Console.WriteLine("     -- Processor() --");
            _DataManager = dataManager;
        }

        public async Task DoWork()
        {
            var loaded = await _DataManager.Load();

            var all = _DataManager.Pull();
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            var l = new List<string>() { "a1", "b1", "c1" };
            //
            var saved = await _DataManager.Put(l);

            return;
        }
    }
}
