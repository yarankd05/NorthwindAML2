using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;
using NorthwindAML.Web.Models;

namespace NorthwindAML.Web.Controllers.Api
{
    [ApiController]
    [Route("api/transactionflags")]
    public class TransactionFlagApiController : ControllerBase
    {
        private readonly ITransactionFlagRepository _flagRepo;
        private readonly ICustomerRiskScoreRepository _riskScoreRepo;
        private readonly NorthwindContext _context;

        public TransactionFlagApiController(
            ITransactionFlagRepository flagRepo,
            ICustomerRiskScoreRepository riskScoreRepo,
            NorthwindContext context)
        {
            _flagRepo = flagRepo;
            _riskScoreRepo = riskScoreRepo;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_flagRepo.GetAll());

        [HttpGet("{customerId}")]
        public IActionResult GetByCustomer(string customerId) =>
            Ok(_flagRepo.GetByCustomer(customerId));

        [HttpPost("scan")]
        public IActionResult Scan()
        {
            int threshold = 2000;
            var orders = _context.Database
                .SqlQueryRaw<OrderTotal>("SELECT o.OrderID, o.CustomerID, SUM(od.UnitPrice * od.Quantity) AS Total FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID GROUP BY o.OrderID, o.CustomerID")
                .ToList();

            int flagCount = 0;
            foreach (var order in orders)
            {
                if (order.Total > threshold)
                {
                    var existing = _context.TransactionFlags
                        .FirstOrDefault(f => f.OrderID == order.OrderID && f.FlagType == "LargeAmount");

                    if (existing == null)
                    {
                        _flagRepo.Add(new TransactionFlag
                        {
                            OrderID = order.OrderID,
                            CustomerID = order.CustomerID ?? string.Empty,
                            FlagType = "LargeAmount",
                            FlaggedDate = DateTime.Now
                        });

                        var score = _riskScoreRepo.GetByCustomer(order.CustomerID ?? string.Empty);
                        if (score != null)
                        {
                            score.Score += 10;
                            score.LastUpdated = DateTime.Now;
                            _riskScoreRepo.Update(score);
                        }
                        flagCount++;
                    }
                }
            }
            return Ok($"{flagCount} new flags added");
        }
    }
}