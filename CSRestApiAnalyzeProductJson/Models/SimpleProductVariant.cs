using System;
using System.Text.RegularExpressions;

namespace CSRestApiAnalyzeProductJson.Models
{
    public class SimpleProductVariant
    {
        private string _pricePerUnitText;
        private string _shortDescription;

        public int id { get; set; }
        public string shortDescription { 
             get { return _shortDescription; }
            set {
                _shortDescription = value; 

                //try with regex to set pricePerUnit                
                var pattern = @"^(\d{1,}) x (\d[.,]*\d*)(.*) \((.*)\)$";
                var puRegex = new Regex(pattern);

                //only set if we have a match
                if(puRegex.IsMatch(_shortDescription)){
                    var puMatches = puRegex.Matches(_shortDescription);
                    if(puMatches != null && puMatches.Count > 0 && puMatches[0].Groups.Count >= 5) {
                        
                        this.midPackagingCount = decimal.Parse(puMatches[0].Groups[1].ToString());
                        this.midPackagingUnit = "PCE";
                        this.smallestPackagingCount = decimal.Parse(puMatches[0].Groups[2].ToString());
                        this.smallestPackagingUnit = puMatches[0].Groups[3].ToString();
                        this.smallestPackagingUnitType = puMatches[0].Groups[4].ToString();
                    }
                }else{
                    this.midPackagingCount = 1;
                    this.midPackagingUnit = "PCE";
                    this.smallestPackagingCount = 1;
                    this.smallestPackagingUnit = "PCE";
                    this.smallestPackagingUnitType= "";
                } 
            }
        }
        public decimal price { get; set; }
        public string unit { get; set; }
        
        public string pricePerUnitText        
        {
            get { return _pricePerUnitText; }
            set {
                _pricePerUnitText = value; 

                //try with regex to set pricePerUnit                
                var pattern = @"^\((\d[.,]*\d*) €/(.*)\)$";
                var ppuRegex = new Regex(pattern);

                //only set if we have a match
                if(ppuRegex.IsMatch(_pricePerUnitText)){
                    var ppuMatches = ppuRegex.Matches(_pricePerUnitText);
                    if(ppuMatches != null && ppuMatches.Count > 0 && ppuMatches[0].Groups.Count > 1) {
                        decimal output;
                        //TODO: check culture and datasource!!!
                        //Could cause problems
                        if(Decimal.TryParse(ppuMatches[0].Groups[1].ToString(), out output)) {
                            this.pricePerUnit = output;
                        }else{
                            this.pricePerUnit = null;
                        }
                    }
                }else{
                    this.pricePerUnit = null;
                }                
            }
        }
        
        public decimal? pricePerUnit { get; private set; } 
        public decimal midPackagingCount  { get; private set; }
        public string midPackagingUnit  { get; private set; }
        public decimal smallestPackagingCount  { get; private set; }
        public string smallestPackagingUnit  { get; private set; }
        public string smallestPackagingUnitType  { get; private set; }
        public string image { get; set; }        

        
    }
}