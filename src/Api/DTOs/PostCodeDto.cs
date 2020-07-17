using System.Collections.Generic;

namespace FindAddresses.DTOs
{ 
    public class PostCodeDto
    {
        public List<Adress> Addresses { get; set; }
        public double DistanceInKm { get; set; }
        public double DistanceInMiles { get; set; }
    }
}
