using AmnPardazJabari.Abstractions.ControllerBasic;
using AmnPardazJabari.Application.Contracts.Users;
using AmnPardazJabari.Application.Contracts.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Controllers.Admin;

public class UsersController(IAdminUserService adminUserService) : AdminBaseController
{
    [HttpGet("{id}")]
    public GetUserResponse Get(string id)
        => adminUserService.GetUserById(Guid.Parse(id));

    [HttpPatch("{id}")]
    public void Delete(string id) => adminUserService.Delete(Guid.Parse(id));
}