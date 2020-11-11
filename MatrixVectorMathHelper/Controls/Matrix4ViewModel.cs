using MatrixVectorMathHelper.Maths;
using Notepad2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MatrixVectorMathHelper.Controls
{
    /// <summary>
    /// M00 = top left, M33 = bottom right. M30 = top right, M03 = bottom left.
    /// <para>
    /// M(Row)(Colum)
    /// </para>
    /// </summary>
    public class Matrix4ViewModel : BaseViewModel
    {
        private float _m00;
        private float _m10;
        private float _m20;
        private float _m30;
        private float _m01;
        private float _m11;
        private float _m21;
        private float _m31;
        private float _m02;
        private float _m12;
        private float _m22;
        private float _m32;
        private float _m03;
        private float _m13;
        private float _m23;
        private float _m33;
        private string _matrixName;

        public float M00 { get => _m00; set => RaisePropertyChanged(ref _m00, value); }
        public float M10 { get => _m10; set => RaisePropertyChanged(ref _m10, value); }
        public float M20 { get => _m20; set => RaisePropertyChanged(ref _m20, value); }
        public float M30 { get => _m30; set => RaisePropertyChanged(ref _m30, value); }
        public float M01 { get => _m01; set => RaisePropertyChanged(ref _m01, value); }
        public float M11 { get => _m11; set => RaisePropertyChanged(ref _m11, value); }
        public float M21 { get => _m21; set => RaisePropertyChanged(ref _m21, value); }
        public float M31 { get => _m31; set => RaisePropertyChanged(ref _m31, value); }
        public float M02 { get => _m02; set => RaisePropertyChanged(ref _m02, value); }
        public float M12 { get => _m12; set => RaisePropertyChanged(ref _m12, value); }
        public float M22 { get => _m22; set => RaisePropertyChanged(ref _m22, value); }
        public float M32 { get => _m32; set => RaisePropertyChanged(ref _m32, value); }
        public float M03 { get => _m03; set => RaisePropertyChanged(ref _m03, value); }
        public float M13 { get => _m13; set => RaisePropertyChanged(ref _m13, value); }
        public float M23 { get => _m23; set => RaisePropertyChanged(ref _m23, value); }
        public float M33 { get => _m33; set => RaisePropertyChanged(ref _m33, value); }
        public string MatrixName { get => _matrixName; set => RaisePropertyChanged(ref _matrixName, value); }

        public Matrix4ViewModel(string name = "mat name")
        {
            MatrixName = name;
        }

        public Matrix4ViewModel(Matrix4 mat, string name = "mat name")
        {
            Set(mat);
            MatrixName = name;
        }

        public Matrix4ViewModel(Matrix4ViewModel vm, string name = "mat name")
        {
            Set(vm);
            MatrixName = name;
        }

        public void Set(Matrix4 m)
        {
            M00 = m.M[0];  M10 = m.M[1];  M20 = m.M[2];  M30 = m.M[3];
            M01 = m.M[4];  M11 = m.M[5];  M21 = m.M[6];  M31 = m.M[7];
            M02 = m.M[8];  M12 = m.M[9];  M22 = m.M[10]; M32 = m.M[11];
            M03 = m.M[12]; M13 = m.M[13]; M23 = m.M[14]; M33 = m.M[15];
        }

        public void Set(Matrix4ViewModel vm)
        {
            M00 = vm.M00; M10 = vm.M10; M20 = vm.M20; M30 = vm.M30;
            M01 = vm.M01; M11 = vm.M11; M21 = vm.M21; M31 = vm.M31;
            M02 = vm.M02; M12 = vm.M12; M22 = vm.M22; M32 = vm.M32;
            M03 = vm.M03; M13 = vm.M13; M23 = vm.M23; M33 = vm.M33;
        }

        public Matrix4 GetMatrix()
        {
            Matrix4 m = new Matrix4();
            m.M[0]  = M00; m.M[1]  = M10; m.M[2]  = M20; m.M[3]  = M30;
            m.M[4]  = M01; m.M[5]  = M11; m.M[6]  = M21; m.M[7]  = M31;
            m.M[8]  = M02; m.M[9]  = M12; m.M[10] = M22; m.M[11] = M32;
            m.M[12] = M03; m.M[13] = M13; m.M[14] = M23; m.M[15] = M33;
            return m;
        }

        public static Matrix4ViewModel GetMatrixVM(Matrix4 m)
        {
            Matrix4ViewModel mvm = new Matrix4ViewModel(m);
            return mvm;
        }
    }
}
