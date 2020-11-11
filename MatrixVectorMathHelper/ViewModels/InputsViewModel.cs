using MatrixVectorMathHelper.Controls;
using MatrixVectorMathHelper.Maths;
using Notepad2.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MatrixVectorMathHelper.ViewModels
{
    public class InputsViewModel : BaseViewModel
    {
        public ObservableCollection<Vector3ViewModel> Vectors { get; set; }

        private Vector3ViewModel _selectedVector;
        public Vector3ViewModel SelectedVector
        {
            get => _selectedVector; 
            set => RaisePropertyChanged(ref _selectedVector, value);
        }

        public Vector3ViewModel InputVector { get; set; }

        public ObservableCollection<Matrix4ViewModel> Matrixes { get; set; }

        private Matrix4ViewModel _selectedMatrix;
        public Matrix4ViewModel SelectedMatrix
        {
            get => _selectedMatrix;
            set => RaisePropertyChanged(ref _selectedMatrix, value);
        }

        public Matrix4ViewModel InputMatrix { get; set; }

        public ICommand SetInputMatrixContentsCommand { get; }
        public ICommand AddVectorFromInputCommand { get; }
        public ICommand RemoveSelectedVectorCommand { get; }
        public ICommand ClearVectorsCommand { get; }
        public ICommand AddMatrixFromInputCommand { get; }
        public ICommand RemoveSelectedMatrixCommand { get; }
        public ICommand ClearMatrixesCommand { get; }

        public InputsViewModel()
        {
            Vectors = new ObservableCollection<Vector3ViewModel>();
            Matrixes = new ObservableCollection<Matrix4ViewModel>();
            InputVector = new Vector3ViewModel(0, 0, 0);
            InputMatrix = new Matrix4ViewModel(Matrix4.Zero());

            SetInputMatrixContentsCommand = new CommandParam<string>(SetInputMatrixContents);
            AddVectorFromInputCommand = new Command(AddVectorFromInput);
            RemoveSelectedVectorCommand = new Command(RemoveSelectedVector);
            ClearVectorsCommand = new Command(ClearVectors);
            AddMatrixFromInputCommand = new Command(AddMatrixFromInput);
            RemoveSelectedMatrixCommand = new Command(RemoveSelectedMatrix);
            ClearMatrixesCommand = new Command(ClearMatrixes);
        }

        public void SetInputMatrixContents(string contentsCode)
        {
            switch (contentsCode)
            {
                case "i": InputMatrix.Set(Matrix4.Identity()); break;
                case "z": InputMatrix.Set(Matrix4.Zero()); break;
            }
        }

        public void AddVectorFromInput()
        {
            Vectors.Add(new Vector3ViewModel(InputVector, $"Vector {Matrixes.Count + 1}"));
        }

        public void AddMatrixFromInput()
        {
            Matrixes.Add(new Matrix4ViewModel(InputMatrix, $"Matrix {Matrixes.Count + 1}"));
        }

        public void RemoveSelectedVector()
        {
            if (IsVectorSelected)
            {
                Vectors.Remove(SelectedVector);
            }
        }

        public void RemoveSelectedMatrix()
        {
            if (IsMatrixSelected)
            {
                Matrixes.Remove(SelectedMatrix);
            }
        }

        public void ClearVectors()
        {
            Vectors.Clear();
            SelectedVector = null;
        }

        public void ClearMatrixes()
        {
            Matrixes.Clear();
            SelectedMatrix = null;
        }

        public bool IsVectorSelected => Vectors.Count > 0 && SelectedVector != null;
        public bool IsMatrixSelected => Matrixes.Count > 0 && SelectedMatrix != null;
    }
}
