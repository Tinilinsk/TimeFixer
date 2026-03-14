using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerController : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;
    public Canvas Canvas;

    private float direction = 1f;
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private int level = 1;

    private void Start()
    {
    }

    private void Update()
    {
        Game();
    }

    private void OnEnable()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = PointB.position;
        level = 1;
        moveSpeed = 20f;
    }

    private void Game()
    {
        

        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, PointA.position) < 0.1f)
        {
            targetPosition = PointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, PointB.position) < 0.1f)
        {
            targetPosition = PointA.position;
            direction = -1f;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CheckSuccess();
        }
    }

    private void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            if (level == 1)
            {
                moveSpeed += 10;
                level++;
            }
            else if (level == 2)
            {
                moveSpeed += 15;
                level++;
            }
            else if (level == 3)
            {
                Canvas.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Fail!");
        }
    }
}
