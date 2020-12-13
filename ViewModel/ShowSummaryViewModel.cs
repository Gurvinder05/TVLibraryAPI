using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVLibraryAPI.ViewModel
{
    public class ShowSummaryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Platform { get; set; }
        public string Schedule { get; set; }
    }
}
