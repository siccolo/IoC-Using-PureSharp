using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoCTemplate
{
    public interface IDataContainer<TEntry>
    {
        Task<bool> Init(IEnumerable<TEntry> data);

        IEnumerable<TEntry> Data { get; }

        Task<bool> Put(IEnumerable<TEntry> entries);

        bool Add(TEntry entry);
    }

}
