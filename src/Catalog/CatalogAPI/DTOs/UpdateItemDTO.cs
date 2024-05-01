using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CatalogApplication.DTOs;
using CatalogDomain.Entities;

namespace CatalogAPI.DTOs;

public class UpdateItemDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required(ErrorMessage = "{0} is Required")]
    public string Category { get; set; }
    protected internal Gender gender = Gender.Unisex;
    [Required]
    [JsonPropertyName("gender")]
    public string ItemGender
    {
        get => Enum.GetName(typeof(Gender), gender)!;
        set 
        {
            gender = value.ToLower() switch {
                "female" => Gender.Female,
                "male" => Gender.Male,
                _ => Gender.Unisex
            };
        }
    }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    [Required]
    [Range(5, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public decimal Price { get; set; }
    public List<SizeDTO> Sizes { get; set; }
    public List<Color> Colors { get; set; }
}