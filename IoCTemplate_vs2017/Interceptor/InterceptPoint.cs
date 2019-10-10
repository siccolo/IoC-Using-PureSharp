using System;
using System.Reflection;
using Puresharp;

namespace IoCTemplate 
{
    
    public class InterceptPoint : Pointcut
    {
        override public bool Match(MethodBase method)
        {
            //return method.DeclaringType == typeof(Data.Data) && method.GetCustomAttributes(typeof(someattribute), true).Any();
            return method.DeclaringType == typeof(Processor) ;
        }
    }
    

    public class InterceptReadWriteOperation : Pointcut.Or<Pointcut<Write>, Pointcut<Read>>
    {
        
    }
}
