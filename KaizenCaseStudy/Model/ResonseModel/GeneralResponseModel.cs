using System.Collections.Generic;

namespace KaizenCaseStudy
{
    public class GeneralResponseModel<T>
    {
        public GeneralResponseModel()
        {
            IsSuccess = false;
            ErrorMessages = new List<string>() { "An error occured!" };
        }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public T Data { get; set; }
    }
}
