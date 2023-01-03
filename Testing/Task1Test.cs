using SQLSpreadsTestProjectDec22.Task1;

namespace Testing
{

    [TestClass]
    public class Task1Test
    {

        [TestMethod]
        public void TestNewListConsistency()
        {
            List<int> result = MergeAndSortLists.ExecuteTask1();
            
            // not null
            Assert.IsNotNull(result);

            bool isAscOrder = true;
            if (result.Any())
            {
                // check ascending order
                int prevItem = result[0];
                for (int i = 1; i < result.Count; i++)
                {
                    int item = result[i];
                    isAscOrder = item >= prevItem;
                    if (!isAscOrder) break;
                    prevItem = item;
                }
            }
            Assert.IsTrue(isAscOrder);

            // Removing items A and B from result, check nothing left
            MergeAndSortLists.A.ToList().ForEach(item => result.Remove(item));
            MergeAndSortLists.B.ToList().ForEach(item => result.Remove(item));
            Assert.AreEqual(0, result.Count);

        }

    }

}