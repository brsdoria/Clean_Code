namespace CleanCode.M11_Praticas_Avancadas;

/***********************************/
/*        Factory Method           */
/***********************************/

#region Problema

// Uso Extensivo de Condicionais
// Baixa Flexibilidade
// Baixa Coesão - O método SendNotification está fazendo mais do que deveria
// Quebra do Princípio Aberto/Fechado (OCP)
// Dificuldade para executar testes

public class NotificationService
{
    public void SendNotification(string notificationType, string message)
    {
        if (notificationType == "Email")
        {
            SendEmailNotification(message);
        }
        else if (notificationType == "SMS")
        {
            SendSmsNotification(message);
        }
        else if (notificationType == "Push")
        {
            SendPushNotification(message);
        }
        else
        {
            throw new NotSupportedException("Notification type not supported");
        }
    }

    private void SendEmailNotification(string message)
    {
        Console.WriteLine("Sending Email Notification: " + message);
    }

    private void SendSmsNotification(string message)
    {
        Console.WriteLine("Sending SMS Notification: " + message);
    }

    private void SendPushNotification(string message)
    {
        Console.WriteLine("Sending Push Notification: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotificationService notificationService = new NotificationService();

        // Enviar uma notificação
        notificationService.SendNotification("Email", "Hello, this is a test notification!");
    }
}

#endregion

#region Solução
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Email Notification: " + message);
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending SMS Notification: " + message);
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Push Notification: " + message);
    }
}

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();

    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}

public class EmailNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SmsNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

public class PushNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}

class ProgramRF
{
    static void Main(string[] args)
    {
        NotificationFactory factory;

        // Dependendo da lógica, escolha a fábrica correta.
        string notificationType = "Email"; // Pode ser "SMS" ou "Push" dependendo do contexto

        switch (notificationType)
        {
            case "Email":
                factory = new EmailNotificationFactory();
                break;
            case "SMS":
                factory = new SmsNotificationFactory();
                break;
            case "Push":
                factory = new PushNotificationFactory();
                break;
            default:
                throw new NotSupportedException("Notification type not supported");
        }

        // Enviar a notificação usando a fábrica escolhida
        factory.Notify("Hello, this is a test notification!");
    }
}

// Solucao sem uso de SWITCH e Factory Method

public interface INotificationServiceRF
{
    void Notify(Type notificationType, string message);
}

public class NotificationServiceRF : INotificationServiceRF
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationServiceRF(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Notify(Type notificationType, string message)
    {
        if (!typeof(INotification).IsAssignableFrom(notificationType))
        {
            throw new ArgumentException("Invalid notification type", nameof(notificationType));
        }

        var notification = _serviceProvider.GetService(notificationType) as INotification;

        if (notification == null)
        {
            throw new InvalidOperationException($"No service of type {notificationType} is registered.");
        }

        notification.Send(message);
    }
}

public class OrderService
{
    private readonly INotificationServiceRF _notificationService;

    public OrderService(INotificationServiceRF notificationService)
    {
        _notificationService = notificationService;
    }

    public void CompleteOrder(object order)
    {
        // Lógica para completar o pedido

        // Notificar o usuário após o pedido ser concluído
        _notificationService.Notify(typeof(EmailNotification), "Your order has been completed!");

        // Você pode passar outros tipos de notificação, dependendo da lógica do seu sistema
    }
}

/*
Padrão Factory Method:

Vantagem: O Factory Method oferece um design claro e estruturado, especialmente útil em sistemas onde a 
criação de objetos é complexa ou quando há necessidade de controle sobre o processo de instância.

Desvantagem: Pode introduzir complexidade adicional ao código, com várias classes de fábrica, 
especialmente em sistemas menores ou quando não há muitos tipos diferentes para criar.


Abordagem com DI:

Vantagem: A abordagem usando injeção de dependência e resolução dinâmica via Type simplifica o código, 
evitando a criação de múltiplas fábricas e utilizando recursos do próprio framework.

Desvantagem: Perde-se um pouco da clareza estrutural e do controle fino que o Factory Method pode oferecer, 
e introduz-se um acoplamento mais forte ao contêiner de DI.
 
*/
#endregion
