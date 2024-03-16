using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField]
    Vector2 playerVectorMovement;

    [SerializeField]
    Rigidbody2D rigidBodySpaceShip;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InitPlayerMovements()
    {
        playerVectorMovement.x = Input.GetAxisRaw("Horizontal");
        playerVectorMovement.y = Input.GetAxisRaw("Vertical");

    }

    void InitMovements()
    {
        rigidBodySpaceShip.MovePosition(rigidBodySpaceShip.position +  playerVectorMovement * playerSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        InitPlayerMovements();
        
    }

    void FixedUpdate()
    {
        InitMovements();
    }
    
}
