using System;
using bfs_and_dfs;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bfs_and_dfs
{


    partial class Program
    {
        static void bidirectional(Node node, String end)
        {
            Queue<Node> q = new Queue<Node>();
            Queue<Node> w = new Queue<Node>();
            q.Enqueue(node);
            Node node2;
            List<Node> nodos = new List<Node>();
            int i=0;
            while (q.Count > 0)
            {


                node = q.ElementAt(i);
             
                
                if (node.data.Equals(end))
                {
                    return;
                }
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                   
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                   
                }

                i++;

            }
            
            nodos = q.Reverse().ToList();
            w = new Queue<Node>(nodos);
            node2 = w.ElementAt(0);
            
            
            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.Write(node.data + " ");
                if (node.data.Equals(end)||node.Equals(node2))
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

            
          
            while (w.Count > 0)
            {
                node2 = w.Dequeue();
                Console.Write(node2.data + " ");
                if (node.data.Equals(end)||node2.Equals(node))
                    return;
                if (node2.left != null)
                {
                    w.Enqueue(node.left);
                }
                if (node2.right != null)
                {
                    w.Enqueue(node2.right);
                }
            }


        }
        static void branch_and_bound(Node node, String end)
        {

            Queue<Node> q = new Queue<Node>();
            int cost=0;
            q.Enqueue(node);
            List<Node> nodos = new List<Node>();

            while (q.Count > 0)
            {


                node = q.Dequeue();
                Console.Write(node.data + " " + "->" + node.distance + " ");
                cost = cost +node.distance;
                if (node.data.Equals(end))
                {
                   if (cost > node.distance)
                    {
                        Console.WriteLine(cost);
                        if (q.Dequeue() == null)
                        {
                            Console.WriteLine("Best path posible");
                            return;
                        }
                        else {
                            Console.WriteLine("not best path posible");
                           node= q.Dequeue();
                        }
                    }
                   else {
                        Console.Write(cost);
                        return;
                    }
                }
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                    node.left.distance = node.distance + node.left.distance;
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                    node.right.distance = node.distance + node.right.distance;
                }

                nodos = new List<Node>(q);
                nodos = nodos.OrderBy(o => o.distance).ToList();
                q = new Queue<Node>(nodos);

            }



        }

        static void best_first(Node node, String end) {

            Queue<Node> q = new Queue<Node>();
            
            q.Enqueue(node);
            List<Node> nodos = new List<Node>();
           
            while (q.Count > 0)
            {
                
                
                node = q.Dequeue();
                Console.Write(node.data + " "+"->"+node.distance+" ");
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
                nodos = new List<Node>(q);
                nodos = nodos.OrderBy(o => o.distance).ToList();
                q = new Queue<Node>(nodos);
            }
            
            
           
        }

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
                new Node("A", new Node("B",new Node("C",2,3), new Node("D",2,1),1,3),
                new Node("E",new Node("F",new Node("H", 3, 1),null,2,4), new Node("G", new Node("H", 3, 1), null,2,1),2,2),0,1);
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
            Console.WriteLine();
            Console.WriteLine("Best First->"); best_first(tree2, "H");
            Console.WriteLine();
            Console.WriteLine("Branch&Bound->"); branch_and_bound(tree2, "H");
            Console.WriteLine();
            Console.WriteLine("Bidirectional->"); bidirectional(tree2, "H");
            Console.ReadKey();


        }
    }
}
