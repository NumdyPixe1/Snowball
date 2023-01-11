using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        float angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
