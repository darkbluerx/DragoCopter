using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HelicopterController : MonoBehaviour
{
    Animator animator;
    bool IsDead;

    public GameManager gameManager;
    Rigidbody2D rb;

    [SerializeField] float velocity = 10f;

    public UnityEvent OnStopScore;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        IsDead = false;
    }

    void Update()
    {
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
       IsDead = true;
       OnStopScore?.Invoke();

       StartCoroutine(GameOverTimer());
    }

    IEnumerator GameOverTimer()
    {
        if (IsDead)
        {
            animator.SetBool("Dead",true);
        }

        yield return new WaitForSeconds(1.5f);

        gameManager.GameOver();
        yield return null;
    }
}
