using System;
using System.Collections.Generic;
using System.Linq;
using Heathly.Data;
using Heathly.Models;

namespace Heathly.Services
{
    public class ClientServices
    {

        public List<PersonModel> GetAllClients(ApplicationDbContext context, string documento = null, string nome = null, DateTime? data = null)
        {
            List<PersonModel> clients = new List<PersonModel>();

            try
            {
                if(documento != null)
                {
                    clients = context.Clientes.Where(w => w.Documento.Contains(documento)).ToList();
                } else if(nome != null)
                {
                    clients = context.Clientes.Where(w => w.Nome.Contains(nome)).ToList();
                } else if(data != null)
                {
                    clients = context.Clientes.Where(w => w.DataCadastro == data).ToList();
                } else
                {
                    clients = context.Clientes.ToList();
                }
            } catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return clients;
        }

    }
}
