using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebContentExtractor.Project.Filters;

namespace WebContentExtractor.Project.Models
{
    public class WebContentModel
    {
        [Required]
        [HttpsUrl]
        public string TargetUrl { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<KeyValuePair<string, int>> NumberOfWordsOccurence { get; set; }
        public int TotalWordCount { get; set; }
        public string ErrorMessage { get; set; }
    }
}