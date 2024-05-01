using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.DTOs;

public class ColorDTO
{
    [FromForm(Name = "Color")]
    public string Color { get; set; }
    [FromForm(Name = "File")]
    public IFormFile File { get; set; }
}