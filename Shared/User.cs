using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Shared
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LocationPreference { get; set; }

        public List<SearchHistory> SearchHistories { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
