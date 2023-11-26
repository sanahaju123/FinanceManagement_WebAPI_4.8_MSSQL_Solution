using FinanceManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinanceManagementApp.DAL.Services.Repository
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly DatabaseContext _dbContext;
        public FinanceRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Transaction> AddTransactions(Transaction transaction)
        {
            try
            {
                var result = _dbContext.Transactions.Add(transaction);
                await _dbContext.SaveChangesAsync();
                return transaction;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTransactionById(long id)
        {
            try
            {
                _dbContext.Transactions.Remove(_dbContext.Transactions.Single(a => a.TransactionId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Transaction> GetFinance()
        {
            try
            {
                var result = _dbContext.Transactions.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Transaction> GetTransactionById(long id)
        {
            try
            {
                return await _dbContext.Transactions.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Transaction> UpdateFinance(Transaction model)
        {
            var ex = await _dbContext.Transactions.FindAsync(model.TransactionId);
            try
            {
                ex.TransactionId = model.TransactionId;
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}