using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField]
    Vector2 playerVectorMovement;

    [SerializeField]
    Rigidbody2D rigidBodySpaceShip;

    [SerializeField]
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InitPlayerMovements()
    {
    playerVectorMovement.x = Input.GetAxisRaw("Horizontal");
    playerVectorMovement.y = Input.GetAxisRaw("Vertical");

    // Touch input
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0); // Assuming only one touch is relevant for movement

        if (touch.position.x < Screen.width / 2)
        {
            // Left side of the screen for horizontal movement
            if (touch.position.y > Screen.height / 2)
            {
                // Top half of the left side for upward movement
                playerVectorMovement.y = 1f;
            }
            else
            {
                // Bottom half of the left side for downward movement
                playerVectorMovement.y = -1f;
            }
        }
        else
        {
            // Right side of the screen for horizontal movement
            if (touch.position.y > Screen.height / 2)
            {
                // Top half of the right side for upward movement
                playerVectorMovement.y = 1f;
            }
            else
            {
                // Bottom half of the right side for downward movement
                playerVectorMovement.y = -1f;
            }
        }
    }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyLaser")
        {
            gameManager.ShowGameOverScreen();
        }
    }

    
    
}
