namespace ShuttleZone.Domain.Enums;

public enum ReservationStatusEnum
{
    PENDING,
    PAYSUCCEED, //if reservation is expired and not paysucceed, it payfail   
    CANCELLED
}