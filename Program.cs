namespace dz_BinaryTree
{ 

     public class BinaryTree<T>
{
    public Node<T> _root;
    public Func<T, T, int> _compareFunction;

    public BinaryTree(Func<T, T, int> compareFunction)
    {
        _compareFunction = compareFunction;
    }
    public void Add(T data)
    {
        if (_root == null)
        {
            _root = new Node<T> { Data = data };
            return;
        }

        AddTo(_root, data);
    }
    public void AddTo(Node<T> node, T data)
    {
        if (_compareFunction(data, node.Data) < 0)
        {
            if (node.Left == null)
            {
                node.Left = new Node<T> { Data = data, Parent = node };
            }
            else
            {
                AddTo(node.Left, data);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new Node<T> { Data = data, Parent = node };
            }
            else
            {
                AddTo(node.Right, data);
            }
        }
    }
    public void Print(bool ascending = true)
    {
        if (ascending)
        {
            InOrderTraversal(_root);
        }
        else
        {
            ReverseInOrderTraversal(_root);
        }
        Console.WriteLine();
    }
    public void InOrderTraversal(Node<T> node)
    {
        if (node == null) return;
        InOrderTraversal(node.Left);
        Console.Write(node.Data + " ");
        InOrderTraversal(node.Right);
    }
    public void ReverseInOrderTraversal(Node<T> node)
    {
        if (node == null) return;
        ReverseInOrderTraversal(node.Right);
        Console.Write(node.Data + " ");
        ReverseInOrderTraversal(node.Left);
    }
    public class Node<TNode>
    {
        public TNode Data { get; set; }
        public Node<TNode> Left { get; set; }
        public Node<TNode> Right { get; set; }
        public Node<TNode> Parent { get; set; }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>((a, b) => a.CompareTo(b));

            tree.Add(8);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            Console.WriteLine("Default:");
            tree.Print(true);
            Console.WriteLine("Revers:");
            tree.Print(false);
        }
    }
}