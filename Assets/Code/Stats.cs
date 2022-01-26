using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public FieldOfView FOV;
    public WorldScript WS;
    public SpriteRenderer SR;
    public float Speed;
    public float RotationSpeed;
    public float ViewDistnace;
    public float ViewAngle;
    public float energy;
    public float health;
    public float size;
    public int generation;
    public GameObject CritterCollection;
    public GameObject FoodCollection;
    public bool IsEgg;
    public float IncubationTime;
    public Sprite EggSprite;
    public Sprite CritterSprite;
    public Vector3 color;
    public float MaxHealth;
    public float SleepEfectivity;
    public bool isSleep;
    
    void Awake()
    {
        FOV.viewRad=ViewDistnace;
        FOV.viewAngle=ViewAngle;
        transform.localScale=new Vector3(size,size,0);
        SR.color= new Color(color.x,color.y,color.z,1);
        MaxHealth=50*size+50;
        health=IncubationTime/5*MaxHealth;
        StartCoroutine(Egg());
    }
    public IEnumerator Egg()
    {
        while(true)
        {
            if(IsEgg==false)
            {
                IsEgg=true;
                SR.sprite=EggSprite;
                
                
                yield return new WaitForSeconds(IncubationTime);
            }
            else
            {
                IsEgg=false;
                SR.sprite=CritterSprite;
                yield break;
            }
        }
        
    }
    void FixedUpdate()
    {
        if(isSleep)
        {
            if(energy>0)
            {
                energy-=(Mathf.Abs(ViewAngle/360*ViewDistnace))*Time.deltaTime;
                health+=2*SleepEfectivity*Time.deltaTime;

            }
            else
            {
                isSleep=false;
            }
            
        }
        
    }
    public void Reproduce()
    {
        GameObject a =Instantiate(gameObject) as GameObject;
        a.transform.position=transform.position;
        a.name="Critter";
        a.GetComponent<Stats>().energy=5;
        a.GetComponent<Stats>().WS=WS;
        a.GetComponent<Stats>().generation=generation+1;
        a.transform.parent=CritterCollection.transform;

        int y=Random.Range(1,WS.MaxChanges+1);
        int x=0;
        
        while (x<y)
        {
            x+=1;
            int z=Random.Range(1,10);
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
                case 7:
                    a.GetComponent<Stats>().IncubationTime+=k*2;
                    break;
                case 8:
                    a.GetComponent<Stats>().color.x+=k;
                    if(a.GetComponent<Stats>().color.x>1)
                    {
                        a.GetComponent<Stats>().color.x=1;
                    }
                    else if(a.GetComponent<Stats>().color.x<0)
                    {
                        a.GetComponent<Stats>().color.x=0;
                    }
                    break;
                case 9:
                    a.GetComponent<Stats>().color.y+=k;
                    if(a.GetComponent<Stats>().color.y>1)
                    {
                        a.GetComponent<Stats>().color.y=1;
                    }
                    else if(a.GetComponent<Stats>().color.y<0)
                    {
                        a.GetComponent<Stats>().color.y=0;
                    }
                    break;
                case 10:
                    a.GetComponent<Stats>().color.z+=k;
                    if(a.GetComponent<Stats>().color.z>1)
                    {
                        a.GetComponent<Stats>().color.z=1;
                    }
                    else if(a.GetComponent<Stats>().color.z<0)
                    {
                        a.GetComponent<Stats>().color.z=0;
                    }
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
        a.transform.parent=FoodCollection.transform;
        Destroy(this.gameObject);
    }
    public void Damage(GameObject Attacker)
    {
        if(Attacker.GetComponent<Stats>().health!=health)
        {
            if(IsEgg)
            {
                health-=-0.4f;
            }
            else
            {
                health-=1;
            }
            
        }
        
    }

}
