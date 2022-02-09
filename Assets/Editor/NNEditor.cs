using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NueralNetwork))]
public class NNEditor : Editor
{
    int index=0;
    int Search=0;
    //float weight=0;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NueralNetwork NN=(NueralNetwork)target;

        if(GUILayout.Button("Create Node"))
        {
            NN.AddNode(0,"bob",false);
        }

        GUILayout.BeginHorizontal();
        Search=EditorGUILayout.IntField("index: ",Search);
        if(GUILayout.Button("Check Node"))
        {
            Debug.Log(NN.CheckValue(NN.Nodes[Search]));
        }
        GUILayout.EndHorizontal();
        foreach (Node item in NN.Nodes)
        {
            
            /*
            for (int i = 0; i < item.Connections.Count; i++)
            {
                item.Connections.Values[i]=EditorGUILayout.FloatField("weight: ",item.Connections.Values[i]);             
            }*/
            //ICollection<float> wei= item.Connections.Values;
            List<float> weights=new List<float>();
            GUILayout.BeginHorizontal();
            int id=0;
            GUILayout.Label(NN.Nodes.IndexOf(item).ToString());
            
            index=EditorGUILayout.IntField("index: ",index);
            if(GUILayout.Button("Create Connection"))
            {
                NN.AddConnection(item,index,1);
            }
            GUILayout.EndHorizontal();
            foreach (Node itm in new List<Node>(item.Connections.Keys))
            {
               item.Connections[itm]=EditorGUILayout.FloatField((NN.Nodes.IndexOf(item)+" to "+NN.Nodes.IndexOf(itm)+" weight: "),item.Connections[itm]);
            }
            /*foreach (float t in wei)
            {
                weights.Add(t);
            }
            for (int i = 0; i < item.Connections.Count; i++)
            {
                weights[i]=EditorGUILayout.FloatField("weight: ",weights[i]);             
            }*/
        }
    }
}
