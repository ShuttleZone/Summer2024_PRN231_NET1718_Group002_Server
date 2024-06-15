namespace ShuttleZone.Domain.Enums;

public enum ReservationStatusEnum
{
    PENDING, //if reservation is expired and pending, it is payfail (check status to show on UI)
    PAYSUCCEED,
    PAYFAIL,//if reservation is expired and not paysucceed, it is payfail   
    CANCELLED
}