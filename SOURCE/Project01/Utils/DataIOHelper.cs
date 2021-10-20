using System;
using System.Collections.Generic;
using System.IO;
using Project01.Entity;
namespace Project01.Utils
{
    static class DataIOHelper
    {
        static List<string> readRawContentFromFile(string filePath)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @filePath);
            List<string> rawInputContent = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(path);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    rawInputContent.Add(line);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi doc du lieu tho: " + e.Message);
            }

            return rawInputContent;
        }

        public static List<AdjList> fetchAdjLists(string filePath)
        {
            List<AdjList> adjListDataSet = new List<AdjList>();
            List<string> rawData = readRawContentFromFile(filePath);
            int rowCount = rawData.Count;
            try
            {
                int totalAdjListCount = int.Parse(rawData[0]);
                rawData.RemoveAt(0);
                for (int adjListId = 0; adjListId < totalAdjListCount; adjListId++)
                {
                    AdjList adjList = new AdjList();
                    int currentAdjListVertexCount = int.Parse(rawData[0]);
                    if (currentAdjListVertexCount >= rawData.Count) throw new Exception("Danh sach ke bi thieu.");
                    rawData.RemoveAt(0);
                    for (int vertexId = 0; vertexId < currentAdjListVertexCount; vertexId++)
                    {
                        Vertex vertex = new Vertex();
                        vertex.setId(vertexId);
                        string tempLine = "";
                        tempLine = rawData[0];
                        int[] tempRow = Array.ConvertAll(tempLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
                        int neighborCount = tempRow[0];
                        if (neighborCount == tempRow.Length - 1)
                        {
                            for (int col = 1; col < tempRow.Length; col++)
                            {
                                int neighbor = tempRow[col];
                                if ((!vertex.getNeighbors().Contains(neighbor)) && (neighbor < currentAdjListVertexCount))
                                {
                                    vertex.addNeighbor(neighbor);
                                }
                                else throw new Exception("Dinh ke bi trung hoac co so hieu vuot qua so dinh duoc khai bao.");
                            }
                            rawData.RemoveAt(0);
                        }
                        else throw new Exception("So luong dinh ke khong khop voi khai bao.");
                        vertex.getNeighbors().Sort();
                        adjList.addVertex(vertex);
                    }
                    adjList.setId(adjListId);
                    adjListDataSet.Add(adjList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi nap danh sach dinh ke: " + e.Message);
                Console.Write("Vui long kiem tra lai tai dong thu {0} >>> ", (rowCount - rawData.Count + 1));
                printRawData(rawData);
            }

            return adjListDataSet;
        }

        public static void printAdjacencyMatrix(int[,] matrix)
        {
            Console.WriteLine("Ma tran ke: ");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string degListToString(int[,] degList)
        {
            string degString = "";

            if (degList.GetLength(1) == 1)
            {
                for (int index = 0; index < degList.GetLength(0); index++)
                {
                    degString += index.ToString() + "(" + degList[index, 0].ToString() + ")" + " ";
                }
            }
            else
            {
                for (int index = 0; index < degList.GetLength(0); index++)
                {
                    degString += index.ToString() + "(" + degList[index, 1].ToString() + "-" + degList[index, 0].ToString() + ")" + " ";
                }
            }
            return degString;
        }

        //For testing purpose
        public static void printRawData(List<string> rawData)
        {
            foreach (string line in rawData)
            {
                Console.WriteLine(line);
            }
        }

        public static void printDataSet(List<AdjList> dataset)
        {
            Console.WriteLine("Co {0} danh sach ke.", dataset.Count);
            foreach (AdjList adjList in dataset)
            {
                Console.WriteLine("Danh sach ke thu {0}: ", dataset.IndexOf(adjList));
                foreach (Vertex vertex in adjList.getVerticesList())
                {
                    Console.WriteLine("Dinh so {0}: {1}", adjList.getVerticesList().IndexOf(vertex), vertex.neighborToString());
                }
                Console.WriteLine("---------------------");
            }
        }
    }
}
