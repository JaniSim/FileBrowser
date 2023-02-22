using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FileBrowser.Model;
using Type = System.Type;

namespace FileBrowser.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        public string Name { get; }

        private string Path { get; } 

        private EType Type { get; } 

        public ObservableCollection<ItemViewModel> Children { get; set; }

        public ICommand ExpandCommand { get; set; }

        public bool IsExpanded
        {
            get => HasChildren();
            set
            {
                Children.Clear();
                if (value)
                {
                    Expand();
                }
                else
                {
                    ClearFolderChildren();
                }

            }
        }

        internal ItemViewModel(string name, string path, EType type)
        {
            Name = name;
            Path = path;
            Type = type;
            ExpandCommand = new RelayCommand(Expand);
            Children = new();
            if (Type is not EType.File)
            {
                ClearFolderChildren();
            }
        }

        private void Expand()
        {
            foreach (var item in FileStructure.GetChildren(Path, Type).Select(item => new ItemViewModel(item.Name, item.Path, item.Type)))
            {
                Children.Add(item);
            }
        }

        private bool HasChildren()
        {
            if (Children.Count == 1 && string.IsNullOrEmpty(Children.First().Path))
            {
                return false;
            }
            return Children.Any();
        }

        private void ClearFolderChildren()
        {
            Children.Add(new ItemViewModel("", "", EType.File));
        }
    }
}
