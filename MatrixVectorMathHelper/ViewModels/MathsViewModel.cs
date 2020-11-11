using Notepad2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMathHelper.ViewModels
{
    public class MathsViewModel : BaseViewModel
    {
        public MatrixCalculationsViewModel MatrixCalculations { get; set; }

        public MathsViewModel()
        {
            MatrixCalculations = new MatrixCalculationsViewModel();
        }
    }
}
