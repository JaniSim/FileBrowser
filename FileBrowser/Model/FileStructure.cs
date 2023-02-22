using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Model
{
    internal class FileStructure
    {
        internal static IEnumerable<Item> GetDrivers()
        {
            return Directory.GetLogicalDrives().Select(driver => new Item(driver, EType.Driver));
        }

        internal static IEnumerable<Item> GetChildren(string path, EType type)
        {
            if (type is EType.File)
            {
                return Enumerable.Empty<Item>();
            }

            try
            {
                var dirs = Directory.GetDirectories(path).Select(dir => new Item(dir, EType.Folder));
                var files = Directory.GetFiles(path).Select(file => new Item(file, EType.File));
                return dirs.Concat(files);
            }
            catch
            {
                return new List<Item>() { new Item("Access denied", EType.File) };
            }
        }
    }
}
