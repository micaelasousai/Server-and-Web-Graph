
// Task 2: Web Graph

namespace Graphs {


	// Create a class for Edge
	public class Edge
	{
		public WebPage AdjVertex { get; set; }
		public int Cost { get; set; }

		public Edge(WebPage webpage)
		{
			AdjVertex = webpage;
			Cost = -1;
		}
	}

	public class WebPage
	{
		public string Name { get; set; }    // Vertex name (webpage name)
		public string Server { get; set; }
		public List<Edge> E { get; set; }   // List of adjancency vertices (webpages)


		// Constructor for Web page
		public WebPage(string name, string host)
		{
			Name = name;
			Server = host;
			// Keep track of list of edges
			E = new List<Edge>();
		}

		// Find link method
		// Returns the index of the given adjacent vertex in E; otherwise returns -1
		// Time complexity: O(n) where n is the number of vertices
		public int FindLink(string name)
		{
			int i;
			for (i = 0; i < E.Count; i++)
			{
				if (E[i].AdjVertex.Name.Equals(name))
					return i;
			}
			return -1;
		}
	}
	public class WebGraph
	{
		private List<WebPage> V;

		// Create an empty WebGraph
		public WebGraph()
		{
			V = new List<WebPage>();
		}

		// Return the index of the webpage with the given name; otherwise return -1
		private int FindPage(string name)
		{
			int i;
			for (i = 0; i < V.Count; i++)
			{
				if (V[i].Name.Equals(name))
					return i;
			}
			return -1;
		}

		// Add a webpage with the given name and store it on the host server
		// Return true if successful; otherwise return false
		public bool AddPage(string name, string host, ServerGraph S)
		{
			if (FindPage(name) == -1)
			{
				WebPage page = new WebPage(name, host);
				V.Add(page);

				// Connect it to server graph
				// Call Method Add WebPage
				S.AddWebPage(page, host);

				return true;
			}
			return false;
		}

		// Remove the webpage with the given name, including the hyperlinks
		// from and to the webpage
		// Return true if successful; otherwise return false
		public bool RemovePage(string name, ServerGraph S)
		{
			int i, j, k;
			if ((i = FindPage(name)) > -1)
			{
				for (j = 0; j < V.Count; j++)
				{
					for (k = 0; k < V[j].E.Count; k++)
						if (V[j].E[k].AdjVertex.Name.Equals(name)) // Incident edge
						{
							V[j].E.RemoveAt(k);
							break; // Since there are no duplicate edges
						}
				}
				V.RemoveAt(i);

				// Remove webpage from the list of webpages of host server
				// Get the name of the server where the webpage is hosted using method findhost
				string serverName = S.FindHost(name);
				// Call method remove webpage from server graph class
				S.RemoveWebPage(name, serverName);

				// return true if removal is successful 
				return true;
			}

			// Return false if removal is unsuccessful
			return false;

		}

		// Add a hyperlink from one webpage to another
		// Return true if successful; otherwise return false
		public bool AddLink(string from, string to)
		{
			int i, j;
			// int k = 0;
			Edge e;

			// Do the vertices exist?
			if ((i = FindPage(from)) > -1 && (j = FindPage(to)) > -1)
			{
				// Does the edge not already exist?
				if (V[i].FindLink(to) == -1)
				{
					e = new Edge (V[j]);
					V[i].E.Add(e);
					// This indicates that an edge exists 
					e.Cost = 1;
					return true;
				}
			}
			return false;
		}

		// Remove a hyperlink from one webpage to another
		// Return true if successful; otherwise return false
		public bool RemoveLink(string from, string to)
		{
			int i, j;
			if ((i = FindPage(from)) > -1 && (j = V[i].FindLink(to)) > -1)
			{
				V[i].E.RemoveAt(j);
				return true;
			}
			return false;
		}

		// Return the average length of the shortest paths from the webpage with
		// given name to each of its hyperlinks
		// Hint: Use the method ShortestPath in the class ServerGraph

        //idk what this is, sorry
        public float AvgShortestPaths(string name, ServerGraph S)
        {
            int [] nameOfLink = FindLink(name); // setting variable to get the array of the index of the name of FindLink
            int averageShortPath = 0; // creating a variable and setting it to 0

            
            int[] hyperLinks = E.Length; //count the amount of hyperlinks in the list
            if(E.Length = 0) //if no hyperlink exists, return false. This is so that when calculating averageShorPath it will not have an error
            {
                return -1;
            }

           if(S.ShortestPath(dist) <= 0) //if destination does not exist, return averageShortPath to be false
            {
                return -1;
            }
           else
            {
                int destination = S.ShortestPath(nameOfLink); //call the Method in ServerGraph for the ShortestPath and set it to name of the hyperlink
                averageShortPath = S.ShortestPath(dist) / hyperLinks; // get all of the hyperlink's path and divide it with the amount of list for average path  
            }

            return averageShortPath;
        }


		// PrintPages
		// Prints out all vertices of a graph
		// Time complexity: O(n)
		// To be called inside the PrintGraph method
		public void PrintPages()
		{
			for (int i = 0; i < V.Count; i++)
				Console.WriteLine(V[i].Name);
			Console.ReadLine();
		}

		// PrintLinks
		// Prints out all edges of the graph
		// Time complexity: O(m)
		// To be called inside the PrintGraph method
		public void PrintLinks()
		{
			int i, j;
			for (i = 0; i < V.Count; i++)
				for (j = 0; j < V[i].E.Count; j++)
					Console.WriteLine("(" + V[i].Name + "," + V[i].E[j].AdjVertex.Name + ")");
			Console.ReadLine();
		}

		// Print the name and hyperlinks of each webpage
		public void PrintGraph()
		{
			PrintPages();
			PrintLinks();
		}
		
	}
}
