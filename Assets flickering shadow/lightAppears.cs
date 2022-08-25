using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; 


public class lightAppears : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Light2D shadowAround;
    public float time;

    void Start()
    {
        time = 0;
        shadowAround.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 10) 
        {
            shadowAround.enabled = true;
            shadowAround.intensity = Mathf.Lerp(1.8f, 3, Mathf.PingPong(Time.time, 1));
        }
        //else shadowAround.enabled = false;
    }
}
