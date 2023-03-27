using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed = 8f;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    public Pistol pistol;
    public float health = 6f;
    public int weaponType = 1;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Processing Inputs
        HandleMovement();
        UseWeapon();
    }

    void FixedUpdate()
    {
        // Physics calculations
        Aim();
        Move();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void UseWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(weaponType == 1)
            {
                pistol.Fire();
            }
            else if(weaponType == 2)
            {
                
            }
            else if(weaponType == 3)
            {

            }
            else if(weaponType == 4)
            {

            }
            else if(weaponType == 5)
            {

            }
            else if(weaponType == 6)
            {

            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            pistol.Reload();
        }
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Aim()
    {
        Vector2 aimDirection = mousePosition - body.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        body.rotation = aimAngle;
    }

}
