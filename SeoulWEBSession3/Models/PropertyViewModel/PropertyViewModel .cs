namespace SeoulWEBSession3.Models.PropertyViewModel
{
    public class PropertyViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Area { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = "default.jpg";
    }

    public class PropertyDetailsViewModel
    {
        public string Title { get; set; }
        public string Area { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string Description { get; set; }
        public string HostRules { get; set; }
        public List<string> Amenities { get; set; } = new List<string>();
        public List<string> Images { get; set; } = new List<string>();
        public decimal Price { get; set; }
    }
}


