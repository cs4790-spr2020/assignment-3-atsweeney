namespace BlabberApp.Domain.Interfaces
{
    public interface iDataStore
    {
        bool Create(iBaseEntity entity);

        iBaseEntity Read(int idx);

        bool Update(iBaseEntity entity);

        bool Delete(int idx);
    }
}