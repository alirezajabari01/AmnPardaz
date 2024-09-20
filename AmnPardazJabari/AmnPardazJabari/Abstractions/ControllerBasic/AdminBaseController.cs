using AmnPardazJabari.Application.Contracts.Users;
using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Abstractions.ControllerBasic;

[ApiController]
[Route("api/admin/[controller]")]
[SecurityFilter(RoleId.Admin)]
public class AdminBaseController : ControllerBase
{
    
}