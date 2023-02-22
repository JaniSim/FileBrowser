using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBrowser.Model;

namespace FileBrowser.ViewModel
{
    public class FileStructureViewModel : BaseViewModel
    {
        public ObservableCollection<ItemViewModel> Drivers { get; set; }

        public FileStructureViewModel()
        {
            Drivers = new ObservableCollection<ItemViewModel>(FileStructure.GetDrivers().Select(item => new ItemViewModel(item.Name, item.Path, item.Type)));
        }
    }
}
