using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    class FileObject
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public FileObject(string name, string fullname)
        {
            Name = name;
            FullName = fullname;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
