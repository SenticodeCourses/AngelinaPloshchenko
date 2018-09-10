using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using linapl.CalculatorApp.Annotations;

namespace linapl.CalculatorApp
{
    public class MathOperation : INotifyPropertyChanged
    {
        private static double _firstDigit;
        private static double _secondDigit;
        private static string _mathSign;

        public double firstDigit
        {
            get => _firstDigit;
            set
            {
                _firstDigit = value;
                OnPropertyChanged();
            }
        }

        public double secondDigit
        {
            get => _secondDigit;
            set
            {
                if (_mathSign == "=")
                {
                    _firstDigit = 0;
                }
                _secondDigit = value;
                OnPropertyChanged();
            }
        }

        public string mathSign
        {
            get => _mathSign;
            set
            {
                _mathSign = value;
                OnPropertyChanged();
            }
        }

        Dictionary<string, Action> operationDictionary = new Dictionary<string, Action>()
        {
            {"+", Plus },
            {"-", Minus },
            {"/", Divide },
            {"*", Multipy }
        };

        private static void Plus()
        {
            _firstDigit += _secondDigit;
            _secondDigit = 0;
            _mathSign = "";
        }

        private static void Minus()
        {
            _firstDigit -= _secondDigit;
            _secondDigit = 0;
            _mathSign = "";
        }

        private static void Divide()
        {
            if (_secondDigit != 0)
            {
                _firstDigit /= _secondDigit;
            }
            else
            {
                _firstDigit = 0;
            }
            _secondDigit = 0;
            _mathSign = "";
        }

        private static void Multipy()
        {
            _firstDigit *= _secondDigit;
            _secondDigit = 0;
            _mathSign = "";
        }

        public void GoMathOperation()
        {
            if (operationDictionary.TryGetValue(_mathSign, out var method))
            {
                method();
            }
        }

        public void AddDigit(int i)
        {
            if (secondDigit != 0)
            {
                secondDigit *= 10;
            }
            secondDigit += i;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
