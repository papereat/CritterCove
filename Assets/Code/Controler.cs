using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Camera C;
    public float CameraSize;



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
        rb.velocity=Movemnt/Time.timeScale*CameraSize;

        CameraSize+=Input.mouseScrollDelta.y*3;

        if(CameraSize<3)
        {
            CameraSize=3;
        }
        C.orthographicSize=CameraSize;
    }
}
