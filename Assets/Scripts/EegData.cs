using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;

public class EegData : MonoBehaviour
{
    private static TcpClient _socketConnection1;
    public string IP = "localhost";
    public int Port = 15361;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            /*
             * Connect to the OpenVibe Acquisition Server. Unless settings have been modified
             * or you're running OpenVibe on a different machine, the address should be
             * localhost and the port 15361. These settings are in Acquisition Server -> Preferences.
             */
            _socketConnection1 = new TcpClient("localhost", 15361);
            Debug.Log("Successfully connected to OpenVibe");
        }
        catch (SocketException se)
        {
            Debug.Log("Socket exception: " + se);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SendTrigger(111111);
        }
        
    }

    private void SendTrigger(int eventId)
    {
        var stream = _socketConnection1.GetStream();

        if (!stream.CanWrite) return;

        var buffer = BitConverter.GetBytes((ulong)0);
        var eventTag = BitConverter.GetBytes((ulong)eventId);

        var sendArray = buffer.Concat(eventTag.Concat(buffer)).ToArray();

        stream.Write(sendArray, 0, sendArray.Length);
    }
}
