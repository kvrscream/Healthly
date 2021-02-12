using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathly.Data;
using Heathly.Models;
using Heathly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Heathly.Controllers
{
    public class PlainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlainController(ApplicationDbContext context)
        {
            _context = context;
        }
     
        public IActionResult Index()
        {
            List<PlainModel> plains = new PlainServices().GetAllPlains(context: _context);
            return View(plains);
        }


        public async Task<IActionResult> InsertOrUpdatePlain(int? id)
        {
            PlainModel plain = new PlainModel();
            if(id != null)
            {
                plain = new PlainServices().GetSinglePlain(context: _context, id: (int)id);
            }

            return View(plain);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdatePlain(PlainModel plain)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if(plain.Id > 0)
                {
                    message = new PlainServices().UpdatePlain(context: _context, plain: plain);
                } else
                {
                    plain.DataCadastro = DateTime.Now;
                    message = await new PlainServices().CreateNewPlain(context: _context, plain: plain);
                }
            }

            if (message.Equals("Plano criado com sucesso") || message.Equals("Plano atualizado com sucesso"))
            {
                ViewBag.Message = "<p class='alert alert-success'>"+message+"</p>";
            } else
            {
                ViewBag.Message = "<p class='alert alert-danger'>" + message + "</p>";
            }

            return View(plain);
        }

    }
}
