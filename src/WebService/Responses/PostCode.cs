using System.Collections.Generic;

namespace WebService.Responses
{ 
    public class PostCode
    {
        public ICollection<Adress> Addresses { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
