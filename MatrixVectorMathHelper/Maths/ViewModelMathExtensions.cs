using MatrixVectorMathHelper.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMathHelper.Maths
{
    /// <summary>
    /// Converts viewmodels like Vector3ViewMode into a Vector3
    /// </summary>
    public static class ViewModelMathExtensions
    {
        public static Vector3 FromViewModel(this Vector3ViewModel vm)
        {
            return new Vector3(vm.X, vm.Y, vm.Z);
        }

        public static Vector3ViewModel ToViewModel(this Vector3 v)
        {
            return new Vector3ViewModel(v.X, v.Y, v.Z);
        }


    }
}
