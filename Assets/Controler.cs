using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        Vector2 Movemnt=new Vector2(0,0);
        if(Input.GetKey(KeyCode.W))
        {
            Movemnt.y+=speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            Movemnt.y-=speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            Movemnt.x+=speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            Movemnt.x-=speed;
        }
        rb.velocity=Movemnt;
    }
}
