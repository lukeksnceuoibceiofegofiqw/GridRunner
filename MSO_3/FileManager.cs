using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_3
{
    internal class FileManager
    {
        UIMediator med;
        internal FileManager()
        {

        }

        public string? OpenTextFile()
        {
            OpenFileDialog fd = new();
            fd.Filter = "Text files (*.txt)|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllText(fd.FileName);
            }
            return null;
        }



    }
}
