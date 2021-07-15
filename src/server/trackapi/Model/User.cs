using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using trackapi.Config;

namespace trackapi.Model
{
    [BsonCollection("User")]
    public class User : Document
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public IEnumerable<string> TrackersIds { get; set; } 
    }
}