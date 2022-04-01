using MedicineDB.ViewModels.Base;

namespace MedicineDB.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "MedicineDb";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
