using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRestApiAnalyzeProductJson.Models;
using CSRestApiAnalyzeProductJson.Models.Responses;
using CSRestApiAnalyzeProductJson.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSRestApiAnalyzeProductJson.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class SimpleProductsController : ControllerBase
    {     
        private readonly ILogger<TestController> _logger;

        public SimpleProductsController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("high-low-perlitre")]            
        ///<summary>Get products with the highest and lowest price per litre. In the response the datatype will be 'CheapestProductPerLitre' or 'MostExpensiveProductPerLitre'</summary        
        ///<param name="url">URL to json-file with product list that will be used for calculation</param>
        public IActionResult GetHighLowPerLitre(string url = "https://raw.githubusercontent.com/fabian-lauer/example-tasks/main/CSRestApiAnalyzeProductJson/Docs/ProductData.json")
        {
            var result = new SimpleProductResponse(){ success = true};

            try{
                var products =  SimpleProductService.FromUrl(url);
                result.data = SimpleProductService.GetPriceLowHighPerLitre(products);
                
            }catch(Exception ex){
                result.message = $"An exception occord - {ex.Message}"                ;
                result.success = false;
            }
            

            return result.success ? Ok(result) : BadRequest( result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("by-price")]        
        ///<summary>Get all products for a given price. In the response the datatype will be 'ByPrice'</summary        
        ///<param name="url">URL to json-file with product list that will be used for calculation</param>
        ///<param name="price">Price with dot as decimal separator used for filtering of products</param>
        public IActionResult GetByPrice(string url = "https://raw.githubusercontent.com/fabian-lauer/example-tasks/main/CSRestApiAnalyzeProductJson/Docs/ProductData.json", decimal price = 17.99M)
        {
            var result = new SimpleProductResponse(){ success = true};

            try{
                var products =  SimpleProductService.FromUrl(url);
                result.data = SimpleProductService.GetByPrice(products, price);
                
            }catch(Exception ex){
                result.message = $"An exception occord - {ex.Message}"                ;
                result.success = false;
            }
            

            return result.success ? Ok(result) : BadRequest( result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("most-packaging-count")]   
        ///<summary>Returns the products with the max packaging-unit included in the product-data-file. In the response the datatype will be 'MostPackagingCount'</summary        
        ///<param name="url">URL to json-file with product list that will be used for calculation</param>   
        public IActionResult GetMostPackagingCount(string url = "https://raw.githubusercontent.com/fabian-lauer/example-tasks/main/CSRestApiAnalyzeProductJson/Docs/ProductData.json")
        {
            var result = new SimpleProductResponse(){ success = true};

            try{
                var products =  SimpleProductService.FromUrl(url);
                result.data = SimpleProductService.GetMostPackagingCount(products);
                
            }catch(Exception ex){
                result.message = $"An exception occord - {ex.Message}"                ;
                result.success = false;
            }
            

            return result.success ? Ok(result) : BadRequest( result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("bundled-info")]        
        ///<summary>Special-call, will return all results as a combination of the above 3 routes</summary        
        ///<param name="url">URL to json-file with product list that will be used for calculation</param>   
        public IActionResult GetAll(string url = "https://raw.githubusercontent.com/fabian-lauer/example-tasks/main/CSRestApiAnalyzeProductJson/Docs/ProductData.json")
        {
            var result = new SimpleProductResponse(){ success = true, data = new List<SimpleProductDataResponse>()};

            try{
                //first the product list
                var products =  SimpleProductService.FromUrl(url);

                //price - high/low
                result.data.AddRange( SimpleProductService.GetPriceLowHighPerLitre(products));

                //fixed price 17.00
                result.data.AddRange( SimpleProductService.GetByPrice(products, 17.99M));

                //Packaging stuff
                result.data.AddRange( SimpleProductService.GetMostPackagingCount(products));
                
            }catch(Exception ex){
                result.message = $"An exception occord - {ex.Message}"                ;
                result.success = false;
            }
            

            return result.success ? Ok(result) : BadRequest( result);
        }
    }
}
