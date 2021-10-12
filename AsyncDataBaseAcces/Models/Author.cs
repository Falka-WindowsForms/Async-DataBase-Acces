using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataBaseAcces.Models
{
    internal class Author
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int BooksCount { get; set; }
    }
}
