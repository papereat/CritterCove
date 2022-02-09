using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NueralNetwork : MonoBehaviour
{
    public List<Node> Nodes=new List<Node>();

    public void AddNode(float value,string Name,bool isInput)
    {
        Nodes.Add(new Node(value,Name,isInput));
    }
    public void AddConnection(Node Reciver,int OtherNodeID, float weight)
    {
        Reciver.CreateConnection(Nodes[OtherNodeID],weight);
    }
    public float CheckValue(Node node)
    {
        if(node.Connections.Count==0)
        {
            return node.Amount;
        }
        float tmp=0;
        foreach (Node conections in node.Connections.Keys)
        {
            Debug.Log(node.Connections[conections]);
            tmp+=CheckValueWithWeight(conections,node.Connections[conections]);
        }
        return tmp;;
    }
    float CheckValueWithWeight(Node node,float weight)
    {
        if(node.Connections.Count==0)
        {
            return node.Amount+weight;
        }
        float tmp=weight;
        foreach (Node conections in node.Connections.Keys)
        {
            tmp+=CheckValueWithWeight(conections,node.Connections[conections]);
        }
        return tmp;
        //return node.Amount+weight;
    }
    
}
