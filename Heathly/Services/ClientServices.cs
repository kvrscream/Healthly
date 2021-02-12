using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PersonModel GtSingleClient(ApplicationDbContext context, int id)
        {
            PersonModel client = new PersonModel();

            try
            {
                client = context.Clientes.Where(w => w.Id == id).FirstOrDefault();
            } catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return client;
        }


        public async Task<string> CreateClient(ApplicationDbContext context, PersonModel client)
        {
            string message = "Cliente cadastrado com sucesso.";

            try
            {
                await context.Clientes.AddAsync(client);
                context.SaveChanges();
            } catch(Exception ex)
            {
                message = "Um erro inesperado ocorreu. " + ex.Message;
            }

            return message;
        }

        public string UpdateClient(ApplicationDbContext context, PersonModel client)
        {
            string message = "Cliente atualizado com sucesso.";

            try
            {
                context.Clientes.Update(client);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                message = "Um erro inesperado ocorreu. " + ex.Message;
            }

            return message;
        }

        public string RemoveClient(ApplicationDbContext context, PersonModel client)
        {
            string message = "Cliente excluído com sucesso.";

            try
            {
                context.Clientes.Remove(client);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                message = "Um erro inesperado ocorreu. " + ex.Message;
            }

            return message;
        }

    }
}
