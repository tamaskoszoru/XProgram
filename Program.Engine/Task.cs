namespace XProgram.Engine
{
    public abstract class Task : IValidatable, IExecutable
    {
        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        public abstract void Validate();
        public abstract void Execute();
    }

}
