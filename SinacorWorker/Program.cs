// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SinacorWorker.Domain;
using System.Text;
using SinacorWorker.Services;

TarefaService tarefaService = new TarefaService();
var connectionfactory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = connectionfactory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "sicanor",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        try
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var tarefa = System.Text.Json.JsonSerializer.Deserialize<Tarefa>(message);
            tarefaService.Save(tarefa);
            Console.WriteLine($"Tarefa Recebida: {tarefa.Descricao}|{tarefa.Data}");
            channel.BasicAck(ea.DeliveryTag, false);
        }
        catch (Exception ex)
        {            
            channel.BasicNack(ea.DeliveryTag, false, true);
        }
    };
    channel.BasicConsume(queue: "sicanor",
                         autoAck: false,
                         consumer: consumer);

    Console.WriteLine("Aperte ENTER para sair.");
    Console.ReadLine();
}

