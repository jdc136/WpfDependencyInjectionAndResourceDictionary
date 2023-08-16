using CommunityToolkit.Mvvm.ComponentModel;
using ProjectB;

namespace ProjectA
{
    public class MainViewModel : ObservableObject
    {
        public IViewModel CurrentViewModel { get; set; }

        public MainViewModel(IViewModel viewModel)
        {
            CurrentViewModel = viewModel;
        }

    }
}
