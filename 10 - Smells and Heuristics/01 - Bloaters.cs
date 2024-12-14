namespace CleanCode.M10_Smells_and_Heuristics;

/***********************************/
/*        Exemplos de Bloaters     */
/***********************************/

#region Long Method
/*
    Long Method: Este exemplo demonstra um método que faz muitas coisas ao
    mesmo tempo, tornando-se longo e difícil de entender e manter.
    A refatoração recomendada seria dividir o método em vários métodos menores.
*/

// Problema
public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Método longo que faz várias tarefas
        ValidateOrder(order);
        CalculateDiscounts(order);
        UpdateInventory(order);
        GenerateInvoice(order);
        SendConfirmationEmail(order);
    }

    private void ValidateOrder(Order order) { /* Validação do pedido */ }
    private void CalculateDiscounts(Order order) { /* Cálculo de descontos */ }
    private void UpdateInventory(Order order) { /* Atualização do inventário */ }
    private void GenerateInvoice(Order order) { /* Geração de fatura */ }
    private void SendConfirmationEmail(Order order) { /* Envio de e-mail de confirmação */ }
}

// Solução
public class RefactoredOrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Método principal delega tarefas específicas a métodos menores e focados
        ValidateOrder(order);
        CalculateOrderDetails(order);
        FinalizeOrder(order);
    }

    private void ValidateOrder(Order order) { /* Validação do pedido */ }

    private void CalculateOrderDetails(Order order)
    {
        CalculateDiscounts(order);
        UpdateInventory(order);
    }

    private void FinalizeOrder(Order order)
    {
        GenerateInvoice(order);
        SendConfirmationEmail(order);
    }

    private void CalculateDiscounts(Order order) { /* Cálculo de descontos */ }
    private void UpdateInventory(Order order) { /* Atualização do inventário */ }
    private void GenerateInvoice(Order order) { /* Geração de fatura */ }
    private void SendConfirmationEmail(Order order) { /* Envio de e-mail de confirmação */ }
}
#endregion

#region Large Class
/*
    Large Class: A classe a seguir possui muitas responsabilidades, o que a torna
    grande e difícil de gerenciar. A refatoração envolve dividir essa classe
    em classes menores com responsabilidades específicas.
*/

// Problema
public class CustomerService
{
    public void SaveCustomer(Customer customer) { /* Salvando cliente no banco de dados */ }
    public void SendWelcomeEmail(Customer customer) { /* Envio de e-mail de boas-vindas */ }
    public void ApplyLoyaltyPoints(Customer customer) { /* Aplicando pontos de fidelidade */ }
    public void GenerateCustomerReport(Customer customer) { /* Geração de relatórios do cliente */ }
    public void DeactivateCustomer(Customer customer) { /* Desativando conta do cliente */ }
}

// Solução
public class RefactoredCustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly EmailService _emailService;
    private readonly LoyaltyService _loyaltyService;
    private readonly ReportService _reportService;

    public RefactoredCustomerService(CustomerRepository customerRepository, EmailService emailService,
                                     LoyaltyService loyaltyService, ReportService reportService)
    {
        _customerRepository = customerRepository;
        _emailService = emailService;
        _loyaltyService = loyaltyService;
        _reportService = reportService;
    }

    public void SaveCustomer(Customer customer) => _customerRepository.Save(customer);
    public void SendWelcomeEmail(Customer customer) => _emailService.SendWelcomeEmail(customer);
    public void ApplyLoyaltyPoints(Customer customer) => _loyaltyService.ApplyPoints(customer);
    public void GenerateCustomerReport(Customer customer) => _reportService.GenerateReport(customer);
    public void DeactivateCustomer(Customer customer) => _customerRepository.Deactivate(customer);
}

// Classes refatoradas que isolam responsabilidades
public class CustomerRepository
{
    public void Save(Customer customer) { /* Salvando cliente no banco de dados */ }
    public void Deactivate(Customer customer) { /* Desativando conta do cliente */ }
}

public class EmailService
{
    public void SendWelcomeEmail(Customer customer) { /* Envio de e-mail de boas-vindas */ }
}

public class LoyaltyService
{
    public void ApplyPoints(Customer customer) { /* Aplicando pontos de fidelidade */ }
}

public class ReportService
{
    public void GenerateReport(Customer customer) { /* Geração de relatórios do cliente */ }
}
#endregion

#region Primitive Obsession
/*
    Primitive Obsession: Esta classe usa tipos primitivos para representar conceitos complexos.
    A refatoração envolve encapsular esses conceitos em suas próprias classes para melhorar
    a expressividade e a manutenção.
*/

// Problema
public class OrderWithPrimitives
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

// Solução
public class RefactoredOrder
{
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
}

public class Email
{
    private readonly string _value;

    public Email(string value)
    {
        // Validação do email
        if (string.IsNullOrEmpty(value) || !value.Contains("@"))
            throw new ArgumentException("Email inválido.");
        _value = value;
    }

    public override string ToString() => _value;
}

public class PhoneNumber
{
    private readonly string _value;

    public PhoneNumber(string value)
    {
        // Validação do número de telefone
        if (string.IsNullOrEmpty(value) || value.Length < 10)
            throw new ArgumentException("Número de telefone inválido.");
        _value = value;
    }

    public override string ToString() => _value;
}
#endregion

#region Classes auxiliares para os exemplos

public class Order { }
public class Customer { }

#endregion
