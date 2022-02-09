using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNAI : MonoBehaviour
{
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public Collider2D MouthColider;
    public Stats Sts;
    public ContactFilter2D filter;
    public NueralNetwork NN;
    public int startingHiddenNodes;

    // Start is called before the first frame update
    void Start()
    {
        //Input Nodes
        NN.AddNode(0,"Foods",true);
        NN.AddNode(0,"Energy",true);
        NN.AddNode(0,"Health",true);

        //Output Nodes
        NN.AddNode(0,"Acceleraction",false);
        NN.AddNode(0,"Rotation",false);
        NN.AddNode(0,"give Birth",false);
        NN.AddNode(0,"Sleep",false);

        //Hidden Nodes
        int x =0;
        while (x<startingHiddenNodes)
        {
            int rnd=Random.Range(0,NN.Nodes.Count);
            if(!NN.Nodes[rnd].isInput)
            {
                int rnd2=0;
                while (true)
                {
                    rnd2=Random.Range(0,NN.Nodes.Count);
                    if(rnd!=rnd2)
                    {
                        break;
                    }
                }
                NN.AddConnection(NN.Nodes[rnd],rnd2,Random.Range(-1,1));
                x+=1;
                
            }
            
        }




    }

    // Update is called once per frame
    void Update()
    {
        //AI


    }
}
