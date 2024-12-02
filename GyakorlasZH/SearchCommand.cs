using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GyakorlasZH
{
    public class SearchCommand : ICommand
    {
        private DataModel _model;
        public SearchCommand(DataModel dataModel)
        {
            _model = dataModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_model.Brand) && !string.IsNullOrEmpty(_model.SelectedType);
        }


        public async void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                await _model.Search();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
