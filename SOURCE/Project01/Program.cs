using System;
using System.Collections.Generic;
using Project01.Utils;
using Project01.Entity;
using Project01.Service;
namespace Project01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AdjList> dataset = DataIOHelper.fetchAdjLists("DataInput/input.txt");
            foreach (AdjList adjList in dataset)
            {
                Console.WriteLine("--- Do thi {0} ---", adjList.getId());
                GraphService.checkIfGraphIsWheelGraph(adjList);
                GraphService.checkIfGraphIsButterflyGraph(adjList);
                GraphService.checkIfGraphIsStarGraph(adjList);
                GraphService.checkIfGraphIsEmptyGraph(adjList);
                GraphService.checkIfGraphIsCycleGraph(adjList);
                GraphService.checkIfGraphIsMothGraph(adjList);
                GraphService.checkIfGraphIsFriendshipGraph(adjList);
                GraphService.checkIfGraphIsBarbellGraph(adjList);
                GraphService.graphPartitioning(adjList);
                Console.WriteLine("------------------------------------");
            }
            
        }
    }
}
