using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace playlist_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController()
        {
       
        }

        [HttpPost]
        [Route("SendMessage")]
        public void SendRabbitMessageMusic()
        {
            var factory = new ConnectionFactory { HostName = "192.168.240.6" };
            factory.UserName = "main-service";
            factory.Password = "main-service";
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            const string message = "Hello World from Playlist-Service!";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "EventBus",
                                 body: body);
        }

        [HttpGet]
        [Route("Hello_World")]
        public string HelloWorld()
        {
            return "Hello World from Playlist-Service";
        }

    }
}