
# 3rd week practice interview question

So this week's practice is related to use of sets on C# given the definitions:

## Definitions

An intersection of two sets contains items that are in both of the two sets.

A union of two sets contains all items that are in either set.

## Questions

1. Describe how you would write a function to find the intersection of two sets. Your solution should NOT use the built-in intersection method.

2. Describe how you would write a function to find the union of two sets. Your solution should NOT use the built-in union method." I have to include "For each task, your response should include:

## Criteria

For each question I have to include:

* Your overall approach.
* Step-by-step discussion of how the function would behave.
* The Big O performance of your approach.
* Highlight at least 3 test cases that you would try to make sure your approach would work.

## Limitation

I have 2 min tops to answer each question.

## Answers

1. For the intersection we could loop the values in the first set and verifies if the second set also contains it, if true populate a intersection set. Given it an O(n) time complexity.

    ### Intersection's Code

    ```csharp
    public static HashSet<T> Intersection<T>(HashSet<T> set1, HashSet<T> set2)
    {
        HashSet<T> intersection = new HashSet<T>();

        foreach (var x in set1)
        {
            if (set2.Contains(x))
            {
                intersection.Add(x);
            }
        }
        
        return intersection;
    }
    ```

    ### Intersection's Test Cases

    1. Sets with common elements: {1, 2, 3} and {2, 3, 4} → Expected result: {2, 3}.
    2. Sets with no common elements: {1, 2, 3} and {4, 5, 6} → Expected result: {}.
    3. One empty set: {} and {1, 2, 3} → Expected result: {}.

2. To create a union it is simpler given a set behavior that doesn't allows duplicates on it. We create a for loop that adds the value for the first set to a union set, with O(n) time given that the Add function is O(1) time we need to repeat for each value in the n sized set1. Then we do a second loop that adds the values of the second set, and given the case where the value to be insert is already there, the add method would simply substitute the value in the union set giving a O(m) for a m sized set2. So at the end we would have a time complexity of O(n + m) that it is basically O(n) time complexity.

    ### Union's Code

    ```csharp
    public static HashSet<T> Union <T>(HashSet<T> set1, HashSet<T> set2)
    {
        HashSet<T> union = new HashSet<T>();

        foreach (var x in set1)
        {
            union.Add(x);
        }

        foreach (var x in set2)
        {
            union.Add(x);
        }

        return union;
    }
    ```

    ### Union's Test Cases

    1. Sets with common elements: {1, 2, 3} and {2, 3, 4} → Expected result: {1, 2, 3, 4}.
    2. Sets with no common elements: {1, 2, 3} and {4, 5, 6} → Expected result: {1, 2, 3, 4, 5, 6}.
    3. One empty set: {} and {1, 2, 3} → Expected result: {1, 2, 3}.
