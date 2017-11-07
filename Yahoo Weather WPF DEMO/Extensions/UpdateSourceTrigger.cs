using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;


namespace Yahoo_Weather_WPF_DEMO
{
    public class UpdateSourceTrigger
    {
        private static UpdateSourceTrigger _Current;
        public static UpdateSourceTrigger Current
        {
            get
            {
                if (_Current == null) _Current = new UpdateSourceTrigger();
                return _Current;
            }
        }

        private ICommand _UpdateTextProperty;
        public ICommand UpdateTextProperty
        {
            get
            {
                return (_UpdateTextProperty == null) ? UpdateSourceInit() : _UpdateTextProperty;
            }
        }

        private ICommand UpdateSourceInit()
        {
            _UpdateTextProperty = new ActionCommand((object obj) =>
            {
                TextBox t = obj as TextBox;
                t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            });
            return _UpdateTextProperty;
        }
        class ActionCommand : System.Windows.Input.ICommand
        {
            private Action<object> _Action;

            public Action<object> Action { get { return _Action; } }

            public ActionCommand(Action<object> Action)
            {
                _Action = Action;
            }

            public bool CanExecute(object parameter)
            {
                return _Action != null;
            }

#pragma warning disable 0067
            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _Action?.Invoke(parameter);
            }
        }
    }
}
