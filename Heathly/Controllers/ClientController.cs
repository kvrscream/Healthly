using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathly.Data;
using Heathly.Models;
using Heathly.Services;
using Microsoft.AspNetCore.Mvc;


namespace Heathly.Controllers
{
    public class ClientController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<PersonModel> clients = new List<PersonModel>();
            clients = new ClientServices().GetAllClients(context: _context);
            return View(clients);
        }


        [HttpPost]
        public IActionResult Index(string documento = null, string nome = null, DateTime? data = null)
        {
            List<PersonModel> clients = new List<PersonModel>();
            clients = new ClientServices()
                .GetAllClients(context: _context, documento: documento, nome: nome, data: data);
            return View(clients);
        }


        public async Task<IActionResult> InsertOrUpdateClient(int? id = null)
        {
            return View();
        }

    }
}
