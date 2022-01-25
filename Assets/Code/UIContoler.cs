using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContoler : MonoBehaviour
{
    public GameObject StatsPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(StatsPannel.activeSelf==true)
            {
                StatsPannel.SetActive(false);
            }
            else
            {
                StatsPannel.SetActive(true);
            }
        }
    }
}
