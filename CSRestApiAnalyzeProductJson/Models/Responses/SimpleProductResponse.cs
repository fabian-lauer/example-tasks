using System;
using System.Collections.Generic;

namespace CSRestApiAnalyzeProductJson.Models.Responses
{
    public class SimpleProductResponse: GeneralResponse
    {
        public List<SimpleProductDataResponse> data { get; set; }        
    }
}