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
            string chosen = "";
            Console.WriteLine("DO AN LY THUYET DO THI - 01");
            Console.WriteLine("Ten-MSSV: Dang Duc Truong - 20880108");
            Console.WriteLine("Ten-MSSV: Tran Thi Tuyet Ngan - 2088010");
            Console.WriteLine("*** Luu y truoc khi dung:");
            Console.WriteLine("  > Vui long luu file input.txt cua do an phan cai dat vao folder: ~\\Project01\\DataInput");
            List<AdjList> dataset = DataIOHelper.fetchAdjLists("DataInput/input.txt"); ;
            while (chosen != "exit")
            {
                Console.WriteLine("*****************************************************************************");
                Console.WriteLine("*    [1].     In tap du lieu");
                Console.WriteLine("*    [2].     Chay tung phan");
                Console.WriteLine("*    [3].     Chay toan bo");
                Console.WriteLine("*    [clear]. Xoa man hinh");
                Console.WriteLine("*    [exit].  Thoat");
                Console.Write("*    Vui long nhap lua chon: ");
                chosen = Console.ReadLine();
                Console.WriteLine(">>>");
                switch (chosen)
                {
                    case "1":
                        {
                            DataIOHelper.printDataSet(dataset);
                            break;
                        }
                    case "2":
                        {
                            Console.Write("*    Vui long nhap ma so do thi muon chay [0 - {0}]: ", dataset.Count - 1);
                            try
                            {
                                int adjListId = int.Parse(Console.ReadLine());
                                if ((adjListId >= 0) && (adjListId <= dataset.Count-1))
                                {
                                    Console.WriteLine("--- Do thi {0} ---", adjListId);
                                    GraphService.checkIfGraphIsWheelGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsButterflyGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsStarGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsEmptyGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsCycleGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsMothGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsFriendshipGraph(dataset[adjListId]);
                                    GraphService.checkIfGraphIsBarbellGraph(dataset[adjListId]);
                                    GraphService.graphPartitioning(dataset[adjListId]);
                                    Console.WriteLine("------------------------------------");
                                }
                                else throw new Exception("Ma so do thi khong hop le.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Loi: " + e.Message);
                            }
                            break;
                        }
                    case "3":
                        {
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
                            break;
                        }
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        chosen = "exit";
                        Console.WriteLine("Thoat chuong trinh...");
                        Console.WriteLine("*****************************************************************************");
                        break;
                }
            }
        }
    }
}
