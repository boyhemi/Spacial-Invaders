using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerLaser"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "EnemyLaser")
        {
            other.gameObject.SetActive(false);
        }
    }
    

    





}
