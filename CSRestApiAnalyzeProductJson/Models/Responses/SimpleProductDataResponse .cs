using System;
using System.Collections.Generic;

namespace CSRestApiAnalyzeProductJson.Models.Responses
{
    public class SimpleProductDataResponse 
    {
        public string datatype { get; set; }
        public List<SimpleProduct> products { get; set; }        
    }
}