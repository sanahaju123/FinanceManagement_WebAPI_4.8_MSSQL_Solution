using FinanceManagementApp.DAL.Interrfaces;
using FinanceManagementApp.DAL.Services.Repository;
using FinanceManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinanceManagementApp.DAL.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _repository;

        public FinanceService(IFinanceRepository repository)
        {
            _repository = repository;
        }

        public Task<Transaction> AddTransactions(Transaction transaction)
        {
            return _repository.AddTransactions(transaction);
        }

        public Task<bool> DeleteTransactionById(long id)
        {
            return _repository.DeleteTransactionById(id);
        }

        public List<Transaction> GetFinance()
        {
            return _repository.GetFinance();
        }

        public Task<Transaction> GetTransactionById(long id)
        {
            return _repository.GetTransactionById(id); ;
        }

        public Task<Transaction> UpdateFinance(Transaction model)
        {
            return _repository.UpdateFinance(model);
        }
    }
}