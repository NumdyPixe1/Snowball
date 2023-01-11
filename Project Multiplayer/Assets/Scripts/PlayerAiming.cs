using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerAiming : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject[] point;
    GameObject points;

    Vector2 direction;

    public Transform shotPoint;
    public GameObject dot;
    GameObject[] dots;
    public int numberOfDots;
    public float spaceBetweenDots;
    public GameObject snowBallPrefab;
    public float launchForce;

    void Start()
    {

        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dot, shotPoint.position, Quaternion.identity);
        }
    }


    void Update()
    {
        //Debug.Log(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            audioSource.Play();
        }
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].transform.position = DotPosition(i * spaceBetweenDots);
        }

        Vector2 arrowPos = transform.position;
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousPos - arrowPos;
        transform.right = direction;
    }
    void Shoot()
    {
        GameObject snowBallClone = Instantiate(snowBallPrefab, shotPoint.position, Quaternion.identity);
        snowBallClone.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
    Vector2 DotPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}