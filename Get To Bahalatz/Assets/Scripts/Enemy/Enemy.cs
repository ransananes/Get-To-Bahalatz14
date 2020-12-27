using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator m_Animator;
    PolygonCollider2D pc;


    [Header("Movement Settings")]
    public float Speed = 8.1f;

    [Header("Other Settings")]
    public bool isgrounded;
    private bool dead_anim_is_over = false;


    [Header("Player")]
    public GameObject Player;
    private int health;
    private Player PlayerHealth;

    void Start()
    {
        PlayerHealth = Player.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        pc = GetComponent<PolygonCollider2D>();
        Speed = 0f;
        StartCoroutine(WaitTillAnimationIsOver(3f));

    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerHealth.health; 
        if (health > 0)
        {
            transform.rotation = Quaternion.identity;

            Vector3 Move = new Vector3(1, 0, 0);
            transform.position += Move * Time.deltaTime * Speed;
            transform.position = new Vector3(transform.position.x, 0.704f);
        }
        else if(dead_anim_is_over == false && health == 0)
        {
            transform.position =  new Vector2(Player.transform.position.x-5f,transform.position.y);
            m_Animator.SetBool("IsDead", true);
            dead_anim_is_over = true;

        }
       /* if (Input.touchCount == 2)
            DoubleTap = true;
        if (isgrounded && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || isgrounded && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            {
                if (DoubleTap)
                    // rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Force);
                    DoubleTap = false;
            }
        }
       */
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;

        }


    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;

        }


    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    


    }
    IEnumerator WaitTillAnimationIsOver(float sec)
    {
        yield return new WaitForSeconds(sec);
        Speed = 6.6f;


    }
}
