﻿using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Grpc;

namespace ShuttleZone.Api.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class GrpcController : ControllerBase
{
    [HttpGet]
    public IActionResult TestGrpc(Guid courtId)
    {
        using var channel = GrpcChannel.ForAddress("grpc://ourproject.io.vn:50051");
        var client = new MaintainCourtService.MaintainCourtServiceClient(channel);
        var response =  client.Maintain(new MaintainCourtRequest() { CourtId = courtId.ToString() });
        return Ok(response.Response);
    }
}