public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Program
{
    public static void Main()
    {
        TreeNode root3 = new(3);
        TreeNode root1 = new(1);
        TreeNode root5 = new(5);
        TreeNode root4 = new(4, root1, root5);
        TreeNode root1a = new(1, root3);
        TreeNode root3a = new(3, root1a, root4);
        GoodNodes(root3a);
    }

    public static int GoodNodes(TreeNode root)
    {
        List<int> listCaminho = new();
        listCaminho.Add(root.val);
        return IsGoodNode(root, listCaminho);
    }

    internal static int IsGoodNode(TreeNode root, List<int> list)
    {
        int soma = 0;
        if (root.left != null)
        {
            list.Add(root.left.val);
            soma += IsGoodNode(root.left, list);
            list.Remove(root.left.val);
            root.left = null;
        }
        if (root.right != null)
        {
            list.Add(root.right.val);
            soma += IsGoodNode(root.right, list);
            list.Remove(root.right.val);
            root.right = null;
        }
        if (root.left == null && root.right == null)
        {
            foreach (var item in list)
            {
                if (root.val < item)
                    return soma;
            }
            return ++soma;
        }
        return soma;
    }
}