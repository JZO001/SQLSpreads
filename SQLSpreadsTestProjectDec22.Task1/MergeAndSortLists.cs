namespace SQLSpreadsTestProjectDec22.Task1
{

    /// <summary>Task 1</summary>
    public static class MergeAndSortLists
    {

        /*
            **********
            * Task 1 *
            **********
            - These are three lists with numbers: 
                int[] A = { 15, 24, 11, 3, 91, 82, 16, 77, 2, 10 };
                int[] B = { 25, 93,82, 22, 24};
                int[] C = { 3, 16, 27 };
            - Get a new list with all numbers from list A and B but do not include the numbers in C. Return the numbers in ascending order. 
            - This task do not need any GUI.
        */

        public static readonly int[] A = { 15, 24, 11, 3, 91, 82, 16, 77, 2, 10 };
        public static readonly int[] B = { 25, 93, 82, 22, 24 };

        /// <summary>Executes the task 1.</summary>
        /// <returns>The new list with the ordered content</returns>
        public static List<int> ExecuteTask1()
        {
            // new list
            List<int> result = new(A); // all numbers from list A
            result.AddRange(B); // and B but do not include the numbers in C
            result.Sort(); // Return the numbers in ascending order
            return result;
        }

    }

}
