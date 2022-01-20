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
    public GameObject ExtinctionPannel;

    public bool AutoRestart;

    public int maxFood;
    // Start is called before the first frame update
    void Start()
    {
        StartWorld();
        
    }
    void Update()
    {
        if(CritterCollection.transform.childCount<=0)
        {
            if(AutoRestart)
            {
                RestartWorld();
            }
            else
            {
                ExtinctionPannel.SetActive(true);
            }
            
        }
        else 
        {
            ExtinctionPannel.SetActive(false);
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("test");
            RestartWorld();
        }
        Time.timeScale=TimeSlider.value;
    }
    public void RestartWorld()
    {
        EndWorld();
        StartWorld();
    }
    void EndWorld()
    {
        foreach (Transform child in FoodCollection.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in CritterCollection.transform)
        {
            Destroy(child.gameObject);
        }
        StopAllCoroutines();
    }
    void StartWorld()
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
        a.GetComponent<Stats>().Speed=Random.Range(0.2f,3f);
        a.GetComponent<Stats>().RotationSpeed=Random.Range(45,135);
        a.GetComponent<Stats>().ViewAngle=Random.Range(30,180);
        a.GetComponent<Stats>().ViewDistnace=Random.Range(0.2f,2f);
        a.transform.rotation=new Quaternion(0,0,Random.Range(0f,360f),a.transform.rotation.w);
        a.transform.parent=CritterCollection.transform;
    }
    

    IEnumerator FoodSpawns()
    {
        while(true)
        {
            
            if(FoodCollection.transform.childCount>=maxFood)
            {
                
                yield return new WaitForSeconds(spawnTime);
            }
            else
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
}
