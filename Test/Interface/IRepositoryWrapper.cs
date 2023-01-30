namespace Interface
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITodoRepository Todo { get; }
        void Save();
    }
}