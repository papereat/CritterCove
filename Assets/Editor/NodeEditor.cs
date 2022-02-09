using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //Node node=(Node)target;

        //node.Name=EditorGUILayout.TextField("index: ",node.Name);
    }
}
