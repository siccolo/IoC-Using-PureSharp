using System;
namespace IoCTemplate
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Read : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class Write : Attribute
    {
        
    }
}
