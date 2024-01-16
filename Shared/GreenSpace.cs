using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Shared
{
    public class GreenSpace
    {
        [Key]
        public int GreenSpaceId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public string Facilities { get; set; }

        public List<SearchHistory> SearchHistories { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
