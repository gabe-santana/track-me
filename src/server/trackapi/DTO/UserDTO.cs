using System.Collections.Generic;

namespace trackapi.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> TrackersIds { get; set; } 
    }
}