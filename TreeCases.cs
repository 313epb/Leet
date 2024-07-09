namespace Leet;

public class TreeCases
{
    [Fact]
    public void Test1()
    {
        var result = SortedArrayToBST(new []{0,1,2,3,4,5});
    }

    [Fact]
    public void Test2()
    {
        
        
    }

    public List<int> LeftCourse(TreeNode treeNode)
    {
        if (treeNode == null) return new List<int>(0);
        var result = new List<int>
        {
            treeNode.val,

        };
        result.AddRange(LeftCourse(treeNode.left));
        result.AddRange(LeftCourse(treeNode.right));
        return result;
    }
    
    public List<int> RightCourse(TreeNode treeNode)
    {
        if (treeNode == null) return new List<int>(0);
        var result = new List<int>
        {
            treeNode.val,

        };
        result.AddRange(RightCourse(treeNode.right));
        result.AddRange(RightCourse(treeNode.left));
        return result;
    }

    public bool IsBalanced(TreeNode root) {
        if (root==null) return true;
        if (Math.Abs(GetHeight(root.left)-GetHeight(root.right))>1) return false;
        return IsBalanced(root.left) && IsBalanced(root.right);
    }
    public int GetHeight(TreeNode treeNode) => treeNode == null? 0: Math.Max(GetHeight(treeNode.right),GetHeight(treeNode.left)) + 1;
    
    
    public TreeNode SortedArrayToBST(int[] a)
    {
        if (a.Length == 0) return null;
        if (a.Length == 1) return new TreeNode(a[0]);
        var mid = a.Length / 2;
        return new TreeNode(
            a[mid],
            SortedArrayToBST(a.Take(mid).ToArray()),
            SortedArrayToBST(a.Skip(mid + 1).ToArray())
        );
    }
}