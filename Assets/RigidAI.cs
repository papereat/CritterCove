using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidAI : MonoBehaviour
{
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public Collider2D MouthColider;
    public GameObject CreaturePrefab;
    public float Speed;
    public float RotationSpeed;
    public float ViewDistnace;
    public float ViewAngle;
    public float energy;
    public float health;

    // Update is called once per frame
    void Start()
    {
        CreaturePrefab = Resources.Load("Creature") as GameObject;
    }
    void Awake()
    {
        FOV.viewRad=ViewDistnace;
        FOV.viewAngle=ViewAngle;
    }
    void Update()
    {
        var Movemnt=0f;
        var Rotation=0f;
        if(FOV.visiblePlayer.Count==0)
        {
            Rotation=.3f;
            Movemnt=.5f;
        }
        else
        {
            Movemnt=1f;
        }

        transform.Rotate(Vector3.forward * Rotation*RotationSpeed * Time.deltaTime);
        transform.position += transform.right * Time.deltaTime * Movemnt*Speed;

        

        if(energy>=6f)
        {
            energy-=5;
            Reproduce();
            
        }
        if(energy>0)
        {
            
            energy-=(Movemnt*Speed+Rotation*RotationSpeed+(ViewDistnace/1*(ViewAngle/90)))/100000;
        }
        else
        {
            health-=(Movemnt*Speed+Rotation*RotationSpeed+(ViewDistnace/1*(ViewAngle/90)))/3000;
        }
        if(health<=0)
        {
            Destroy(this.gameObject);
        }

        

    }
    void Reproduce()
    {
        GameObject a =Instantiate(CreaturePrefab) as GameObject;
        a.transform.position=transform.position;
        a.name="sdl";
        a.GetComponent<RigidAI>().CreaturePrefab=CreaturePrefab;
        a.GetComponent<RigidAI>().energy=2;
        a.GetComponent<RigidAI>().health=100;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        energy+=collision.gameObject.GetComponent<Food>().energy;
        Destroy(collision.gameObject);

    }
}
