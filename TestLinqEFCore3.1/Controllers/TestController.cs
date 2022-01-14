using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLinqEFCore3._1.Db;

namespace TestLinqEFCore3._1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _context;

        public TestController(ILogger<TestController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _context.Categories.Join(_context.ProductTypes,
                category => category.Id,
                productType => productType.Product.CategoryId,
                (c, pt) =>
                new
                {
                    Category = c,
                    ProductType = pt
                })
                .GroupBy(e => e.Category)
                .Select(e => new
                {
                    Category = e.Key,
                    ProductTypes = e.Select(e => e.ProductType)
                }).ToList();
            return Ok(result);
        }
    }
}
