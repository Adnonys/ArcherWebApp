using System.Collections.Generic;

namespace ArcheryWebApp.Models
{
    public class ArcherListViewModel
    {
        public IEnumerable<Archer> Archers   { get; set; }
        public string SearchTerm             { get; set; }
        public int PageNumber                { get; set; }
        public int TotalPages                { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage     => PageNumber < TotalPages;
    }
}