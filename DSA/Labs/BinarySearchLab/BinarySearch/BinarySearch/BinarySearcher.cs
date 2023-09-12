namespace BinarySearch
{
    public class BinarySearcher
    {
        public static int Search(int valToSearch, int[] inputArr)
        {
            //need issortedarray check

            //if arr is empty
            if (inputArr.Length == 0) throw new ArgumentException("Input array is empty.");

            //if valToSearch is out of bound
            if (inputArr[0] > valToSearch || inputArr[^1] < valToSearch) return -1;

            //setting index variables
            int startingPointIndex = 0;
            int endPointIndex = inputArr.Length - 1;
            int midPointIndex = startingPointIndex + (endPointIndex - startingPointIndex) / 2;

            
            while (inputArr[midPointIndex] != valToSearch)
            {
                //if valToSearch is not found
                if (midPointIndex == startingPointIndex || midPointIndex == endPointIndex) return -1;

                if (inputArr[midPointIndex] < valToSearch) //right
                {
                    startingPointIndex = midPointIndex;
                    midPointIndex = startingPointIndex + (endPointIndex - startingPointIndex) / 2;
                }
                else //left
                {
                    endPointIndex = midPointIndex;
                    midPointIndex = startingPointIndex + (endPointIndex - startingPointIndex) / 2;
                }
            }
            return inputArr[midPointIndex];
        }
    }
}