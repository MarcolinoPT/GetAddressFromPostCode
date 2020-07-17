using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models
{
    public class Address
    {
        [Required]
        [FromQuery(Name = "postcode")]
        public string Postcode { get; set; }
    }
}
