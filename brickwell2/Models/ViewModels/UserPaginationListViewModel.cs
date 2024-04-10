namespace brickwell2.Models.ViewModels;

public class UserPaginationListViewModel
{
    public IQueryable<Customer> Customers { get; set; }
    public UserPagination UserPagination { get; set; } = new UserPagination();

}