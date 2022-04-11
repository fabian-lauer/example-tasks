using System;
using System.Collections.Generic;

namespace CSRestApiAnalyzeProductJson.Models
{
    public class SimpleProduct
    {
        public int id { get; set; }
        public string brandName { get; set; }
        public string name { get; set; }
        public List<SimpleProductVariant> articles { get; set; }
    }
}