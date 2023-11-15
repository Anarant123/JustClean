using JustClean.Web.Models;
using JustClean.Web.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JustClean.Web.Repository
{
    public static class ClientExtensions
    {
        public static async Task<Client> GetClient(this Repository repository, int id)
        {
            var client = await repository.context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client is null) return null;

            return client;
        }

        public static async Task<Client> Authorization(this Repository repository, AuthModel authModel)
        {
            var client = await repository.context.Clients.FirstOrDefaultAsync(x => x.Login == authModel.Login && x.Password == authModel.Password);
            if (client is null) return null;

            return client;
        }

        public static async Task<Client> Registration(this Repository repository, RegModel regModel)
        {
            var client = new Client
            {
                Surname = regModel.Surname,
                Name = regModel.Name?.Trim(),
                Patronymic = regModel.Patronymic,
                Phone = regModel.Phone.Trim(),
                Mail = regModel.Mail.Trim(),
                CreateDate = DateTime.Now.Date,
                Company = regModel.Company,
                Description = regModel.Description,
                IdOffice = regModel.IdOffice,
                Login = regModel.Login.Trim(),
                Password = regModel.Password,
            };

            var errors = new List<Error>(3);

            if (await repository.context.Clients.AnyAsync(x => x.Login == client.Login))
                return null;

            repository.context.Clients.Add(client);

            try
            {
                await repository.context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return null;
            }

            return client;
        }
    }
}
