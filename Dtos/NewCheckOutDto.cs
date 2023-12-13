using System.Collections.Generic;

namespace LibraryManager.Dtos
{
    public class NewCheckOutDto
    {
        public int CustomerId { get; set; }

        public IEnumerable<int> BookIds { get; set; }
    }
}