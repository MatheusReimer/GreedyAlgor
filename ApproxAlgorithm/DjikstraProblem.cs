namespace DijkstraAlgorithm {
    public class Dijkstra {
        private int V; // Number of vertices
        private int[,] graph; // Adjacency matrix representation of the graph

        public Dijkstra(int[,] g) {
            V = g.GetLength(0);
            graph = g;
        }

        // A utility function to find the vertex with minimum distance value,
        // from the set of vertices not yet included in shortest path tree
        private int MinDistance(int[] dist, bool[] sptSet) {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++) {
                if (sptSet[v] == false && dist[v] <= min) {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public void PrintSolution(int[] dist) {
            Console.WriteLine("Vertex \t Distance from Source");
            for (int i = 0; i < V; i++) {
                Console.WriteLine((char)('A' + i) + " \t " + dist[i]);
            }
        }
        public int[] ShortestPath(char start, char end) {
            int startIndex = start - 'A';
            int endIndex = end - 'A';

            int[] dist = new int[V]; // shortest distance from src to i
            int[] prev = new int[V]; // store the previous node in the shortest path

            // sptSet[i] will true if vertex i is included in shortest
            // path tree or shortest distance from src to i is finalized
            bool[] sptSet = new bool[V];

            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++) {
                dist[i] = int.MaxValue;
                prev[i] = -1; // Initialize prev array
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[startIndex] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++) {
                // Pick the minimum distance vertex from the set of vertices
                // not yet processed. u is always equal to src in the first iteration.
                int u = MinDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex
                for (int v = 0; v < V; v++) {
                    // Update dist[v] only if it's not in sptSet, there is an
                    // edge from u to v, and total weight of path from src to
                    // v through u is smaller than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 &&
                        dist[u] != int.MaxValue &&
                        dist[u] + graph[u, v] < dist[v]) {
                        dist[v] = dist[u] + graph[u, v];
                        prev[v] = u;
                    }
                }
            }

            // Print the constructed distance array
            PrintSolution(dist);

            // Print the constructed path
            PrintPath(startIndex, endIndex, prev);

            return dist;
        }

        // Function to print the constructed path from start to end
        private void PrintPath(int start, int end, int[] prev) {
            if (start == end) {
                Console.Write((char)('A' + start) + " ");
            }
            else if (prev[end] == -1) {
                Console.WriteLine("No path from " + (char)('A' + start) + " to " + (char)('A' + end) + " exists");
            }
            else {
                PrintPath(start, prev[end], prev);
                Console.Write((char)('A' + end) + " ");
            }
        }
    }
}
