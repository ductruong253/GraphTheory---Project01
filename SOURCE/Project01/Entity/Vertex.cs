using System;
using System.Collections.Generic;
using System.Text;

namespace Project01.Entity
{
    class Vertex
    {
        private int id;

        private List<int> neighbors;

        public Vertex()
        {
            this.neighbors = new List<int>();
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public int getDegree()
        {
            return this.neighbors.Count;
        }

        public List<int> getNeighbors()
        {
            return this.neighbors;
        }

        public void addNeighbor(int neighborVertexId)
        {
            try
            {
                this.neighbors.Add(neighborVertexId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi them dinh vao danh sach ke: " + e.Message);
            }
        }

        public string neighborToString()
        {
            string result = "";
            foreach (int neighbor in this.neighbors)
            {
                result = result + neighbor + " ";
            }
            return result;
        }
    }
}
