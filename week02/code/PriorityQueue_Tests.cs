using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities.
    // Expected Result: Dequeue returns the item with the highest priority.
    // Defect(s) Found: Dequeue did not always examine the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    
    }
      

    [TestMethod]
    // Scenario: Two items have the same highest priority.
    // Expected Result: The first item added with that priority is removed first (FIFO).
    // Defect(s) Found: The last item with the highest priority was being selected instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
    

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items and then dequeue all of them.
    // Expected Result: Items are dequeued in order of their priority.
    // Defect(s) Found: Items were not removed from the queue after being dequeued.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
    

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }
    
     
     [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None after fixes.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }    

}