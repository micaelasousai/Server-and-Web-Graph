using System;
using Graphs;

public static class MainProgram
{
	public static void Main()
	{
		// Declare variables
		int i, j;

		//////////// Instantiate a server graph and a web graph.
		ServerGraph S = new ServerGraph("server0");
		WebGraph W = new WebGraph();

        /////////// Testing adding a server whose name is the empty string
        //S.AddServer("", "server0");
        //S.PrintGraph();

        /////////// Add a number of servers.
        S.AddServer("server1", "server0");
        S.AddServer("server2", "server0");
        S.AddServer("server3", "server1");
        S.AddConnection("server1", "server2");

        S.AddServer("server4", "server1");
        S.AddServer("server5", "server0");
        S.AddServer("server6", "server3");

        //////////// Print all the servers
        //S.PrintServers();
        //S.PrintConnections();

        //////////// Add a number of webpages to various servers.
        W.AddPage("webpage0", "server3", S);
        W.AddPage("webpage1", "server5", S);
        W.AddPage("webpage2", "server4", S);
        W.AddPage("webpage3", "server3", S);
        W.AddPage("webpage4", "server2", S);
        W.AddPage("webpage5", "server2", S);
        W.AddPage("webpage6", "server1", S);
        S.PrintGraph();

        /////////// Add hyperlinks between the webpages.
        W.AddLink("webpage0", "webpage1");
        W.AddLink("webpage1", "webpage2");
        W.AddLink("webpage2", "webpage3");
        W.AddLink("webpage3", "webpage4");
        W.AddLink("webpage4", "webpage5");
        W.AddLink("webpage5", "webpage6");
        W.AddLink("webpage6", "webpage0");

        W.PrintGraph();

        ///////////// Critical Servers testing
        ///////////// Determine the critical servers of the remaining Internet.
        //string[] servers = S.CriticalServers();
        //Console.WriteLine("Critical server(s): ");
        //foreach (string s in servers)
        //{
        //    Console.WriteLine(s);
        //}

        //////////// Remove hyperlinks between the webpages
        //W.RemoveLink("webpage0", "webpage1");
        //W.RemoveLink("webpage1", "webpage2");
        //W.PrintGraph();

        //////////// Removing servers successfully 
        //S.RemoveServer("server4", "server0");
        //S.RemoveServer("server5", "server1");
        //S.PrintGraph();

        ////////////Testing Remove WebPage
        //S.RemoveWebPage("webpage2");
        //S.RemoveWebPage("webpage4");
        //S.PrintGraph();

        ///////////// Testing remove critical server (attempt unsuccessful)
        //S.RemoveServer("server1", "server0");
        //S.PrintGraph();

        ///////////// Remove non-existent server
        //S.RemoveServer("server10", "server0");
        //S.PrintGraph();
        //W.PrintGraph();

        ////////////// Remove almost all servers successfully (everything but last server)
        //S.RemoveServer("server6", "server1");
        //S.RemoveServer("server3", "server1");
        //S.RemoveServer("server4", "server0");
        //S.RemoveServer("server5", "server0");
        //S.RemoveServer("server2", "server1");
        //S.RemoveServer("server0", "server1");
        //S.PrintGraph();
        //W.PrintGraph();

        //////////////Testing error handles for removing only 1 server
        //S.RemoveServer("server0", "server0");
        //S.PrintGraph();
        //W.PrintGraph();

        ////////////// Test case for the ShortestPath
        //int shortestPathFrom1to6 = S.ShortestPath("server1", "server6");
        //int shortestPathFrom1to2 = S.ShortestPath("server1", "server2");
        //Console.WriteLine("The shortest path from server 1 to server 6 is: " + shortestPathFrom1to6);
        //Console.WriteLine("The shortest path from server 1 to server 2 is: " + shortestPathFrom1to2);

        ////////////// Calculate the average shortest distance to the hyperlinks of a given webpage.
        ////////////// Adding more webpages for average shortest distance
        //W.AddLink("webpage1", "webpage3");
        //W.AddLink("webpage2", "webpage6");
        //W.AddLink("webpage5", "webpage0");
        //W.AddLink("webpage0", "webpage3");
        //W.AddLink("webpage4", "webpage1");
        //W.AddLink("webpage3", "webpage0");
        //W.AddLink("webpage4", "webpage2");
        //W.AddLink("webpage4", "webpage2");
        //W.AddLink("webpage4", "webpage5");
        //float avgshortdist2 = W.AvgShortestPaths("webpage6", S);
        //Console.WriteLine("The average length of the shortest paths from the webpage 6 to each of its hyperlinks: " + avgshortdist2);

        ////////////// Testing remove page for successful cases
        //W.RemovePage("webpage1", S);
        //W.RemovePage("webpage2", S);
        //W.RemovePage("webpage3", S);
        //W.RemovePage("webpage4", S);
        //W.RemovePage("webpage5", S);
        //W.RemovePage("webpage6", S);
        //W.PrintGraph();

        ////////////// Remove Webpages from web graph for unsuccessful cases:
        //W.RemovePage("webpage10", S);
        //W.PrintGraph();

        Console.ReadLine();
    }
}
