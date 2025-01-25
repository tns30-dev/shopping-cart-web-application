namespace SoftwareSellingCA.Models
{
    public class ProductSearchBrowse
    {
        public string UserFindTerm { get; set; }
        public List<Product> FoundResults { get; set;}
    }
}
