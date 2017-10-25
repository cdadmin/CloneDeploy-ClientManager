using System;
using ClientManager_Entities;

namespace ClientManager_DataModel
{
    public interface IUnitOfWork : IDisposable
    {
        

        IGenericRepository<EntityUserLogin> UserLoginRepository { get; }
        IGenericRepository<EntityPolicyHistory> PolicyHistoryRepository { get; }
      
        void Save();
    }
}