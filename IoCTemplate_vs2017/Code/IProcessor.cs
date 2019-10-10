using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCTemplate
{
    public interface IProcessor
    {
        Task DoWork();
    }
}
