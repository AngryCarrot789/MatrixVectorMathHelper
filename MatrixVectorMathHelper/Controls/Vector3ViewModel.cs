using MatrixVectorMathHelper.Maths;
using Notepad2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMathHelper.Controls
{
    public class Vector3ViewModel : BaseViewModel
    {
        private float _x;
        public float X { get => _x; set => RaisePropertyChanged(ref _x, value); }

        private float _y;
        public float Y { get => _y; set => RaisePropertyChanged(ref _y, value); }

        private float _z;
        public float Z { get => _z; set => RaisePropertyChanged(ref _z, value); }

        private string _vectorName;
        public string VectorName { get => _vectorName; set => RaisePropertyChanged(ref _vectorName, value); }

        public Vector3ViewModel(string name = "vec name") { VectorName = name; }

        public Vector3ViewModel(float x, float y, float z, string name = "vec name")
        {
            Set(x, y, z);
            VectorName = name;
        }

        /// <summary>
        /// Creates a new copy of a <see cref="Vector3ViewModel"/> from an existing <see cref="Vector3ViewModel"/>
        /// </summary>
        /// <param name="vecVM"></param>
        public Vector3ViewModel(Vector3ViewModel vecVM, string name = "vec name")
        {
            X = vecVM.X;
            Y = vecVM.Y;
            Z = vecVM.Z;
            VectorName = name;
        }

        public void Set(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public void Set(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 GetVector()
        {
            return new Vector3(X, Y, Z);
        }
    }
}
