using System;
using System.ComponentModel.DataAnnotations;

namespace Commissions.Manager.Employees;

public class CreateUpdateEmployeeDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
    [Required]
    [StringLength(128)]
    public string Surname { get; set; }
    [Required]
    [StringLength(128)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartingDate { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 1000, ErrorMessage = "Pick up a number between 0 and 1000")]
    public double HourlyFee { get; set; }
}