using System.Collections.Generic;

namespace KaizenCaseStudy
{
    /// <summary>
    /// Genel cevap modeli
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneralResponseModel<T>
    {
        public GeneralResponseModel()
        {
            IsSuccess = false;
            ErrorMessages = new List<string>() { "An error occured!" };
        }
        /// <summary>
        /// İstek başarılımı?
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Hata mesajları
        /// </summary>
        public List<string> ErrorMessages { get; set; }
        /// <summary>
        /// Veri
        /// </summary>
        public T Data { get; set; }
    }
}
