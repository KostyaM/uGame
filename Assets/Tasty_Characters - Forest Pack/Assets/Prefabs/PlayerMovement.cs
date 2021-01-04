using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, CollisionListener
{
    public float movementSpeed = 2f;
    public float jumpForce = 4f;
    public bool isJumping = false;


    private bool isFacingLeft = true;

    

    // Update is called once per frame
    void Update()
    {

        var movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        if (movement.x > 0 && isFacingLeft)
        {
            isFacingLeft = !isFacingLeft;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else if (movement.x < 0 && !isFacingLeft) 
        {
            isFacingLeft = !isFacingLeft;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

       transform.Translate(movement * Time.deltaTime * movementSpeed * (isFacingLeft ? 1 : -1));

        if (Input.GetButtonDown("Jump") && !isJumping) {
            Jump();
        }
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public void onCollide()
    {
        isJumping = false;
    }

    public void onExitCollide()
    {
        isJumping = true;
    }
}
