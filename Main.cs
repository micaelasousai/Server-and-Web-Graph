// Name: Micaela Sousa (0722724), Rachel Lee (0696297), Boaz Chan (0686531)
// Assignment 1

// Program description:
// TO COMPLETE!!!

// Data dictionary: 
// TO COMPLETE!!!

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

		// Add and remove hyperlinks between the webpages.

		// Remove both webpages and servers.

		// Determine the critical servers of the remaining Internet.

		// Calculate the average shortest distance to the hyperlinks of a given webpage.

		Console.ReadLine();
	}
}
