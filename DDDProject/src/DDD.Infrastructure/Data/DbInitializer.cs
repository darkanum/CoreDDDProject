using DDD.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClientContext context)
        {

            //context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return; //DB já foi povoada
            }

            var clients = new Client[]
            {
                new Client
                {
                    Name = "Vitor José da Luz",
                    Cpf = "68283554077"
                },
                new Client
                {
                    Name = "Maria Sars",
                    Cpf = "43219199089"
                }
            };

            //Adiciona clientes no context
            context.AddRange(clients);

            var contacts = new Contact[]
            {
                new Contact
                {
                    Name = "Contact 1",
                    Phone = "(27) 98102-4961",
                    Email = "vitorjosedaluz-75@icloud.com",
                    Client = clients[0]
                },
                new Contact
                {
                    Name = "Contact 2",
                    Phone = "(27) 98102-7984",
                    Email = "v.luz-75@icloud.com",
                    Client = clients[1]
                }
            };

            context.AddRange(contacts);

            //salva alterações do contexto
            context.SaveChanges();
        }
    }
}
