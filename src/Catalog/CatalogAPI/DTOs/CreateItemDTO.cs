using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CatalogApplication.DTOs;
using CatalogDomain.Entities;
using Microsoft.OpenApi.Extensions;

namespace CatalogAPI.DTOs;

public class CreateItemDTO
{
    [Required]
    public string Name { get; set; }
    [Required(ErrorMessage = "{0} is Required")]
    public string Category { get; set; }
    
    protected internal Gender gender = Gender.Unisex;
    [Required]
    [JsonPropertyName("gender")]
    [JsonConverter(typeof(JsonStringEnumConverter<Gender>))]
    public Gender ItemGender { get; set; }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    [Required]
    [Range(5, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public decimal Price { get; set; }
    public List<SizeDTO> Sizes { get; set; }
}