using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;

    [SerializeField] private Animator _animator;

    private int coinCounter = 0;
    public TMP_Text coinText;

    private bool FirstGearPick = false;
    private bool SecondGearPick = false;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((FirstGearPick || SecondGearPick) && Keyboard.current.eKey.isPressed)
        {
            minigame();
        }
        Movement();
    }

    private void minigame()
    {
        coinCounter++;
        coinText.text = "Coins: " + coinCounter;
        FirstGearPick = false;
        SecondGearPick = false;
    }

    private void Movement()
    {
        if (Keyboard.current.dKey.isPressed && Keyboard.current.eKey.wasPressedThisFrame)
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

        rb.linearVelocity = new Vector2(speedX, speedY);
        if (speedX == 0 && speedY == 0)
        {
            _animator.SetBool("IsRunning", false);
        }
        else
        {
            _animator.SetBool("IsRunning", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 1;
            coinText.text = "Coins: " + coinCounter;
        }
        else if (collision.CompareTag("SilverCoin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 3;
            coinText.text = "Coins: " + coinCounter;
        }
        else if (collision.CompareTag("GoldCoin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 20;
            coinText.text = "Coins: " + coinCounter;
        }
        
        
        if (collision.CompareTag("Gear1"))
        {
            FirstGearPick = true;
        }

        if (collision.CompareTag("Gear2"))
        {
            SecondGearPick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gear1"))
        {
            FirstGearPick = false;
        }
        if (collision.CompareTag("Gear2"))
        {
            SecondGearPick = false;
        }
    }
}
