using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace PII_Batalla_Naval
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            Console.WriteLine("Bienvenido a Batalla Naval, ingresa alguno de los siguientes comandos:");
            Console.WriteLine("> Jugar (1v1)");
            Console.WriteLine("> Salir");
            message = Console.ReadLine();
        }

        public static async Task HandleMessageRecived(string message)
        {
            string response;

            switch(message.ToLower().Trim())
            {
                case "jugar":
                    
                    Logic game = new Logic();

            }

        }
    }
}
