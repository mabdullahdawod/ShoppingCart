using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Modal;
using ShoppingCartShared.Dbcontext;
using ShoppingCartShared.DTO;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public ProductController(ApDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        // Get all products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _dbContext.Products.Select(s => new ProductDTO()
            {
                ProductId = s.ProductId,
                ProductCategory = s.ProductCategory,
                ProductDescription = s.ProductDescription,
                ProductPrice = s.ProductPrice,
                Title = s.Title,
                ProductImgUrl = $"{Request.Scheme}://{Request.Host}/images/{s.ProductImg}"

            }).ToListAsync();
            return Ok(products);
        }

        // Get a product image
        [HttpGet("image/{filename}")]
        public IActionResult GetImage(string filename)
        {
            var path = Path.Combine(_env.WebRootPath, "images", filename);

            if (!System.IO.File.Exists(path))
                return NotFound();

            var contentType = "image/jpeg";
            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, contentType);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var path = Path.Combine(_env.WebRootPath, "images", product.ProductImg);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok(product);

        }


        [HttpPost()]
        public async Task<ActionResult<Product>> AddProduct(ProductDTO product)
        {
            if (product == null)
            {
                return NotFound();
            }
            if (product.File != null)
            {
                var modal = new Product()
                {
                    ProductCategory = product.ProductCategory,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    Title = product.Title,
                    ProductImg = Guid.NewGuid().ToString()+ product.File.FileName  ,
                };
               var path =  Path.Combine(_env.WebRootPath, "images", modal.ProductImg);
                
                if (!System.IO.File.Exists(path))
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await product.File.CopyToAsync(stream);
                    }

                }


                await _dbContext.Products.AddAsync(modal);
                await _dbContext.SaveChangesAsync();

                return Ok(product);
            }
            return BadRequest("File is required");
        }
    }
}
