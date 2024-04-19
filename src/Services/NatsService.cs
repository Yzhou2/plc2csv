using NATS.Client;
using NATS.Client.JetStream;
using Backend.Utilities;

public class NatsService
{
    private IConnection _connection;
    private IJetStream _jetStream;

    public NatsService()
    {
        var options = ConnectionFactory.GetDefaultOptions();
        options.Url = "nats://localhost:4222";
        _connection = new ConnectionFactory().CreateConnection(options);
        _jetStream = _connection.CreateJetStreamContext();
    }

    public void Subscribe<T>(string subject, DataHandler<T> handler)
    {
       // Create a stream consumer with a subscription configuration
        var stream = _jetStream.PushSubscribeAsync(subject, (sender, args) =>
        {
            handler.HandleMessage(args.Message.Data);
        });

        // Start listening asynchronously
        stream.Start();
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Error subscribing to '{subject}': {ex.Message}");
    }
}
