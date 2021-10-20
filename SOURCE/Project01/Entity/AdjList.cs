using System;
using System.Collections.Generic;
using System.Text;

namespace Project01.Entity
{
    class AdjList
    {
        private List<Vertex> verticesList;

        private int id;

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public AdjList()
        {
            this.verticesList = new List<Vertex>();
        }

        public AdjList(List<Vertex> _verticesList)
        {
            this.verticesList = _verticesList;
        }
        public List<Vertex> getVerticesList()
        {
            return this.verticesList;
        }

        public void addVertex(Vertex vertex)
        {
            try
            {
                this.verticesList.Add(vertex);
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi them dinh vao danh sach ke: " + e.Message);
            }
        }

        public int getVertexCount()
        {
            return this.verticesList.Count;
        }

        public int countVerticesWithDegree(int degree)
        {
            int result = 0;
            foreach (Vertex vertex in this.verticesList)
            {
                if (vertex.getDegree() == degree)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
