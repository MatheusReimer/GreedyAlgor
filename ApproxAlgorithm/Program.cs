using DijkstraAlgorithm;
using FractionalKnapsackProblem;

namespace ApproxAlgorithm {
    class Program {
        static void Main(string[] args) {
            // Test Knapsack Problem
            KnapSackProblem();
            // Test Fractional Knapsack Problem
            FractionalKnapsackProblem();
            // Test Djikstra Problem
            DjikstraProblem();
        }

        private static void KnapSackProblem(){
            // <---- Expand lines to see problem details
            // PROBLEM AT: https://www.youtube.com/watch?v=lfQvPHGtu6Q&t=692s
            /*
            Problem: 
            Given a set of items, each with a weight and a value, 
            determine the maximum value that can be obtained by selecting 
            a subset of the items such that the total weight does not exceed a given capacity.

            Solution: 
            The Knapsack algorithm uses dynamic programming to find the maximum value that can be obtained. 
            It constructs a 2D array where each cell represents the maximum value that can be obtained with a given capacity and a subset of items.
            It iterates through each item and calculates the maximum value by either including the current item or excluding it based on its weight.

            */
            int[] values = { 19, 9, 9, 6 };
            int[] weights = { 22,10,9,7 };
            int capacity = 25;
            int maxValue = KnapsackProblem.Knapsack.Solve(values, weights, capacity);
            Console.WriteLine("Knapsack problem: Maximum value that can be obtained: " + maxValue);
        }

        private static void FractionalKnapsackProblem(){
            // <---- Expand lines to see problem details
            // PROBLEM AT: https://www.youtube.com/watch?v=lfQvPHGtu6Q&t=692s
            /*
            Problem:
            Given a set of items, each with a weight and a value, and a knapsack with a maximum weight capacity,
            determine the maximum total value that can be obtained by selecting fractions of items to include in the knapsack.
            Unlike the 0/1 Knapsack Problem, where items cannot be divided, in the Fractional Knapsack Problem, fractions of items can be taken.

            Solution: The Fractional Knapsack Problem is solved by the Greedy Algorithm.
            It sorts the items based on their value per unit weight (value/weight ratio) in non-increasing order and then iteratively
            adds items to the knapsack until it is full. If there is still capacity left in the knapsack, 
            it takes fractions of the next item with the highest value per unit weight until the knapsack is full. 
            This algorithm provides an optimal solution in polynomial time.
            */
            int[] values = { 19, 9, 9, 6 };
            int[] weights = { 22,10,9,7 };
            int capacity = 25;

            double maxValue = FractionalKnapsack.MaxValue(values, weights, capacity);
            Console.WriteLine("Maximum value that can be obtained: " + maxValue);
        }

        private static void DjikstraProblem(){
            //PROBLEM AT: https://www.youtube.com/watch?v=EFg3u_E6eHU
            // <---- Expand lines to see problem details
            /*
            Problem: 
            Given a graph and a source vertex in the graph, 
            find the shortest paths from the source to all vertices in the graph.

            Solution: 
            Dijkstra's algorithm is a Greedy algorithm that finds the shortest path from a source vertex to all other vertices in the graph.
            It maintains a set of vertices whose shortest distance from the source is already known. 
            It repeatedly selects the vertex with the minimum distance from the source that is not yet included in the set and updates the distances of its adjacent vertices.
            This algorithm provides the shortest path from the source to all other vertices in the graph.
            */  
            int[,] graph = new int[,] {
                //  A   B   C   D   E   F   G
                {  0,  0,  3,  0,  0,  2,  0 }, // A
                {  0,  0,  0,  1,  2,  6,  2 }, // B
                {  3,  0,  0,  4,  1,  2,  0 }, // C
                {  0,  1,  4,  0,  0,  0,  0 }, // D
                {  0,  2,  1,  0,  0,  3,  0 }, // E
                {  2,  6,  2,  0,  3,  0,  5 }, // F
                {  0,  2,  0,  0,  0,  5,  0 }  // G
            };
            Dijkstra dijkstra = new Dijkstra(graph);
            dijkstra.ShortestPath('F', 'G');
        }
    }
}
