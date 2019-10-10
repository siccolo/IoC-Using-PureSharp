using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoCTemplate
{
    public interface IDataManager<TEntry>
    {
        //
        [Read]
        Task<bool> Load();
        //

        //Task<bool> Put(IDataContainer<TEntries> dataContainer);
        [Write]
        Task<bool> Put(IEnumerable<TEntry> list);

        [Write]
        bool Add(TEntry entry);

        IEnumerable<TEntry> Pull();
    }
}
