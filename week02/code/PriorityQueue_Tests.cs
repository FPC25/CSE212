using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue
    // This will test error handling.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    // None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an InvalidOperationException to be thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
            return; // Test passes if exception is caught with correct message
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Add a single item to the priority queue and then dequeue it, emptying the queue.
    // This will test adding and removing items functionality.
    // Expected Result: The first dequeue returns the item.
    // Defect(s) Found: 
    // The dequeue method did not remove the item from the queue before returning it. So added _queue.RemoveAt(highPriorityIndex) to fix.
    public void TestPriorityQueue_OneItem()
    {
        var bob = new PriorityItem("Bob", 1);

        PriorityItem[] expectedResult = [bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add a single item to the priority queue and then dequeue it, then try to dequeue again.
    // This will test error handling after removing all items from the queue.
    // Expected Result: The first dequeue returns the item, the second dequeue throws an exception.
    // Defect(s) Found:
    // None, after fix in previous test.
    public void TestPriorityQueue_DequeueAfterEmpty()
    {
         var bob = new PriorityItem("Bob", 1);

        PriorityItem[] expectedResult = [bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an InvalidOperationException to be thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
            return; // Test passes if exception is caught with correct message
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        } 
    }

    [TestMethod]
    // Scenario: Add multiple items with different positive priorities, (Lowest, 1), (Highest, 3), (Mid, 2) to the priority queue, then dequeue them .
    // This will test correct ordering based on priority.
    // Expected Result: Items are dequeued in order of their priorities, from highest to lowest. (Highest, Mid, Lowest)
    // Defect(s) Found:
    // The dequeue method's for loop had an off-by-one error in its condition, causing it to skip the last item. Changed "index < _queue.Count - 1" to "index < _queue.Count". 
    public void TestPriorityQueue_MultipleDIfferentPositivePriorities()
    {
        var bob = new PriorityItem("Lowest", 1);
        var tim = new PriorityItem("Highest", 3);
        var sue = new PriorityItem("Mid", 2);

        PriorityItem[] expectedResult = [tim, sue, bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add multiple items with different negative priorities to the priority queue, then dequeue them.
    // This will test correct ordering based on priority, with the twist of negative values.
    // Expected Result: Items are dequeued in order of their priorities, from least negative to most negative.
    // Defect(s) Found: 
    // None, after fix in previous test.
    public void TestPriorityQueue_MultipleDIfferentNegativePriorities()
    {
        var tim = new PriorityItem("Tim", -2);
        var sue = new PriorityItem("Sue", -5);
        var bob = new PriorityItem("Bob", -1);

        PriorityItem[] expectedResult = [bob, tim, sue];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add multiple items with mixed positive and negative priorities to the priority queue, including zero, then dequeue them.
    // This will test correct ordering based on priority across the full range of integer values.
    // Expected Result: Items are dequeued in order of their priorities, from highest to lowest.
    // Defect(s) Found: 
    // None, after fix in previous test.
    public void TestPriorityQueue_MultipleDIfferentMixedPriorities()
    {
        var tim = new PriorityItem("Tim", -2);
        var sue = new PriorityItem("Sue", -5);
        var bob = new PriorityItem("Bob", -1);
        var ann = new PriorityItem("Ann", 0);
        var max = new PriorityItem("Max", 3);
        var liz = new PriorityItem("Liz", 1);

        PriorityItem[] expectedResult = [max, liz, ann, bob, tim, sue];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(ann.Value, ann.Priority);
        priorityQueue.Enqueue(max.Value, max.Priority);
        priorityQueue.Enqueue(liz.Value, liz.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add items with edge case priority values (int.MaxValue, int.MinValue) to the priority queue, then dequeue them.
    // This will test the priority queue's handling of extreme priority values.
    // Expected Result: Items are dequeued in order of their priorities, from highest to lowest.
    // Defect(s) Found: 
    // None, after fix in previous test.
    public void TestPriorityQueue_EdgeValues()
    {
        var tim = new PriorityItem("Tim", int.MaxValue);
        var sue = new PriorityItem("Sue", 0);
        var bob = new PriorityItem("Bob", int.MinValue);

        PriorityItem[] expectedResult = [tim, sue, bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add multiple items with some having the same priorities to the priority queue, then dequeue them.
    // This will test correct ordering and handling of items with identical priorities, validating FIFO order.
    // Expected Result: Items are dequeued in order of their priorities, from highest to lowest, with items of the same priority dequeued in the order they were added.
    // Defect(s) Found: 
    // The dequeue method did not correctly handle items with the same priority in FIFO order. Changed the comparison in the for loop from "if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)" to "if (_queue[index].Priority > _queue[highPriorityIndex].Priority)" to fix.
    public void TestPriorityQueue_SomeSamePriorities()
    {
        var tim = new PriorityItem("Tim", 1);
        var sue = new PriorityItem("Sue", 1);
        var bob = new PriorityItem("Bob", -1);
        var ann = new PriorityItem("Ann", 0);
        var max = new PriorityItem("Max", 3);
        var liz = new PriorityItem("Liz", 0);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(ann.Value, ann.Priority);
        priorityQueue.Enqueue(max.Value, max.Priority);
        priorityQueue.Enqueue(liz.Value, liz.Priority);

        PriorityItem[] expectedResult = [max, tim, sue, ann, liz, bob];

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add multiple items all having the same priority to the priority queue, then dequeue them.
    // This will test correct FIFO ordering when priorities are identical.
    // Expected Result: Items are dequeued in the order they were added, since all priorities are the same.
    // Defect(s) Found: 
    // None, after fix in previous test.
    public void TestPriorityQueue_AllSamePriorities()
    {
        var tim = new PriorityItem("Tim", 0);
        var sue = new PriorityItem("Sue", 0);
        var bob = new PriorityItem("Bob", 0);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        PriorityItem[] expectedResult = [bob, tim, sue];
        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add multiple items midway through processing to the priority queue.
    // This will test the priority queue's ability to handle dynamic additions.
    // Expected Result: The newly added items are correctly placed according to their priorities.
    // Defect(s) Found: 
    // None, after fix in previous test.
    public void TestPriorityQueue_AddingPlayersMidway()
    {
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 1);
        var bob = new PriorityItem("Bob", -1);
        var ann = new PriorityItem("Ann", 1);
        var max = new PriorityItem("Max", 3);
        var liz = new PriorityItem("Liz", 0);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(ann.Value, ann.Priority);
        priorityQueue.Enqueue(liz.Value, liz.Priority);

        PriorityItem[] expectedResult = [tim, sue, max, ann, liz, bob];

        int i;
        for (i = 0; i < 2; i++)
        {
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
        }

        priorityQueue.Enqueue(max.Value, max.Priority);
        priorityQueue.Enqueue(bob.Value, bob.Priority);

        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }    
}