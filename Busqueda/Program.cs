using System;
using System.IO;
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
            /* Queue<Node> q = new Queue<Node>();
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
             */
            dfs_traversal(node, end);

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
                Console.Write(node.data + " " + "->");
                cost = cost +node.distance;
                if (node.data.Equals(end))
                {
                   if (cost > node.distance)
                    {
                        
                        if (q.Dequeue() == null)
                        {
                            //Console.WriteLine("Best path posible");
                            return;
                        }
                        else {
                            //Console.WriteLine("not best path posible");
                            if (q.Count>0)
                            {
                                node = q.Dequeue();
                            }
                        }
                    }
                   else {
                        
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
                Console.Write(node.data + " "+"->");
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
                new Node("Aberdeen",
                new Node("Pierre",
                new Node("North Platte"),new Node("Rapid City")),
                new Node("Watertown SD",
                    new Node("Syracuse"), new Node("Minneapolis",
                    new Node("Rapid City"), null)));
            return root;
        }

        static Node sample_tree2()
        {
            Node root =
                new Node("Aberdeen", new Node("Pierre",new Node("North Platte",2,264), new Node("Rapid City", new Node("Siaux City", 3, 429), null,2,191),1,159),
                new Node("Watertown SD",new Node("Syracuse",2,72), new Node("Minneapolis", new Node("Siaux City", 3, 300), null,2,212),2,2),0,1);
            return root;
        }

        static void Main(string[] args)
        {

            using (var reader = new StreamReader(@"C:\Users\maria\source\repos\Busqueda\Ciudades.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

            Node tree = sample_tree();
            Node tree2 = sample_tree2();
            
            Console.WriteLine("BFS->"); bfs_traversal(tree,"Rapid City");
            Console.WriteLine();
            Console.WriteLine("DFS->"); dfs_traversal(tree2,"Siaux City");
            Console.WriteLine();
            Console.WriteLine("DFS Limited->"); dfs_limited_traversal(tree2, "Siaux City",2);
            Console.WriteLine();
            Console.WriteLine("Best First->"); best_first(tree2, "Siaux City");
            Console.WriteLine();
            Console.WriteLine("Branch&Bound->"); branch_and_bound(tree2, "Siaux City");
            Console.WriteLine();
            Console.WriteLine("Bidirectional->"); bidirectional(tree2, "Siaux City");
            Console.ReadKey();


        }
    }
}
