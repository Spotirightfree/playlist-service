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
        [Route("SendMessageMusic")]
        public void SendRabbitMessageMusic()
        {
            var factory = new ConnectionFactory { HostName = "192.168.240.6" };
            factory.UserName = "playlist-service";
            factory.Password = "playlist-service";
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "music-service-queue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            const string message = "Hello World!";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "music-service-queue",
                                 basicProperties: null,
                                 body: body);
        }


        [HttpPost]
        [Route("SendMessageLogin")]
        public void SendRabbitMessageLogin()
        {
            var factory = new ConnectionFactory { HostName = "192.168.240.6" };
            factory.UserName = "playlist-service";
            factory.Password = "playlist-service";
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "login-service-queue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            const string message = "Hello World!";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "login-service-queue",
                                 basicProperties: null,
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