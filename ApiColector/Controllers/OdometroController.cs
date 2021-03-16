using ApiColector.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiColector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdometroController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Odometro odometro)
        {

            string connectionString = "Endpoint=sb://queuematias.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=/NoSg88zhM6W5wCoN6kmMdFNv1hebNZ2V3rSFz21zWA=;EntityPath=ejercicios";
            string queueName = "ejercicios";
            string mensaje = JsonConvert.SerializeObject(odometro);

            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            return true;
        }

    }
}
