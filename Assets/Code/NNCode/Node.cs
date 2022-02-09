using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Node 
{
    public Dictionary<Node,float> Connections=new Dictionary<Node,float>();
    public Dictionary<string,string> test=new Dictionary<string,string>();
    public bool isInput;
    public float Amount;
    public string Name;

    public void CreateConnection(Node node,float weight)
    {
        Connections.Add(node,weight);
    }
    public void ChangeWeight(Node node,float Change,bool isSet)
    {
        if(isSet)
        {
            Connections[node]=Change;
        }
        else
        {
            Connections[node]+=Change;
        }
    }
    public Node(float value,string Name,bool isInput)
    {
        this.Name=Name;
        Amount=value;
        this.isInput=isInput;
    }
}
