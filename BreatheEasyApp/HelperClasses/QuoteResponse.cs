using System.Collections.Generic;

namespace BreatheEasyApp.HelperClasses
{
    public class QuoteResponse
    {
        public Success Success { get; set; }
        public Contents Contents { get; set; }
    }

    public class Success
    {
        public string Total { get; set; }
    }

    public class Contents
    {
        public List<QuoteContent> Quotes { get; set; }
        public string Copyright { get; set; }
    }
        
    public class QuoteContent
    {
        public string Quote { get; set; }
        //public int Length { get; set; }
        public string Author { get; set; }
        //public string Background { get; set; }
        //public string PermaLink { get; set; }
      
    
    }
}