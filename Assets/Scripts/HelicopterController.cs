using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody2D rb;

    [SerializeField] float velocity = 10f;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if(Input.GetMouseButtonDown(0)) 
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                rb.velocity = Vector2.up * velocity;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
