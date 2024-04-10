namespace brickwell2.Models.ViewModels
{
    public class PaginationListViewModel
    {
        public IQueryable<Product>? Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo(); 

        public string? CurrentItemType { get; set; }
    }
}
