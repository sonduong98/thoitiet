using System.Collections.Generic;

namespace Models.Parameter
{
    public class ParameterViewModel : BaseViewModel
    {
        public ParameterViewModel()
        {
            ListParameters = new List<ParameterModel>();
        }

        public List<ParameterModel> ListParameters { get; set; }
    }
}
