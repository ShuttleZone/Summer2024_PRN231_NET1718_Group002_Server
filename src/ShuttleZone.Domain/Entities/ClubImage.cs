using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class ClubImage : BaseEntity<Guid>
{
    
    public required string ImageUrl { get; set; }//req
    
    public required Guid ClubId { get; set; }//req
    public required Club Club { get; set; }//req
}