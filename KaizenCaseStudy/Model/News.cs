using System.ComponentModel;

namespace KaizenCaseStudy.Model
{
    /// <summary>
    /// Haberler Model
    /// </summary>
    public class News
    {
        /// <summary>
        /// Dil
        /// </summary>
        public int Lang { get; set; }
        /// <summary>
        /// Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Detayı
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// Kategori
        /// </summary>
        public string Category { get; set; }
    }

}
