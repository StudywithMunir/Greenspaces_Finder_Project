using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Shared
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int GreenSpaceId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public User User { get; set; }
        public GreenSpace GreenSpace { get; set; }
    }
}
