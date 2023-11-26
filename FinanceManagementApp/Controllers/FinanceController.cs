using FinanceManagementApp.DAL.Interrfaces;
using FinanceManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinanceManagementApp.Controllers
{
    public class FinanceController : ApiController
    {
        private readonly IFinanceService _service;
        public FinanceController(IFinanceService service)
        {
            _service = service;
        }
        public FinanceController()
        {
            // Constructor logic, if needed
        }

        [HttpPost]
        [Route("api/Finance/CreateTransaction")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateTransaction([FromBody] Transaction model)
        {
            var leaveExists = await _service.GetTransactionById(model.TransactionId);
            var result = await _service.AddTransactions(model);
            return Ok(new Response { Status = "Success", Message = "Transaction created successfully!" });
        }


        [HttpPut]
        [Route("api/Finance/UpdateTransaction")]
        public async Task<IHttpActionResult> UpdateTransaction([FromBody] Transaction model)
        {
            var result = await _service.UpdateFinance(model);
            return Ok(new Response { Status = "Success", Message = "Transaction updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Finance/DeleteTransaction")]
        public async Task<IHttpActionResult> DeleteTransaction(long id)
        {
            var result = await _service.DeleteTransactionById(id);
            return Ok(new Response { Status = "Success", Message = "Transaction deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Finance/GetTransactionById")]
        public async Task<IHttpActionResult> GetTransactionById(long id)
        {
            var expense = await _service.GetTransactionById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Finance/GetAllTransactions")]
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return _service.GetFinance();
        }
    }
}
