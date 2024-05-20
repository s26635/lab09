using lab09.Enitites;
using lab09.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab09.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientsController
{
    [HttpGet]
    public async Task<IActionResult> GetClients(CancellationToken cancellationToken)
    {
        MolakContext context = new();

        List<ClientDTO> clients = await context.Clients
            .Include(x => x.IdClient)
            .Select(x => new ClientDTO())
            .ToListAsync();
        return Ok(clients);
    }
}