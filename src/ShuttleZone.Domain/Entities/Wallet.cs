﻿using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities
{
    public class Wallet : BaseEntity<Guid>
    {
        public double Balance { get; set; } = 0;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
