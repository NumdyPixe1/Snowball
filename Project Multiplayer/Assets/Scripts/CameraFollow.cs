
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = 0.15f;
    public Vector3 velocity = Vector3.zero;
    public Transform target;

    Vector3 offer = new Vector3(0f, 0f, -10f);
    float smoothTime = 0.25f;

    void Start()
    {

    }
    void Update()
    {
        // if (target)
        // {
        //     Vector3 point = camera.WorldToViewportPoint(target.position);
        //     Vector3 delta = target.position - camera.WorldToViewportPoint(new Vector3(0.5f, 0.5f, point.z));
        //     Vector3 destination = transform.position + delta;
        //     transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);


        // }
        Vector3 targetPosition = target.position + offer;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);


    }
    private void LateUpdate()
    {

    }
}
