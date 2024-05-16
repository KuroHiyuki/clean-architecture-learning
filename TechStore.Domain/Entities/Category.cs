namespace TechStore.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL {  get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
