using MatrixVectorMathHelper.Controls;
using MatrixVectorMathHelper.Maths;
using Notepad2.Utilities;
using System.Windows.Input;

namespace MatrixVectorMathHelper.ViewModels
{
    public class MatrixCalculationsViewModel : BaseViewModel
    {
        public Matrix4ViewModel DotProductInput1 { get; set; }
        public Matrix4ViewModel DotProductInput2 { get; set; }
        public Matrix4ViewModel DotProductOutput { get; set; }

        public Matrix4ViewModel RotationMatrixInput { get; set; }
        public Vector3ViewModel RotationXInput { get; set; }
        public Vector3ViewModel RotationYInput { get; set; }
        public Vector3ViewModel RotationZInput { get; set; }
        public Matrix4ViewModel RotationMatrixOutput { get; set; }




        public ICommand CalculateDotProductCommand { get; }
        public ICommand CalculateRotationCommand { get; }

        public MatrixCalculationsViewModel()
        {
            DotProductInput1 = new Matrix4ViewModel();
            DotProductInput2 = new Matrix4ViewModel();
            DotProductOutput = new Matrix4ViewModel();
            RotationMatrixInput = new Matrix4ViewModel();
            RotationXInput = new Vector3ViewModel();
            RotationYInput = new Vector3ViewModel();
            RotationZInput = new Vector3ViewModel();
            RotationMatrixOutput = new Matrix4ViewModel();
            CalculateDotProductCommand = new Command(CalculateDotProduct);
            CalculateRotationCommand = new CommandParam<string>(CalculateRotation);
        }

        public void CalculateDotProduct()
        {
            DotProductOutput.Set(MultiplyMatrixByMatrix(DotProductInput1, DotProductInput2));
        }

        public void CalculateRotation(string axis)
        {
            switch (axis)
            {
                case "x": RotationMatrixOutput.Set(RotateX(RotationMatrixInput, RotationXInput)); break;
                case "y": RotationMatrixOutput.Set(RotateY(RotationMatrixInput, RotationXInput)); break;
                case "z": RotationMatrixOutput.Set(RotateZ(RotationMatrixInput, RotationXInput)); break;
            }
        }

        public static Matrix4ViewModel MultiplyMatrixByMatrix(Matrix4ViewModel a, Matrix4ViewModel m)
        {
            return new Matrix4ViewModel(a.GetMatrix() * m.GetMatrix());
        }

        public static Matrix4ViewModel RotateX(Matrix4ViewModel a, Vector3ViewModel b)
        {
            Matrix4 rot = a.GetMatrix() * Matrix4.RotateX(b.X);
            return new Matrix4ViewModel(rot);
        }

        public static Matrix4ViewModel RotateY(Matrix4ViewModel a, Vector3ViewModel b)
        {
            Matrix4 rot = a.GetMatrix() * Matrix4.RotateY(b.Y);
            return new Matrix4ViewModel(rot);
        }

        public static Matrix4ViewModel RotateZ(Matrix4ViewModel a, Vector3ViewModel b)
        {
            Matrix4 rot = a.GetMatrix() * Matrix4.RotateZ(b.Z);
            return new Matrix4ViewModel(rot);
        }
    }
}
