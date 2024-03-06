// The Main 

using System;
using Graphs;

public static class Assignment1
{
	public static void Main()
	{
		// Declare variables
		int i, j;

		// Instantiate a server graph and a web graph.
		ServerGraph S = new ServerGraph("server0");
		WebGraph W = new WebGraph();

		// Add a number of servers.
		S.AddServer("server1", "server0");
		S.AddServer("server2", "server0");
		S.AddServer("server3", "server1");
		S.AddServer("server4", "server1");
		S.AddServer("server5", "server0");
		S.AddServer("server6", "server3");

		// Print all the servers
		S.PrintServers();
		S.PrintConnections();

		// Add additional connections between servers.
		
		// Use two for loop to get the 2 servers to be connected
		//for (i = 0; i < 7; i += 2)
		//	for (j = 0; j < 7; j += 3)
		//	{
		//		S.AddConnection((char)(i + 'a'), (char)(j + 'a'));
		//	}

		//H.PrintConnections();
		//Console.ReadKey();

		// Add a number of webpages to various servers.
		W.AddPage("webpage0", "server3", S);
		W.AddPage("webpage1", "server5", S);
		W.AddPage("webpage2", "server4", S);
		W.AddPage("webpage3", "server3", S);
		W.AddPage("webpage4", "server2", S);
		W.AddPage("webpage5", "server2", S);
		W.AddPage("webpage6", "server1", S);

		// Add and remove hyperlinks between the webpages.

		// Remove both webpages and servers.

		// Determine the critical servers of the remaining Internet.

		// Calculate the average shortest distance to the hyperlinks of a given webpage.

		Console.ReadLine();
	}
}
