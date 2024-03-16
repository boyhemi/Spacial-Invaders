using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    // Start is called before the first frame update
public float speed = 5f;
public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D (Collider2D attack)
    {
         if(attack.CompareTag("Enemy"))
        {
            attack.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        

    }

}
