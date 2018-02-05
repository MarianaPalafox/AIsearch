using System;
using bfs_and_dfs;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bfs_and_dfs
{

   
    partial class Program
    {

        static void dfs_traversal(Node node,String end)
        {
            
            if (node == null)
                return;

            Console.Write(node.data + " ");
            if (node.data.Equals(end))
                return;
            
                dfs_traversal(node.left,end);
                dfs_traversal(node.right,end);
              
            
        }
        static void dfs_limited_traversal(Node node, String end,int p)
        {
            int profundidad = p;
            if (node == null)
                return;

            Console.Write(node.data + " ");
            if (node.data.Equals(end))
                return;
            if (node.depht == profundidad)
                return;

            dfs_limited_traversal(node.left,end,p);
            dfs_limited_traversal(node.right,end,p);
            

        }

        static void bfs_traversal(Node node,String end)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.Write(node.data + " ");
                if (node.data.Equals(end))
                    return;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }
        static Node sample_tree()
        {
            Node root =
                new Node("A",
                new Node("B",
                new Node("C"),new Node("D")),
                new Node("E",
                    new Node("F"), new Node("G",
                    new Node("H"), null)));
            return root;
        }

        static Node sample_tree2()
        {
            Node root =
                new Node("A", new Node("B",new Node("C",2), new Node("D",2),1),
                new Node("E",new Node("F",2), new Node("G",new Node("H",3), null),2),0);
            return root;
        }
        static void Main(string[] args)
        {
            Node tree = sample_tree();
            Node tree2 = sample_tree2();
            Console.WriteLine("BFS->"); bfs_traversal(tree,"H");
            Console.WriteLine();
            Console.WriteLine("DFS->"); dfs_traversal(tree2,"H");
            Console.WriteLine();
            Console.WriteLine("DFS Limited->"); dfs_limited_traversal(tree2, "H",2);
            Console.ReadKey();


        }
    }
}
