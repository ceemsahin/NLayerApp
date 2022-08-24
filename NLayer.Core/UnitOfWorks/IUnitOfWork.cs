namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //SaveChangeAsync
        Task CommitAsync();

        //SaveChange
        void Commit();

    }
}
