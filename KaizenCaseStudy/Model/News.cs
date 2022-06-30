using System.ComponentModel;

namespace KaizenCaseStudy.Model
{
    public class News
    {
        public Lang Lang { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Category { get; set; }
    }
    public enum Lang
    {
        [Description("Türkçe")]
        TR = 1,
        [Description("English")]
        EN = 2
    }
}
