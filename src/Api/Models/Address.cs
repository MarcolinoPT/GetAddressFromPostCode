using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models
{
    public class Address
    {
        [Required]
        [FromQuery(Name = "postcode")]
        public string PostCode { get; set; }

        [FromQuery(Name = "housenumber")]
        public string Housenumber { get; set; }
    }
}
