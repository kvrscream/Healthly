using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathly.Data;
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
            return View();
        }
    }
}
