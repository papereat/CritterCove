using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidAI : MonoBehaviour
{
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public Collider2D MouthColider;
    public Stats Sts;

    // Update is called once per frame
    void Start()
    {
    }
    
    void Update()
    {
        var Movemnt=0f;
        var Rotation=0f;
        if(FOV.visiblePlayer.Count==0)
        {
            if(Sts.energy<=1)
            {
                Rotation=.1f;
                Movemnt=.7f;
            }
            else
            {
                Rotation=.3f;
                Movemnt=.5f;
            }
            
        }
        else
        {
            Movemnt=1f;
        }

        transform.Rotate(Vector3.forward * Rotation*Sts.RotationSpeed * Time.deltaTime);
        transform.position += transform.right * Time.deltaTime * Movemnt*Sts.Speed;

        

        if(Sts.energy>=6f)
        {
            Sts.energy-=5;
            Sts.Reproduce();
            
        }
        if(Sts.energy>0)
        {
            
            Sts.energy-=(Movemnt*Sts.Speed+Rotation*Sts.RotationSpeed+(Sts.ViewDistnace/1*(Sts.ViewAngle/90)))/100000;
        }
        else
        {
            Sts.health-=(Movemnt*Sts.Speed+Rotation*Sts.RotationSpeed+(Sts.ViewDistnace/1*(Sts.ViewAngle/90)))/3000;
        }
        if(Sts.health<=0)
        {
            Destroy(this.gameObject);
        }

        

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Sts.energy+=collision.gameObject.GetComponent<Food>().energy;
        Destroy(collision.gameObject);

    }
}
