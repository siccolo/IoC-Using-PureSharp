using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Puresharp;

namespace IoCTemplate
{
    public class InterceptAdvice:IAdvice
    {
        public void Log(Exception exception
                , [System.Runtime.CompilerServices.CallerMemberName] string caller = ""
                , [System.Runtime.CompilerServices.CallerLineNumber] int line = 0
            )
        {
            Console.WriteLine($"Exception in {caller} at {line} - " + exception.ToString());
        }

        public void Log(string text
                , [System.Runtime.CompilerServices.CallerMemberName] string caller = ""
                , [System.Runtime.CompilerServices.CallerLineNumber] int line = 0)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {caller} --> {text}");
        }

        private MethodBase _Method;

        public InterceptAdvice(MethodBase method)
        {
            this._Method = method;
        }

        public void Instance<T>(T instance)
        {
        }

        public void Argument<T>(ref T value)
        {
        }

        public void Begin()
        {
            Log($"Begin {_Method.Name}");
        }

        public void Await(MethodInfo method, Task task)
        {
            Log($"Await {_Method.Name}");
        }

        public void Await<T>(MethodInfo method, Task<T> task)
        {
            Log($"Await {_Method.Name}");
        }

        public void Continue()
        {
            Log($"Continue {_Method.Name}");
        }

        public void Throw(ref Exception exception)
        {
            Log($"Throw {_Method.Name}");
        }

        public void Throw<T>(ref Exception exception, ref T value)
        {
        }

        public void Return()
        {
            Log($"Return {_Method.Name}");
        }

        public void Return<T>(ref T value)
        {
            Log($"Return {_Method.Name}");
        }

        public void Dispose()
        {
        }
    }
}
