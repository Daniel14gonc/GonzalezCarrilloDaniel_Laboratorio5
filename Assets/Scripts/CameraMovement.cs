using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camTarget;
    public Transform lookTarget;
    public float smoothSpeed = 10.0f;
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = new Vector3(0, 20, -3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (camTarget && lookTarget)
        {
            Vector3 dPos = camTarget.position + distance;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, smoothSpeed * Time.deltaTime);
            transform.position = sPos;
            transform.LookAt(lookTarget.position);
        }
            
    }

}
