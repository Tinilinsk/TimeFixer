using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.dKey.isPressed && Keyboard.current.aKey.isPressed)
        {
            speedX = 0;
        }
        else
        {
            if (Keyboard.current.dKey.isPressed)
            {
                speedX = movSpeed;
            }
            else if (Keyboard.current.aKey.isPressed)
            {
                speedX = -movSpeed;
            }
            else
            {
                speedX = 0;
            }
        }

        if (Keyboard.current.wKey.isPressed && Keyboard.current.sKey.isPressed)
        {
            speedY = 0;
        }
        else
        {
            if (Keyboard.current.wKey.isPressed)
            {
                speedY = movSpeed;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                speedY = -movSpeed;
            }
            else
            {
                speedY = 0;
            }
        }

        rb.linearVelocity = new Vector2 (speedX, speedY);
    }
}
