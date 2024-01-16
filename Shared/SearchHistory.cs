using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Shared
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string Filters { get; set; }

        public User User { get; set; }
    }
}
