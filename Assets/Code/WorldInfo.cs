using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldInfo : MonoBehaviour
{
    public WorldScript WS;
    public GameObject InfoPannel;
    public float WorldTime;
    int CritterCount;
    int PlantCount;
    public Text textBoxes;
    // Start is called before the first frame update
    void Start()
    {
        StartGather();
    }

    // Update is called once per frame
    void Update()
    {
        if(WS.CritterCollection.transform.childCount==0)
        {
            WorldTime=0f;
        }
    }
    IEnumerator CheckInfo()
    {
        while(true)
        {
            WorldTime+=0.1f;
            CritterCount=WS.CritterCollection.transform.childCount;
            PlantCount=WS.FoodCollection.transform.childCount;
            textBoxes.text="Time: "+WorldTime+"\nCritter Count: "+CritterCount+"\nFood Count: "+PlantCount;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    public void StartGather()
    {
        WorldTime=0f;
        StartCoroutine(CheckInfo());
    }
    public void StopGather()
    {
        StopAllCoroutines();
    }
    public void OnOff()
    {
        if(InfoPannel.activeSelf)
        {
            InfoPannel.SetActive(false);
        }
        else
        {
            InfoPannel.SetActive(true);
        }
    }
}
