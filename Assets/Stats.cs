using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public FieldOfView FOV;
    public WorldScript WS;
    public float Speed;
    public float RotationSpeed;
    public float ViewDistnace;
    public float ViewAngle;
    public float energy;
    public float health;
    public float size;
    public int generation;
    public GameObject CritterCollection;

    void Awake()
    {
        FOV.viewRad=ViewDistnace;
        FOV.viewAngle=ViewAngle;
        transform.localScale=new Vector3(size,size,0);
    }
    public void Reproduce()
    {
        GameObject a =Instantiate(gameObject) as GameObject;
        a.transform.position=transform.position;
        a.name="Critter";
        a.GetComponent<Stats>().energy=5;
        a.GetComponent<Stats>().health=100;
        a.GetComponent<Stats>().WS=WS;
        a.GetComponent<Stats>().generation=generation+1;
        a.transform.parent=CritterCollection.transform;

        int y=Random.Range(1,WS.MaxChanges+1);
        int x=0;
        while (x<y)
        {
            x+=1;
            int z=Random.Range(1,6);
            var k=Random.Range(-WS.ChangeDistance,WS.ChangeDistance);
            switch (z)
            {
                case 1:
                    a.GetComponent<Stats>().Speed+=k*2;
                    break;
                case 2:
                    a.GetComponent<Stats>().RotationSpeed+=k*3;
                    break;
                case 3:
                    a.GetComponent<Stats>().ViewDistnace+=k*2;
                    break;
                case 4:
                    a.GetComponent<Stats>().ViewAngle+=k*3;
                    break;
                case 5:
                    a.GetComponent<Stats>().size+=k;
                    break;
            }

        }
    }
    public void Death()
    {
        GameObject a=Instantiate(Resources.Load("food") as GameObject);
        a.transform.position=transform.position;
        a.GetComponent<Food>().energy=3;
        a.transform.localScale=new Vector3(WS.MeatSize,WS.MeatSize,0);
        a.GetComponent<SpriteRenderer>().color=Color.red;
        Destroy(this.gameObject);
    }
    public void Damage(GameObject Attacker)
    {
        if(Attacker.GetComponent<Stats>().health!=health)
        {
            health-=1;
        }
        
    }

}
