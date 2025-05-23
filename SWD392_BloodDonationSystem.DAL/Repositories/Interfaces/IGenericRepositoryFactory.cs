namespace SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;

public interface IGenericRepositoryFactory
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}