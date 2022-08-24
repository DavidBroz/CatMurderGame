using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomin : MonoBehaviour
{
    public float transitionSpeed = 0.3f;
    public int zoom = 120;
    public int normal = 60;
    public float timer;
    public float timeZoom =5;
    // Start is called before the first frame update
    // public GameObject obj;

    void Start()
    {
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeZoom)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * transitionSpeed);
        } 
    }
   

}






