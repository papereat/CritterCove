using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidAI : MonoBehaviour
{
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public Collider2D MouthColider;
    public Stats Sts;
    public ContactFilter2D filter;

    // Update is called once per frame
    void Start()
    {
        
    }
    
    void FixedUpdate()
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
            Sts.energy-=(Mathf.Abs(Movemnt*Sts.Speed/5)+Mathf.Abs(Rotation*Sts.RotationSpeed/90)+Mathf.Abs(Sts.ViewAngle/360*Sts.ViewDistnace))*Time.deltaTime;
        }
        else
        {
            Sts.health-=(Mathf.Abs(Movemnt*Sts.Speed/5)+Mathf.Abs(Rotation*Sts.RotationSpeed/90)+Mathf.Abs(Sts.ViewAngle/360*Sts.ViewDistnace))*Time.deltaTime;
        }
        if(Sts.health<=0)
        {
            Sts.Death();
        }
        List<Collider2D> Collisions=new List<Collider2D>();
        MouthColider.OverlapCollider(filter,Collisions);
        foreach (Collider2D item in Collisions)
        {
            Sts.energy+=item.transform.gameObject.GetComponent<Food>().energy;
            Destroy(item.gameObject);
        }

        

    }
}
