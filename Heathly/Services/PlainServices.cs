using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathly.Data;
using Heathly.Models;

namespace Heathly.Services
{
    public class PlainServices
    {

        public List<PlainModel> GetAllPlains(ApplicationDbContext context)
        {
            List<PlainModel> plains = new List<PlainModel>();

            try
            {
                plains = context.Planos.ToList();
            }catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return plains;
        }

        public PlainModel GetSinglePlain(ApplicationDbContext context, int id)
        {
            PlainModel plain = new PlainModel();

            try
            {
                plain = context.Planos.Where(w => w.Id == id).FirstOrDefault();
            } catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

            return plain;
        }


        public async Task<string> CreateNewPlain(ApplicationDbContext context, PlainModel plain)
        {
            string message = "Plano criado com sucesso";

            try
            {
                await context.Planos.AddAsync(plain);
                context.SaveChanges();
            }catch(Exception ex)
            {
                message = "Ocorreu um problema inesperado! " + ex.Message;
            }

            return message;
        }


        public string UpdatePlain(ApplicationDbContext context, PlainModel plain)
        {
            string message = "Plano atualizado com sucesso";

            try
            {
                context.Planos.Update(plain);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                message = "Ocorreu um problema inesperado! " + ex.Message;
            }

            return message;
        }


        public string DeletePlain(ApplicationDbContext context, PlainModel plain)
        {
            string message = "Plano excluído com sucesso";

            try
            {
                context.Planos.Remove(plain);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                message = "Ocorreu um problema inesperado! " + ex.Message;
            }

            return message;
        }

    }
}
