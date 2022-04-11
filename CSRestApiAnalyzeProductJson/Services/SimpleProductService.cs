using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using CSRestApiAnalyzeProductJson.Models;
using CSRestApiAnalyzeProductJson.Models.Responses;
using System.Linq;

namespace CSRestApiAnalyzeProductJson.Services
{
    public static class SimpleProductService
    {
        ///<summary>Load JSON string from given URL</summary>
        public static List<SimpleProduct> FromUrl(string url){
            var urlContent = "";

            //TODO: check format of url

            //get data from url
            using(WebClient client = new WebClient()) {
                urlContent = client.DownloadString(url);
            }

            //check content            
            if(string.IsNullOrEmpty(urlContent)) throw new ArgumentException($"Url content is empty - please check url '{url}'");

            //TODO: validate json - more optional, will be done in deserialization

            //get object from json
            return _GetObject<List<SimpleProduct>>(urlContent);
        }

        ///<summary>Load JSON string from file</summary>
        public static List<SimpleProduct> FromFile(string filename){
            //load file content
            var content = File.ReadAllText(filename);

            //check for input
            if(string.IsNullOrEmpty(content)) throw new ArgumentException($"File content is empty - please check file '{filename}'");

            //TODO: validate json - more optional, will be done in deserialization

            //get object from json
            return _GetObject<List<SimpleProduct>>(content);
        }

        ///<summary>Convert JSON string to object</summary>
        private static T _GetObject<T>(string json){
            var result = default(T);            

            //check for input
            if(string.IsNullOrEmpty(json)) throw new ArgumentException("Value is empty or null", "json");

            result = JsonSerializer.Deserialize<T>(json);
            return result;
        }

        ///<summary>Get two products - one with the lowest and one with the highest price per litre</summary>
        public static List<SimpleProductDataResponse> GetPriceLowHighPerLitre(List<SimpleProduct> products){
            var result = new List<SimpleProductDataResponse>();
            
            //get cheapest and add to result
            var cheapProduct = products.OrderBy(x => x.articles.Min(y => y.pricePerUnit)).FirstOrDefault();            
            result.Add(new SimpleProductDataResponse{ datatype = "CheapestProductPerLitre", products = new List<SimpleProduct>(){cheapProduct}});            

            //get most expensive
            var expensiveProduct = products.OrderBy(x => x.articles.Max(y => y.pricePerUnit)).FirstOrDefault();     
            result.Add(new SimpleProductDataResponse{ datatype = "MostExpensiveProductPerLitre", products = new List<SimpleProduct>(){expensiveProduct}});
         
            return result;
        }

        ///<summary>Filter given products price and order the result by price per unit (price per litre)</summary>
        public static List<SimpleProductDataResponse> GetByPrice(List<SimpleProduct> products, decimal price){
            var result = new List<SimpleProductDataResponse>();
            
            //match on given price and return products
            var priceProducts = products.Where(x => x.articles.Where(y => y.price == price).Any()).OrderBy(x => x.articles.Min(y => y.pricePerUnit)).ToList();
            result.Add(new SimpleProductDataResponse{ datatype = "ByPrice", products = priceProducts});            

            return result;
        }

        ///<summary>Filter given products by max packaging-unit and return only them</summary>
        public static List<SimpleProductDataResponse> GetMostPackagingCount(List<SimpleProduct> products){
            var result = new List<SimpleProductDataResponse>();
            
            //get the max packaging count and the products
            var maxPackagingCount = products.OrderByDescending(x => x.articles.Max(y => y.midPackagingCount)).FirstOrDefault().articles.Max(y => y.midPackagingCount);
            var mostPackagingProducts = products.Where(x => x.articles.Where(y => y.midPackagingCount == maxPackagingCount).Any()).OrderBy(x => x.articles.Min(y => y.pricePerUnit)).ToList();    
            result.Add(new SimpleProductDataResponse{ datatype = "MostPackagingCount", products = mostPackagingProducts});            

            return result;
        }
    }
}