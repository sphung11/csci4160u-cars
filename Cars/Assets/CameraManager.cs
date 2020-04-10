using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 1.25f;
    public float dampening = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), 
            Time.deltaTime * dampening
        );

        transform.LookAt(focus.transform);
    }
}
