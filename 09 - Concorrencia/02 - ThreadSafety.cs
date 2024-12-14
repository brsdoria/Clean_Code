using System.Collections.Concurrent;

namespace CleanCode.M09_Concorrencia;

/*********************************/
/*        Thread Safety          */
/*********************************/

#region Imutabilidade
/*
    Objetos imutáveis são intrinsecamente thread-safe porque seu estado não pode ser alterado 
    após a criação. Em C#, a classe String é um exemplo de objeto imutável.
*/

public class ImmutableClass
{
    public int Value { get; }
    public ImmutableClass(int value) => Value = value;
}

#endregion

#region Sincronização
/*
    Usar mecanismos de sincronização para controlar o acesso a recursos compartilhados. 
    Em C#, lock, Monitor, Mutex e SemaphoreSlim são exemplos de mecanismos de sincronização.
*/

public class Counter
{
    private int _count;
    private readonly object _lock = new object();

    public void Increment()
    {
        lock (_lock)
        {
            _count++;
        }
    }

    public int GetCount()
    {
        lock (_lock)
        {
            return _count;
        }
    }
}

#endregion

#region Coleções Thread-Safe
/*
    Usar coleções especialmente projetadas para serem thread-safe, 
    como ConcurrentDictionary, ConcurrentQueue, ConcurrentBag e 
    BlockingCollection no .NET.
*/
public class Program7
{
    public void Demo()
    {
        var concurrentDictionary = new ConcurrentDictionary<int, string>();
        concurrentDictionary.TryAdd(1, "Value1");

    }
}

#endregion

#region Biblioteca Paralela de Tarefas (TPL) e async/await
/*
    Utilizar Task, Parallel e a palavra-chave await para criar código não bloqueante 
    e gerenciar a concorrência de forma segura.
*/

public class Program8
{
    public async Task<string> FetchDataAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            return await client.GetStringAsync("http://example.com");
        }
    }
}

#endregion

#region Condições de Corrida (Race Conditions)
/*
    Condições de corrida ocorrem quando duas ou mais threads acessam dados compartilhados 
    simultaneamente, e pelo menos um dos threads tenta modificar os dados. 
    Isso pode levar a resultados imprevisíveis e comportamentos erráticos.
*/

// Exemplo Problematico:
public class BadCounter
{
    private int _count = 0;

    public void Increment()
    {
        _count++;
    }

    public int GetCount()
    {
        return _count;
    }
}

public class Program9
{
    public static void Main()
    {
        var counter = new BadCounter();
        var thread1 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        var thread2 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Final count: {counter.GetCount()}");
    }
}

// Exemplo Solução:

public class GoodCounter
{
    private int _count = 0;
    private readonly object _lock = new object();

    public void Increment()
    {
        lock (_lock)  // Ponto relevante: Usar lock para garantir exclusão mútua
        {
            _count++;
        }
    }

    public int GetCount()
    {
        lock (_lock)  // Ponto relevante: Garantir leitura segura do valor
        {
            return _count;
        }
    }
}

public class Program10
{
    public static void Main()
    {
        var counter = new GoodCounter();
        var thread1 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        var thread2 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Final count: {counter.GetCount()}");
    }
}
#endregion

#region Deadlocks
/*
    Acontecem quando dois ou mais threads estão esperando indefinidamente por recursos 
    que são mantidos uns pelos outros, causando um impasse.
*/

// Exemplo Ruim:
public class DeadlockExample
{
    private readonly object _lock1 = new object();
    private readonly object _lock2 = new object();

    public void Method1()
    {
        lock (_lock1)
        {
            lock (_lock2)
            {
                // ...
            }
        }
    }

    public void Method2()
    {
        lock (_lock2)
        {
            lock (_lock1) // A solução aqui seria inverter os Locks como no primeiro método
            {
                // ...
            }
        }
    }
}

#endregion

#region Starvation
/*
    Starvation ocorre quando um thread é constantemente preterido e nunca tem 
    a chance de executar.
*/

// Starvation:
public class StarvationExample
{
    private readonly object _lock = new object();

    public void LongRunningTask()
    {
        lock (_lock)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock.");
            Thread.Sleep(5000); // Simula uma tarefa de longa duração
            Console.WriteLine($"{Thread.CurrentThread.Name} released the lock.");
        }
    }

    public void ShortRunningTask()
    {
        lock (_lock)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is running a short task.");
        }
    }
}

public class Program11
{
    public static void Main()
    {
        var example = new StarvationExample();

        // Thread de longa duração
        var longTaskThread = new Thread(example.LongRunningTask) { Name = "LongTaskThread" };
        longTaskThread.Start();

        // Threads de curta duração
        for (int i = 0; i < 5; i++)
        {
            // Neste exemplo, ShortTaskThread pode sofrer de starvation se LongTaskThread estiver
            // constantemente segurando o bloqueio por um longo tempo.
            var shortTaskThread = new Thread(example.ShortRunningTask) { Name = $"ShortTaskThread{i}" };
            shortTaskThread.Start();
        }
    }
}

public class StarvationSolutionExample
{
    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

    public void LongRunningTask()
    {
        _lock.EnterWriteLock();
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock.");
            Thread.Sleep(5000); // Simula uma tarefa de longa duração
            Console.WriteLine($"{Thread.CurrentThread.Name} released the lock.");
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    public void ShortRunningTask()
    {
        _lock.EnterReadLock();
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is running a short task.");
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
}

public class Program12
{
    public static void Main()
    {
        var example = new StarvationSolutionExample();

        var longTaskThread = new Thread(example.LongRunningTask) { Name = "LongTaskThread" };
        longTaskThread.Start();

        for (int i = 0; i < 5; i++)
        {
            var shortTaskThread = new Thread(example.ShortRunningTask) { Name = $"ShortTaskThread{i}" };
            shortTaskThread.Start();
        }
    }
}


#endregion

#region Interlocked Class
/*
    Técnica avançada de Thread Safe
    Fornece operações atômicas para variáveis compartilhadas, como incremento, decremento e troca.
*/

// Classe que representa um contador atômico
public class AtomicCounter
{
    // Campo privado que armazena o valor do contador
    private int _count;

    // Método que incrementa o valor do contador de maneira atômica
    public void Increment()
    {
        // Incrementa o valor de _count de forma atômica usando Interlocked.Increment
        Interlocked.Increment(ref _count);
    }

    // Método que retorna o valor atual do contador de maneira segura
    public int GetCount()
    {
        // Retorna o valor atual de _count de forma segura usando Interlocked.CompareExchange
        // Interlocked.CompareExchange retorna o valor original de _count sem alterá-lo
        return Interlocked.CompareExchange(ref _count, 0, 0);
    }
}

public class Program13
{
    public static void Main()
    {
        var counter = new AtomicCounter();

        // Cria a primeira thread que incrementa o contador 1000 vezes
        var incrementThread1 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        // Cria a segunda thread que incrementa o contador 1000 vezes
        var incrementThread2 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                counter.Increment();
            }
        });

        // Inicia as duas threads
        incrementThread1.Start();
        incrementThread2.Start();

        // Espera que ambas as threads terminem sua execução
        incrementThread1.Join();
        incrementThread2.Join();

        // Exibe o valor final do contador
        // O valor esperado é 2000, pois cada thread incrementa o contador 1000 vezes
        Console.WriteLine($"Final count: {counter.GetCount()}");
    }
}

#endregion

#region Thread Local Storage
/*
    Thread-Local Storage (TLS) permite que cada thread tenha sua própria cópia de uma variável, 
    evitando a necessidade de sincronização e permitindo que os dados sejam isolados para cada thread. 
    Isso é útil em situações onde você quer garantir que cada thread tenha seu próprio estado independente.
*/

public class MyThreadLocalExample
{
    // Define uma variável local por thread usando ThreadLocal<T>
    private static ThreadLocal<int> _threadLocalValue = new ThreadLocal<int>(() =>
    {
        // Inicializa a variável com o ID da thread atual
        // Isso é feito para demonstrar que cada thread terá um valor único
        return Thread.CurrentThread.ManagedThreadId;
    });

    // Método que exibe o valor da variável local por thread
    public void DisplayThreadLocalValue()
    {
        // Obtém e exibe o valor da variável local para a thread atual
        // Cada thread exibirá seu próprio valor inicializado com seu ID
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has value: {_threadLocalValue.Value}");
    }
}

public class Program14
{
    public static void Main()
    {
        // Cria uma instância da classe de exemplo
        var example = new MyThreadLocalExample();

        // Cria e inicia múltiplas threads
        var threads = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(example.DisplayThreadLocalValue);
            threads[i].Start();
        }

        // Espera que todas as threads terminem sua execução
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
}

// Saida esperada:
// Thread 1 has value: 1
// Thread 3 has value: 3
// Thread 5 has value: 5
// Thread 7 has value: 7
// Thread 9 has value: 9

#endregion

#region Jiggle Points
/*
    Técnica avançada de teste
    Jiggle points são pontos de inserção de aleatoriedade ou atrasos introduzidos deliberadamente 
    no código para testar a robustez e a resiliência de sistemas concorrentes. 
    O objetivo é simular condições imprevisíveis e detectar bugs que só aparecem sob certas condições 
    de execução, como race conditions ou deadlocks.
*/

public class JigglePointsExample
{
    private readonly object _lock1 = new object();
    private readonly object _lock2 = new object();
    private Random random = new Random();

    public void Method1()
    {
        try
        {
            if (random.NextDouble() < 0.5)
            {
                lock (_lock1)
                {
                    SimulateRandomYield(); // Introduzindo jiggle point
                    SimulateRandomDelay(); // Introduzindo jiggle point
                    lock (_lock2)
                    {
                        // Código protegido por ambos os bloqueios
                        Console.WriteLine("Method1 is executing with lock1 -> lock2.");
                    }
                }
            }
            else
            {
                lock (_lock2)
                {
                    SimulateRandomYield(); // Introduzindo jiggle point
                    SimulateRandomDelay(); // Introduzindo jiggle point
                    lock (_lock1)
                    {
                        // Código protegido por ambos os bloqueios
                        Console.WriteLine("Method1 is executing with lock2 -> lock1.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Method1 caught exception: {ex.Message}");
        }
    }

    public void Method2()
    {
        try
        {
            if (random.NextDouble() < 0.5)
            {
                lock (_lock1)
                {
                    SimulateRandomYield(); // Introduzindo jiggle point
                    SimulateRandomDelay(); // Introduzindo jiggle point
                    lock (_lock2)
                    {
                        // Código protegido por ambos os bloqueios
                        Console.WriteLine("Method2 is executing with lock1 -> lock2.");
                    }
                }
            }
            else
            {
                lock (_lock2)
                {
                    SimulateRandomYield(); // Introduzindo jiggle point
                    SimulateRandomDelay(); // Introduzindo jiggle point
                    lock (_lock1)
                    {
                        // Código protegido por ambos os bloqueios
                        Console.WriteLine("Method2 is executing with lock2 -> lock1.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Method2 caught exception: {ex.Message}");
        }
    }

    private void SimulateRandomYield()
    {
        // Geram um novo numero aleatório para modificar o comportamento dos metodos acima
        if (random.NextDouble() < 0.5)
        {
            Thread.Yield();
        }
    }

    private void SimulateRandomDelay()
    {
        // Introduz um atraso aleatório
        int delay = random.Next(1, 100);
        Thread.Sleep(delay);
    }
}

public class Program15
{
    public static void Main()
    {
        var example = new JigglePointsExample();

        var thread1 = new Thread(example.Method1);
        var thread2 = new Thread(example.Method2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}

#endregion