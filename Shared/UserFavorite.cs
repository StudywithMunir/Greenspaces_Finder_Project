using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Shared
{
    public class UserFavorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int GreenSpaceId { get; set; }
        public DateTime DateAdded { get; set; }

        public User User { get; set; }
        public GreenSpace GreenSpace { get; set; }
    }
}
