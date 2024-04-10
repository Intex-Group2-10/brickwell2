namespace brickwell2.Models.ViewModels;

public class UserPagination
{
    public int TotalUsers { get; set; }
    public int UsersPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalNumPages => (int)(Math.Ceiling((decimal) TotalUsers / UsersPerPage));
}