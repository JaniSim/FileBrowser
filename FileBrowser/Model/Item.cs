using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace FileBrowser.Model
{
    internal class Item
    {
        internal string Name { get; }

        internal string Path { get; } 

        internal EType Type { get; } 

        internal Item(string path, EType type)
        {
            Path = path;
            Type = type;
            Name = GetName(path);
        }

        private string GetName(string path)
        {
            return Type switch
            {
                EType.File => System.IO.Path.GetFileName(path),
                EType.Folder => new DirectoryInfo(path).Name,
                _ => path
            };
        }
    }
}
