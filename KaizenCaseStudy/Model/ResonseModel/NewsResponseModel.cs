using System.Text.Json.Serialization;

namespace KaizenCaseStudy.Model
{
    /// <summary>
    /// Haber cevap Modeli
    /// </summary>
    public class NewsResponseModel
    {
        //[JsonIgnore]
        /// <summary>
        /// Ad
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Başlık
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Detay
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// Kategori
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Resim Url'leri
        /// </summary>
        public string ImageUrls { get; set; }
    }
}
