using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class NotifyUserController : ControllerBase
{
    // we can have a notification entity and add to those 
    [HttpPost]
    public string Notify(List<int> ids)
    => "hello";
    
}