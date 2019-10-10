using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puresharp;
namespace IoCTemplate
{
    class Program
    {
        //static async Task Main(string[] args)
        static void Main(string[] args)
        {
            var _logging = new InterceptAspect();
            _logging.Weave<InterceptReadWriteOperation>();
            
            Console.WriteLine("------");

            DoWork(args).GetAwaiter().GetResult();

            Console.WriteLine("------");
        }

        private static async Task DoWork(string[] args)
        {
            //Processor.DoWork();
            //var processor = new Processor();
            //processor.DoWork();


            var composition = new Composition();
            composition.Setup<IDataContainer<string>>(() => new DataContainer(), Instantiation.Multiton);
            composition.Setup<IDataManager<string>>(() => new DataManager(Metadata<IDataContainer<string>>.Value), Instantiation.Multiton);
            composition.Setup<IProcessor>(() => new Processor(Metadata<IDataManager<string>>.Value), Instantiation.Multiton);
            using (var container = composition.Materialize())
            {
                using (var processor = container.Module<IProcessor>())
                {
                    ((IProcessor)processor.Value).DoWork();
                }
            }
        }
    }
}
