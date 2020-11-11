using MatrixVectorMathHelper.Controls;
using MatrixVectorMathHelper.Views;
using Notepad2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace MatrixVectorMathHelper.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public InputsViewModel Inputs { get; set; }

        public MathsViewModel Maths { get; set; }

        public ICommand SetMatrixFromActive { get; }
        public ICommand SetMatrixAsActive { get; }
        public ICommand SetVectorFromActive { get; }
        public ICommand SetVectorAsActive { get; }
        public ICommand ShowHelpCommand { get; }

        public MainViewModel()
        {
            Inputs = new InputsViewModel();
            Maths = new MathsViewModel();
            SetMatrixFromActive = new CommandParam<Matrix4ViewModel>(SetMatrixFromSelected);
            SetMatrixAsActive = new CommandParam<Matrix4ViewModel>(SetMatrixAsSelected);
            SetVectorFromActive = new CommandParam<Vector3ViewModel>(SetVectorFromSelected);
            SetVectorAsActive = new CommandParam<Vector3ViewModel>(SetVectorAsSelected);
            ShowHelpCommand = new Command(ShowHelp);
        }

        public void ShowHelp()
        {
            HelpWindow hw = new HelpWindow();
            hw.Show();
        }

        /// <summary>
        /// Sets a given matrix to the actively selected matrix in the <see cref="InputsViewModel"/>
        /// </summary>
        /// <param name="mat"></param>
        public void SetMatrixFromSelected(Matrix4ViewModel mat)
        {
            if (Inputs.IsMatrixSelected)
            {
                mat.Set(Inputs.SelectedMatrix.GetMatrix());
            }
        }

        /// <summary>
        /// Sets a given vector to the actively selected vector in the <see cref="InputsViewModel"/>
        /// </summary>
        /// <param name="vec"></param>
        public void SetVectorFromSelected(Vector3ViewModel vec)
        {
            if (Inputs.IsVectorSelected)
            {
                vec.Set(Inputs.SelectedVector.GetVector());
            }
        }

        /// <summary>
        /// Sets the actively selected matrix in the <see cref="InputsViewModel"/> to the given matrix
        /// </summary>
        /// <param name="mat"></param>
        public void SetMatrixAsSelected(Matrix4ViewModel mat)
        {
            if (Inputs.IsMatrixSelected)
            {
                Inputs.SelectedMatrix.Set(mat.GetMatrix());
            }
        }

        /// <summary>
        /// Sets the actively selected vector in the <see cref="InputsViewModel"/> to the given vector
        /// </summary>
        /// <param name="vec"></param>
        public void SetVectorAsSelected(Vector3ViewModel vec)
        {
            if (Inputs.IsVectorSelected)
            {
                Inputs.SelectedVector.Set(vec.GetVector());
            }
        }
    }
}
