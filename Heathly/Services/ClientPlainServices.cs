using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathly.Data;
using Heathly.Models;

namespace Heathly.Services
{
    public class ClientPlainServices
    {

        public List<ClientPlainsModel> GetClientPlains(ApplicationDbContext context, int? clientID = null)
        {
            List<ClientPlainsModel> clientPlains = new List<ClientPlainsModel>();

            try
            {
                if(clientID != null)
                {
                    clientPlains = context.PlanosCliente.Where(w => w.Client.Id == clientID).ToList();
                } else
                {
                    clientPlains = context.PlanosCliente.ToList();
                }
            }catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return clientPlains;
        }

        public ClientPlainsModel GetClientPlain(ApplicationDbContext context, int clientId, int plainId)
        {
            ClientPlainsModel clientPlain = new ClientPlainsModel();

            try
            {
                clientPlain = context.PlanosCliente
                    .Where(w => w.Client.Id == clientId && w.Planos.Id == plainId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return clientPlain;
        }

        public string AddClientPlain(ApplicationDbContext context, ClientPlainsModel clientPlains)
        {
            string message = "Plano vinculado com sucesso";

            try
            {
                context.PlanosCliente.Add(clientPlains);
                context.SaveChanges();
            } catch(Exception ex)
            {
                message = "Um erro inesperado ocorreu. " + ex.Message;
            }

            return message;
        }

        public string RemoveClientPlain(ApplicationDbContext context, ClientPlainsModel clientPlains)
        {
            string message = "Plano removido do cliente com sucesso";

            try
            {
                context.PlanosCliente.Remove(clientPlains);
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
