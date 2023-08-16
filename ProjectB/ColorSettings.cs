using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class ColorSettings : ObservableObject
    {
        private string _colorHeader;

        public string ColorHeader { get => _colorHeader; set => SetProperty(ref _colorHeader, value); }
    }
}
