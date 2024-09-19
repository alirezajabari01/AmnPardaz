using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Abstractions.ControllerBasic;

[ApiController]
[Route("api/[controller]")]
[SecurityFilter(RoleId.User)]
public class UserBaseController : ControllerBase
{
}