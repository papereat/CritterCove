using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    public GameObject foodPrefab;
    public float spawnTime;
    public Vector2 screenSize;
    public Vector2 foodEnergy;
    public float foodDensity;
    public int FoodCreatedPerWave;
    float foodScale;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(FoodSpawns());
    }

    void spawnFood()
    {
        foodScale=Random.Range(foodEnergy.x,foodEnergy.y)*foodDensity;
        GameObject a =Instantiate(foodPrefab) as GameObject;
        a.transform.position=new Vector2(Random.Range(0,screenSize.x),Random.Range(0,screenSize.y));
        a.transform.localScale= new Vector3(foodScale,foodScale,0);
        a.GetComponent<Food>().energy=foodScale/foodDensity;
        Debug.Log("Food Spawned");
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
