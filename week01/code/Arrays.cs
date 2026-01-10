public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // <solution>
        // Since in this case we know the length of the array ahead of time, we can create a fixed size array of that size
        // returning it at the end.
        // So the first step is to create the array by the size
        // Then populate the array with a for loop using with index starting at 1 and increasing counter that we can use as the multiplier as well until it reaches the length
        // inside the for loop, each value in the array is set to the number multiplied by (index + 1) since the index starts at 1
        
        var multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // <solution>
        // To rotate the list to the right by the amount, we can follow these steps:
        // 1. Create a copy of the original list (originalData) to preserve the original values
        // 2. Clear the original list to remove all elements (but keep the reference)
        // 3. Use GetRange to get the last 'amount' elements and the remaining elements
        // 4. Add them back to the original list in the rotated order using AddRange

        List<int> originalData = new List<int>(data);

        data.Clear();
        
        data.AddRange(originalData.GetRange(originalData.Count - amount, amount));

        data.AddRange(originalData.GetRange(0, originalData.Count - amount));
    }
}
