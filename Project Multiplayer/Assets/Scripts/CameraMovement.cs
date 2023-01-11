using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //edge scrolling
    Camera cam;
    float camSpeed = 20;
    int BorderSize = 100;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        EdgeScroll();
    }
    void EdgeScroll()
    {
        int distanceToTop = cam.pixelHeight - (int)Input.mousePosition.y;
        int distanceToBotton = (int)Input.mousePosition.y;
        int distanceToRight = cam.pixelWidth - (int)Input.mousePosition.x;
        int distanceToLeft = (int)Input.mousePosition.x;
        if (distanceToTop < BorderSize && distanceToTop > 0)
        {
            cam.transform.position += Vector3.up * Time.deltaTime * camSpeed;
        }
        else if (distanceToBotton < BorderSize && distanceToBotton > 0)
        {
            cam.transform.position += Vector3.down * Time.deltaTime * camSpeed;
        }
        if (distanceToLeft < BorderSize && distanceToLeft > 0)
        {
            cam.transform.position += Vector3.left * Time.deltaTime * camSpeed;

        }
        else if (distanceToRight < BorderSize && distanceToRight > 0)
        {
            cam.transform.position += Vector3.right * Time.deltaTime * camSpeed;
        }
    }
}
