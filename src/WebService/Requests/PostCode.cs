using System.Collections.Generic;

namespace WebService.Requests
{ 
    public class PostCodeDto
    {
        public ICollection<Adress> Addresses { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
