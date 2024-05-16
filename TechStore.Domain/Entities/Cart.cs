namespace TechStore.Domain.Entities
{
    public class Cart
    {
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
        public int VolumeProduct { get; set; }

    }
}
