public class Program
{
    public static void Main()
    {
        TreeNode root3a = new(3, new(1, new(3)), new(4, new(1), new(5)));
        Console.WriteLine("Teste 1- " + (GoodNodes(root3a) == 4 ? "Correto" : "Errado"));
    }

    public static int GoodNodes(TreeNode root)
    {
        List<int> listCaminho = new()
        {
            root.val
        };
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