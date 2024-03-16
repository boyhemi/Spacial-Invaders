using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject playerLaserProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Return))
        {
            Attack();
        }
    }


    public void Attack()
    {
        Instantiate(playerLaserProjectile, attackPoint.position, attackPoint.rotation);

    }


}
