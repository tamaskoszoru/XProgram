using System;
using System.Collections.Generic;
using System.Text;

namespace XProgram.Engine
{
    public class ItemValidationContext : IDisposable
    {

        public ItemValidationContext(IValidatable item)
        {
            ProgramValidationContext.Current.PushPath(item.GetName());
        }

        public ItemValidationContext(IValidatable item, int line)
        {
            ProgramValidationContext.Current.PushPath(item.GetName() + $" (Line: {line})");
        }

        public void AddError(string msg)
        {
            ProgramValidationContext.Current.AddError(msg);
        }

        public void AddWarning(string msg)
        {
            ProgramValidationContext.Current.AddWarning(msg);
        }

        public void Dispose()
        {
            ProgramValidationContext.Current.PopPath();
        }
    }
}
