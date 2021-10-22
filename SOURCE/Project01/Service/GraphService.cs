using System;
using System.Collections.Generic;
using System.Text;
using Project01.Entity;

namespace Project01.Service
{
    class GraphService
    {
        public static int countVertexWithDegree(List<Vertex> verticesList, int degree)
        {
            int counter = 0;
            foreach (Vertex vertex in verticesList)
            {
                if (vertex.getDegree() == degree) counter++;
            }
            return counter;
        }

        public static Vertex getMaxDegreeVertex(List<Vertex> verticesList)
        {
            Vertex maxDegreeVertex = verticesList[0];
            foreach (Vertex vertex in verticesList)
            {
                if (vertex.getDegree() > maxDegreeVertex.getDegree())
                {
                    maxDegreeVertex = vertex;
                }
            }
            return maxDegreeVertex;
        }
        public static bool isAllVisited(bool[] visitedList)
        {
            int counter = 0;
            foreach (bool visited in visitedList)
            {
                if (visited) counter++;
            }
            if (counter == visitedList.Length) { return true; } else return false;
        }

        public static void checkIfGraphIsCycleGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int totalVertices = verticesList.Count;
            Vertex next = verticesList[0];
            int nextPointIndex;
            nextPointIndex = 0;
            bool[] visited = new bool[totalVertices];
            int degree2VertexCount = countVertexWithDegree(verticesList, 2);
            if (degree2VertexCount == totalVertices)
            {
                while (true)
                {
                    if (!visited[nextPointIndex])
                    {
                        visited[nextPointIndex] = true;
                        foreach (int neighbor in next.getNeighbors())
                        {
                            if (!visited[neighbor])
                            {
                                nextPointIndex = neighbor;
                                next = verticesList[nextPointIndex];
                                break;
                            }
                        }
                    }
                    else if (isAllVisited(visited))
                    {
                        Console.WriteLine("Do thi vong: k={0}", totalVertices);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Do thi vong: Khong");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Do thi vong: Khong");
            }
        }

        public static void checkIfGraphIsWheelGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int totalVertices = verticesList.Count;
            Vertex centerVertex = getMaxDegreeVertex(verticesList);
            bool[] visited = new bool[totalVertices];
            int centerVertexDegree = centerVertex.getDegree();
            visited[centerVertex.getId()] = true;
            int degree3VertexCount = countVertexWithDegree(verticesList, 3);
            if ((centerVertexDegree == (totalVertices - 1)) && (degree3VertexCount == (totalVertices - 1)))
            {
                int nextPointIndex;
                if ((centerVertex.getId() == 0) || (centerVertex.getId() == totalVertices - 1))
                {
                    nextPointIndex = 1;
                }
                else nextPointIndex = 0;
                Vertex next = verticesList[nextPointIndex];
                while (true)
                {
                    if (!visited[nextPointIndex])
                    {
                        visited[nextPointIndex] = true;
                        foreach (int neighbor in next.getNeighbors())
                        {
                            if ((neighbor != centerVertex.getId()) && (!visited[neighbor]))
                            {
                                nextPointIndex = neighbor;
                                next = verticesList[nextPointIndex];
                                break;
                            }
                        }
                    }
                    else if (isAllVisited(visited))
                    {
                        Console.WriteLine("Do thi banh xe: k={0}", totalVertices);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Do thi banh xe: Khong");
                        break;
                    }
                }
            }
            else Console.WriteLine("Do thi banh xe: Khong");
        }

        public static void checkIfGraphIsEmptyGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int zeroDegreeVertexCount = countVertexWithDegree(verticesList, 0);
            if (zeroDegreeVertexCount == adjList.getVertexCount())
            {
                Console.WriteLine("Do thi trong: k={0}", zeroDegreeVertexCount);
            }
            else Console.WriteLine("Do thi trong: Khong");
        }

        public static void checkIfGraphIsButterflyGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int degree2VertexCount = countVertexWithDegree(verticesList, 2);
            int degree4VertexCount = countVertexWithDegree(verticesList, 4);
            if ((degree2VertexCount == 4) && (degree4VertexCount == 1))
            {
                Console.WriteLine("Do thi hinh con buom: Co");
            }
            else Console.WriteLine("Do thi hinh con buom: Khong");
        }

        public static void checkIfGraphIsStarGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int degree1VertexCount = countVertexWithDegree(verticesList, 1);
            int vertexCount = adjList.getVertexCount();
            int centerVertexCount = countVertexWithDegree(verticesList, vertexCount - 1);
            if ((degree1VertexCount == vertexCount - 1) && (centerVertexCount == 1))
            {
                Console.WriteLine("Do thi hinh sao: Co");
            }
            else Console.WriteLine("Do thi hinh sao: Khong");
        }

        public static void checkIfGraphIsMothGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int degree1VertexCount = countVertexWithDegree(verticesList, 1);
            int degree2VertexCount = countVertexWithDegree(verticesList, 2);
            int degree3VertexCount = countVertexWithDegree(verticesList, 3);
            int degree5VertexCount = countVertexWithDegree(verticesList, 5);
            if ((degree1VertexCount == 2) && (degree2VertexCount == 2) && (degree3VertexCount == 1) && (degree5VertexCount == 1))
            {
                Console.WriteLine("Do thi hinh con ngai: Co");
            }
            else
            {
                Console.WriteLine("Do thi hinh con ngai: Khong");
            }

        }

        public static void checkIfGraphIsFriendshipGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int totalVertices = verticesList.Count;
            int degree2VertexCount = countVertexWithDegree(verticesList, 2);
            int centerVertexDegree = totalVertices - 1;
            int centerVertexCount = countVertexWithDegree(verticesList, centerVertexDegree);
            int cycleCount = (totalVertices - 1) / 2;
            if ((centerVertexCount == 1) && (degree2VertexCount == (totalVertices - 1)) && (totalVertices % 2 == 1))
            {
                Console.WriteLine("Do thi tinh ban: k={0}", cycleCount);
            }
            else
            {
                Console.WriteLine("Do thi tinh ban: Khong");
            }

        }

        public static void checkIfGraphIsBarbellGraph(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            int totalVertices = verticesList.Count;
            int completeGraphVertexCount = totalVertices / 2;
            int degreeOfMemberVertex = completeGraphVertexCount - 1;
            int degreeOfConnectorVertex = completeGraphVertexCount;
            int memberVertexCount = countVertexWithDegree(verticesList, degreeOfMemberVertex);
            int connectorVertexCount = countVertexWithDegree(verticesList, degreeOfConnectorVertex);
            if ((memberVertexCount == totalVertices - 2) && (connectorVertexCount == 2))
            {
                Console.WriteLine("Do thi Barbell: k={0}", completeGraphVertexCount);
            }
            else
            {
                Console.WriteLine("Do thi Barbell: Khong");
            }
        }

        public static void graphPartitioning(AdjList adjList)
        {
            List<Vertex> verticesList = new List<Vertex>(adjList.getVerticesList());
            List<Party> partite = new List<Party>();
            Vertex vertex;
            while (verticesList.Count>0)
            {
                vertex = verticesList[0];
                if (partite.Count == 0)
                {
                    Party partite0 = new Party(verticesList[0]);
                    partite.Add(partite0);
                    verticesList.RemoveAt(0);
                    continue;
                }
                else
                {
                    foreach(Party party in partite)
                    {
                        foreach(Vertex member in party.getMembers())
                        {
                            if (member.getNeighbors().Contains(vertex.getId()))
                            {
                                goto NextParty;
                            }
                        }
                        party.addMember(vertex);
                        verticesList.RemoveAt(0);
                        goto NextVertex;
                    NextParty: continue;
                    }
                    partite.Add(new Party(vertex));
                    verticesList.RemoveAt(0);
                NextVertex: continue;
                }
            }
            if (partite.Count > 1)
            {
                Console.Write("Do thi k-phan (k > 1): k={0} ", partite.Count);
                printPartite(partite);
            }
            else
            {
                Console.WriteLine("Do thi k-phan (k > 1): Khong");
            }
        }

        private static void printPartite(List<Party> partite)
        {
            foreach (Party party in partite)
            {
                Console.Write("{");
                int iteration = 0;
                foreach (Vertex member in party.getMembers())
                {
                    if (iteration > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(member.getId());
                    iteration++;
                    if (iteration < party.getMembers().Count)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("} ");
            }
            Console.WriteLine();
        }
    }
}
