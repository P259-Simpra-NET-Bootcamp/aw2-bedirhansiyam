using Aw2.Base.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aw2.Data.Domains;

[Table("Staff", Schema = "dbo")]
[Index(nameof(FirstName), nameof(LastName), IsUnique = true, Name = "UIX_FirstName_LastName")]
[Index(nameof(Email), IsUnique = true, Name = "UIX_Email")]
public class Staff : BaseModel
{
    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(30)]
    [Required]
    public string LastName { get; set; }

    [EmailAddress()]
    [Required]
    [MaxLength(30)]
    public string Email { get; set; }

    [Required]
    [MaxLength(11)]
    public string Phone { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(150)]
    public string? AddressLine1 { get; set; }

    [MaxLength(20)]
    public string? City { get; set; }

    [MaxLength(20)]
    public string? Country { get; set; }

    [MaxLength(20)]
    public string? Province { get; set; }

    [NotMapped]
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}
