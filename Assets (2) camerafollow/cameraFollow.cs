using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float offset;
    public float smoothTime = 0.5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 vectCamera = transform.position;
        vectCamera.x = target.position.x;
        vectCamera.y = target.position.y;

        vectCamera.x += offset;
        vectCamera.y += offset;

        Vector3 smoothedCamera = Vector3.Lerp(transform.position, vectCamera, smoothTime);
        transform.position = smoothedCamera;
    }
}