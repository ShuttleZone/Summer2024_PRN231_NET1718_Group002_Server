﻿using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Club
{
    public class CreateClubRequestResponse
    {
        public Guid Id { get; set; }
        public string ClubName { get; set; } = null!;
        public string ClubAddress { get; set; } = null!;
        public string ClubPhone { get; set; } = null!;
        public string ClubDescription { get; set; } = null!;
        public string Status { get; set; } = null!;
      
    }
    
}