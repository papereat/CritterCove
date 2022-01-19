using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldScript : MonoBehaviour
{
    public GameObject foodPrefab;
    public float spawnTime;
    public Vector2 screenSize;
    public Vector2 foodEnergy;
    public float foodDensity;
    public int FoodCreatedPerWave;
    public float MeatSize;
    public GameObject FoodCollection;

    public GameObject CritterPrefab;
    public GameObject CritterCollection;
    public int StartingCritters;

    public int MaxChanges;
    public float ChangeDistance;
    float foodScale;

    public Slider TimeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(FoodSpawns());
        var x=0;
        while (x<StartingCritters)
        {
            spawnCritter();
            x+=1;
        }
    }

    void spawnFood()
    {
        foodScale=Random.Range(foodEnergy.x,foodEnergy.y)*foodDensity;
        GameObject a =Instantiate(foodPrefab) as GameObject;
        a.transform.position=new Vector2(Random.Range(0,screenSize.x),Random.Range(0,screenSize.y));
        a.transform.localScale= new Vector3(foodScale,foodScale,0);
        a.GetComponent<Food>().energy=foodScale/foodDensity;
        a.transform.parent=FoodCollection.transform;
    }
    void spawnCritter()
    {
         GameObject a =Instantiate(CritterPrefab) as GameObject;
        a.transform.position=new Vector3(Random.Range(0,screenSize.x),Random.Range(0,screenSize.y));
        a.name="Critter";
        a.GetComponent<Stats>().energy=5;
        a.GetComponent<Stats>().health=100;
        a.GetComponent<Stats>().WS=this;
        a.GetComponent<Stats>().generation=0;
        a.GetComponent<Stats>().CritterCollection= CritterCollection;
        a.transform.parent=CritterCollection.transform;
    }
    void FixedUpdate()
    {
        Time.timeScale=TimeSlider.value;
    }

    IEnumerator FoodSpawns()
    {
        while(true)
        {
            var x=0;
            while(x<FoodCreatedPerWave)
            {
                spawnFood();
                x+=1;
            }
            yield return new WaitForSeconds(spawnTime);

        }
    }
}
