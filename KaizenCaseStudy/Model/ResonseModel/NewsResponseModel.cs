using System.Text.Json.Serialization;

namespace KaizenCaseStudy.Model
{
    public class NewsResponseModel
    {
        //[JsonIgnore]
        public string Name { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Category { get; set; }
        public string ImageUrls { get; set; }
    }
}
