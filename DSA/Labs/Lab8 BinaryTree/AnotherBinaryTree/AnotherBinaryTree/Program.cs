using System.Linq;
class Solution
{
    public static TreeNode ArrayToTree(int[] arr, int i = 0)
    {
        TreeNode root = null;
        if ( i < arr.Length)
        {
            root = new TreeNode(arr[i]);
            root.left = ArrayToTree(arr, i * 2 + 1);
            root.right = ArrayToTree(arr, i * 2 + 2);
        }
        return root;
    }

}

class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int Value;
    public TreeNode(int value)
    {
        Value = value;
    }


    
    public static void Main()
    {
        string town = "asdjfipsdajPdsjaflk";
        string sliceLeft = town.Substring(4);
        sliceLeft.Count(x => x == '~');

    }
}