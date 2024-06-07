namespace ShuttleZone.Domain.Enums;

public enum ReservationStatusEnum
{
    PENDING,
    PAYSUCCEED,
    PAYFAIL,//if reservation is expired and not paysucceed, it payfail   
    CANCELLED
}