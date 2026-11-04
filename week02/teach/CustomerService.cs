/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with size 0.
        // Expected Result: Queue defaults to a size of 10. 
        Console.WriteLine("Test 1");

        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario:  Fill the queue to its maximum size and add one more customer.
        // Expected Result: Display "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 2");

        // Defect(s) Found:
        // Queue allows one extra customer because
       // _queue.Count > _maxSize should be
      // _queue.Count >= _maxSize 

        Console.WriteLine("=================");

        // Test 3
      // Scenario: Serve a customer when the queue is empty.
      // Expected Result: Display an error message.

        Console.WriteLine("Test 3");

        // Defect(s) Found:
       // Program crashes because ServeCustomer()
      // does not check whether the queue is empty.

       Console.WriteLine("=================");

       // Test 4
      // Scenario: Add two customers and serve one.
      // Expected Result: First customer added should be served first (FIFO).

       Console.WriteLine("Test 4");

        // Defect(s) Found:
        // ServeCustomer removes the first customer
        // before displaying it, causing the wrong
       // customer to be shown.
       Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}