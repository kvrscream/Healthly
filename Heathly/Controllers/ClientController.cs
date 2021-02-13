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
            PersonModel client = new PersonModel();
            if (id != null)
            {
                client = new ClientServices().GtSingleClient(context: _context, id: (int)id);
            }

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateClient(PersonModel client)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if(client.Id > 0)
                {
                    message = new ClientServices().UpdateClient(context: _context, client: client);
                } else
                {
                    client.DataCadastro = DateTime.Now;
                    message = await new ClientServices().CreateClient(context: _context, client: client);
                }
            }

            if(message.Equals("Cliente cadastrado com sucesso.") || message.Equals("Cliente atualizado com sucesso."))
            {
                ViewBag.Message = "<p class='alert alert-success'>" + message + "</p>";
            }
            else
            {
                ViewBag.Message = "<p class='alert alert-danger'>" + message + "</p>";
            }

            return View(client);
        }

        public IActionResult AddPlain(int id)
        {
            PersonModel client = new ClientServices().GtSingleClient(context: _context, id: id);
            List<ClientPlainsModel> clientPlains =
                new ClientPlainServices().GetClientPlains(context: _context, clientID: id);
            List<PlainModel> plains = new List<PlainModel>();

            if(client.Documento.Length > 15 && client.RG == null)
            {
                plains = new PlainServices()
                    .GetAllPlains(context: _context).Where(w => w.PermitePJ == true).ToList();
            } else
            {
                plains = new PlainServices()
                    .GetAllPlains(context: _context).Where(w => w.PermitePJ == false).ToList();
            }

            ViewBag.Plains = plains;
            ViewBag.ClientPlains = clientPlains;

            return View(client);
        }


        [HttpGet]
        public JsonResult AddPlainToClient(int planoId, int clienteId)
        {
            PersonModel client = new ClientServices().GtSingleClient(context: _context, id: clienteId);
            PlainModel plain = new PlainServices().GetSinglePlain(context: _context, id: planoId);
            string message = "";
            if(client.Documento.Length > 15 && client.RG == null)
            {
                if (plain.PermitePJ == false)
                {
                    return Json(new { success = false, message = "Plano não permite pessoa jurídica." });
                }
            }
            ClientPlainsModel clientPlain = new ClientPlainsModel();
            clientPlain.Client = client;
            clientPlain.Planos = plain;

            message = new ClientPlainServices().AddClientPlain(context: _context, clientPlains: clientPlain);

            if (message.Equals("Plano vinculado com sucesso"))
            {
                return Json(new { success = true, message = message});

            }

            return Json(new { success = false, message = message });
        }

        [HttpGet]
        public JsonResult RemovePlainToClient(int planoId, int clienteId)
        {
            ClientPlainsModel clientPlain =
                new ClientPlainServices().GetClientPlain(context: _context, clientId: clienteId, plainId: planoId);

            string message = new ClientPlainServices().RemoveClientPlain(context: _context, clientPlains: clientPlain);

            if (message.Equals("Plano removido do cliente com sucesso"))
            {
                return Json(new { success = true, message = message });
            }

            return Json(new { success = false, message = message });
        }

    }
}
