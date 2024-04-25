using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoginApp.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        public bool _isbusy;
        [ObservableProperty]
        public string _title;
    }
}
