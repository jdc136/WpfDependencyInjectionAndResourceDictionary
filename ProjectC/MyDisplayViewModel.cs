using CommunityToolkit.Mvvm.ComponentModel;
using ProjectB;

namespace ProjectC
{
    public class MyDisplayViewModel : ObservableObject, IViewModel
    {
        public string MyIntro { get; set; } = "My Dynamic View/ViewModel";
    }
}
