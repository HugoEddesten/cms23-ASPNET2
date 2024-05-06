using System.ComponentModel.DataAnnotations;

namespace AddressProvider.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public string StreetName { get; set; } = null!;

    [Required]
    public string StreetNumber { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

}
