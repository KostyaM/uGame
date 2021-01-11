using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ServerUtils 
{
    public static bool isListeningClients = false;
    public const int CONNECTIONS_COUNT = 4;

    public static void startServer()
    {
        isListeningClients = true;
        while(isListeningClients)
        {
           
           
              
            
        }
    }

    public static void stopServer()
    {
        isListeningClients = false;
    }
}
