using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManager_DataModel;
using ClientManager_Entities;

namespace ClientManager_Services
{
    public class PolicyHistoryServices
    {
        private readonly UnitOfWork _uow;
      
        public PolicyHistoryServices()
        {
            _uow = new UnitOfWork();
        }

        //Gets the last instance that a specific policy ran.  Not the last policy to run.
        public EntityPolicyHistory GetLastPolicyRun(string policyHash)
        {
            return _uow.PolicyHistoryRepository.Get(x => x.PolicyHash == policyHash,q => q.OrderByDescending(t => t.Id)).FirstOrDefault();
        }

        //Gets the last instance that a specific policy ran.  Not the last policy to run.
        public EntityPolicyHistory GetLastPolicyRunForUser(string policyHash, string user)
        {
            return _uow.PolicyHistoryRepository.Get(x => x.PolicyHash == policyHash && x.Username == user, q => q.OrderByDescending(t => t.Id)).FirstOrDefault();
        }
    }
}
