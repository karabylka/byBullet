namespace Common.Helpers.Patterns
{
    public interface ICreator
    {
        IProduct Create<T>();
    }
}