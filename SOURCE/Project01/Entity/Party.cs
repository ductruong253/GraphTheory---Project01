using System;
using System.Collections.Generic;
using System.Text;

namespace Project01.Entity
{
    class Party
    {
        private List<Vertex> members;
        private string neighbors;

        public Party() { }
        public Party(Vertex vertex)
        {
            this.members = new List<Vertex>();
            members.Add(vertex);
        }

        public void addMember(Vertex vertex)
        {
            this.members.Add(vertex);
        }

        public List<Vertex> getMembers()
        {
            return this.members;
        }

        public void setNeighbors(string neighbors)
        {
            this.neighbors = neighbors;
        }

        public string getNeighbors()
        {
            return this.neighbors;
        }
    }
}
