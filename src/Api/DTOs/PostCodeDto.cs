using System.Collections.Generic;

namespace FindAddresses.DTOs
{ 
    public class PostCodeDto
    {
        public List<Adress> Addresses { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
