using System;
using System.Collections.Generic;

namespace bfs_and_dfs
{
    public class Node
    {
        public Node left;
        public Node right;
        public String data;
        public int depht;
        public int distance;

        public Node(String data, Node left, Node right) {
            this.data = data;
            this.right = right;
            this.left = left;
        }

        public Node(String data, Node left, Node right, int depht,int dis)
        {
            this.data = data;
            this.right = right;
            this.left = left;
            this.depht = depht;
            this.distance = dis;
        }

        public Node(String data) {
            this.data = data;
            this.left = null;
            this.right = null;
        }


        public Node(String data,int d,int dis)
        {
            this.data = data;
            this.distance = dis;
            depht = d;
            this.left = null;
            this.right = null;
        }
    }
}