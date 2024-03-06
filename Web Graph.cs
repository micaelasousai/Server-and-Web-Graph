
// Web Graph

namespace Graphs
{

	public class WebPage
	{
		public string Name { get; set; }    // Vertex name (webpage name)
		public string Server { get; set; }
		public List<WebPage> E { get; set; }   // List of adjancency vertices (webpages)


		// Constructor for Web page
		public WebPage(string name, string host)
		{
			Name = name;
			Server = host;
			// Keep track of list of edges
			E = new List<WebPage>();
		}

		// Find link method
		// Returns the index of the given adjacent vertex in E; otherwise returns -1
		// Time complexity: O(n) where n is the number of vertices
		public int FindLink(string name)
		{
				
			for (int i = 0; i < E.Count; i++)
            {
				if (E[i].Name == name)
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

				// If adding the page is successful, return true
				return true;
			}
			return false;
		}

		// Remove the webpage with the given name, including the hyperlinks
		// from and to the webpage
		// Return true if successful; otherwise return false
		public bool RemovePage(string name, ServerGraph S)
		{
			// Find the index of the page to be removed in V
			int i = FindPage(name);
			
			if ( i > -1)
			{
				// Remove the hyperlinks from the webpage
				for (int j = 0; j < V[i].E.Count; j++)
                {
					// Remove the webpage at index j in the list E 
					V[i].E.Remove(V[i].E[j]);
                }

				// Remove the hyperlinks to the webpage
				for (int k = 0; k < V.Count; k++)
                {
					// Remove the hyperlinks to the webpage
					if (V[k].E.Contains(V[i]))
						V[k].E.Remove(V[i]);
                }

				// Remove webpage from the list of webpages
				V.RemoveAt(i);

				// Call method remove webpage from server graph class
				S.RemoveWebPage(name);

				// return true if removal is successful 
				return true;
			}

			// Return false if removal is unsuccessful
			Console.WriteLine("The removal was unsuccessful. Provide a valid webpage name.");
			return false;

		}

		// Add a hyperlink from one webpage to another
		// Return true if successful; otherwise return false
		public bool AddLink(string from, string to)
		{
			int i, j;
			
			// Do the vertices exist?
			if ((i = FindPage(from)) > -1 && (j = FindPage(to)) > -1)
			{
				// Does the edge not already exist?
				if (V[i].FindLink(to) == -1)
				{
					// If an edge doesn't exist already, create link
					V[i].E.Add(V[j]);
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

        public float AvgShortestPaths(string name, ServerGraph S)
        {
			// Get the server of the given page
			// Get each hyperlinked page
			// For each page:
			// Get the server that it is on
			// Compute the shortest path from the starting server to the server hosting the hyperlinked page
			// Compute the average as normal
			
			// Check if the name of the page is valid
			if (FindPage(name) == -1)
            {
				Console.WriteLine("No webpage with the given name. Provide a valid name.");
				return -1;
            }
			
			WebPage page = V[FindPage(name)];

			// declare variables
			string hostServerName = page.Server;
			int pathSum = 0;
			bool flag = false;

			// Foreach loop to find the path
			foreach(WebPage p in page.E)
            {
				int dist = S.ShortestPath(hostServerName, p.Server);
				if (dist != -1)
                {
					pathSum += dist;
                }
				else
                {
					flag = true;
                }
            }
			if (flag)
            {
				Console.WriteLine("Not all hyperlinks accessible");
            }
			// return the average
			return (float)(pathSum) / page.E.Count;

        }


        // PrintPages
        // Prints out all vertices of a graph
        // Time complexity: O(n)
        // To be called inside the PrintGraph method
        public void PrintPages()
		{
			for (int i = 0; i < V.Count; i++)
				Console.WriteLine(V[i].Name);
		}

		// PrintLinks
		// Prints out all edges of the graph
		// Time complexity: O(m)
		// To be called inside the PrintGraph method
		public void PrintLinks()
		{
			foreach (WebPage p in V)
			{
				foreach (WebPage adjacent in p.E)
                {
					Console.WriteLine("(" + p.Name + "," + adjacent.Name + ")");
				}
			}
		}

	// Print the name and hyperlinks of each webpage
	public void PrintGraph()
	{
			PrintPages();
			PrintLinks();
		}

	}
}
