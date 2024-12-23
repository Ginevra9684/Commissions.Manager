
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Commissions.Manager.Commissions;

public class CreateUpdateCommissionDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EnumDataType(typeof(CommissionType))]
    public CommissionType Type { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public decimal Total { get; set; }
    //[Required]
    ////[Display(Name = "Customer")]
    //[UIHint("Hidden")]  // hides the field in the form
    [IgnoreDataMember]  // allows to ignore input for this field
    public Guid CustomerId { get; set; }
}
