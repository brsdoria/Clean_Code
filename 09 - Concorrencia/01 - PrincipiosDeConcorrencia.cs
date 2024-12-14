using System.Collections.Concurrent;

namespace CleanCode.M09_Concorrencia;

/***********************************/
/*    Principios De Concorrencia   */
/***********************************/

#region Isolamento de Dados Compartilhados
/*
    Minimize a quantidade de dados compartilhados entre threads para reduzir
    a complexidade e a possibilidade de erros. Sempre que possível, 
    cada thread deve trabalhar com seus próprios dados.
 */

public class Worker
{
    public void DoWork()
    {
        int localData = 0; // Dados isolados por thread
        // Processamento usando dados locais não compartilhados
        localData++;
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Data: {localData}");
    }
}

public class Program
{
    public static void Main()
    {
        var worker = new Worker();
        var thread1 = new Thread(worker.DoWork);
        var thread2 = new Thread(worker.DoWork);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
#endregion

#region Sincronização Adequada
/*
    Use mecanismos de sincronização para controlar o acesso a recursos compartilhados. 
    Evite dependências desnecessárias que possam levar a contenções e deadlocks.
 */

public class SharedResource
{
    private int _data;
    private readonly object _lock = new object();

    public void UpdateData(int value)
    {
        lock (_lock)
        {
            _data = value;
            Console.WriteLine($"Data updated to {value} by Thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    public int ReadData()
    {
        lock (_lock)
        {
            return _data;
        }
    }
}

public class Program2
{
    public static void Main()
    {
        var resource = new SharedResource();
        var thread1 = new Thread(() => resource.UpdateData(10));
        var thread2 = new Thread(() => Console.WriteLine($"Read Data: {resource.ReadData()}"));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}


#endregion

#region Uso de Coleções Thread-Safe
/*
    Utilize coleções projetadas para uso concorrente para gerenciar dados compartilhados
    entre threads, evitando a necessidade de implementar sincronização manual.
 */

public class Program3
{
    public static void Main()
    {
        var concurrentDictionary = new ConcurrentDictionary<int, string>();
        var thread1 = new Thread(() => concurrentDictionary.TryAdd(1, "Value1"));
        var thread2 = new Thread(() => Console.WriteLine($"Value: {concurrentDictionary[1]}"));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
#endregion

#region Separação de Preocupações
/*
    Separe a lógica de negócios da lógica de concorrência. 
    Classes de negócio não devem gerenciar threads diretamente; 
    essa responsabilidade deve ser atribuída a um componente separado.
 */

public class BusinessLogic
{
    public void Execute()
    {
        Console.WriteLine("Lógica de negócios executada.");
    }
}

public class ConcurrentExecutor
{
    private readonly BusinessLogic _businessLogic;

    public ConcurrentExecutor(BusinessLogic businessLogic)
    {
        _businessLogic = businessLogic;
    }

    public void Run()
    {
        Task.Run(() => _businessLogic.Execute());
    }
}

public class Program4
{
    public static void Main()
    {
        var businessLogic = new BusinessLogic();
        var executor = new ConcurrentExecutor(businessLogic);

        executor.Run();
    }
}


#endregion

#region Thread-Local Storage (TLS)
/*
    Utilize armazenamento local por thread para evitar o compartilhamento 
    de dados entre threads, garantindo que cada thread tenha sua própria cópia dos dados.
*/

public class ThreadLocalExample
{
    private static ThreadLocal<int> _threadLocalValue = new ThreadLocal<int>(() => 42);

    public int GetThreadLocalValue()
    {
        return _threadLocalValue.Value;
    }
}

public class Program5
{
    public static void Main()
    {
        var example = new ThreadLocalExample();

        var thread1 = new Thread(() => Console
            .WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Value: {example.GetThreadLocalValue()}"));
        
        var thread2 = new Thread(() => Console
            .WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Value: {example.GetThreadLocalValue()}"));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
#endregion

#region Princípio de Não Interferência
/*
    Projete sistemas concorrentes de modo que threads não interfiram umas 
    nas outras mais do que o necessário. Minimize a duração das seções 
    críticas e use estruturas de dados projetadas para acesso concorrente 
    para reduzir a contenção e melhorar o desempenho.
*/

public class NonInterferenceExample
{
    private readonly ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();

    public void Producer()
    {
        for (int i = 0; i < 100; i++)
        {
            _queue.Enqueue(i);
            Console.WriteLine($"Produced: {i}");
        }
    }

    public void Consumer()
    {
        while (_queue.TryDequeue(out int result))
        {
            Console.WriteLine($"Consumed: {result}");
        }
    }
}

public class Program6
{
    public static void Main()
    {
        var example = new NonInterferenceExample();

        var producerThread = new Thread(example.Producer);
        var consumerThread = new Thread(example.Consumer);

        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();
    }
}
#endregion