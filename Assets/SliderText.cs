using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderText : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public string BeggingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text=BeggingText+slider.value.ToString();
    }
}
