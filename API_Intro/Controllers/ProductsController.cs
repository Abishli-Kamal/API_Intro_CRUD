using API_Intro.DAL;
using API_Intro.DTOs;
using API_Intro.DTOs.ProductsDtos;
using API_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id?}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _context.Products.Where(p => p.IsStatus == true).ToListAsync();
            //ProductGetAllDto model = new();
            //foreach (var item in products)
            //{
            //    ProductListItem listItem = new()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Price = item.Price,
            //    };
            //    model.ProductList.Add(listItem);
            //}


            //model.TotalCount = products.Count;
            ProductGetAllDto model = new()
            {
                ProductList = products.Select(p => new ProductListItem()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList(),

                TotalCount = products.Count
            };
            return Ok(model);
        }
        [HttpPost("create")]
        public IActionResult Create(ProductPostDto productdto)
        {
            Product product = new Product
            {
                Name = productdto.Name,
                Price = productdto.Price,
                IsStatus = productdto.IsStatus,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("update/{id?}")]
        public IActionResult Update(ProductPostDto productdto,int id)
        {
            Product existedproduct = _context.Products.Find(id);
            if (existedproduct == null) return NotFound();

            existedproduct.Name = productdto.Name;
            existedproduct.Price = productdto.Price;

            //_context.Entry(existedproduct).CurrentValues.SetValues(product);

            _context.SaveChanges();
            return Ok(existedproduct);
        }

        [HttpDelete("delete")]

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpPatch("status/{id}")]
        public IActionResult ChangeStatus(int id, string statusStr)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            bool status;
            bool result = bool.TryParse(statusStr, out status);

            if (!result) return BadRequest();


            product.IsStatus = status;
            _context.SaveChanges();
            return Ok();
        }
    }
}
