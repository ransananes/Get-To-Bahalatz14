using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{


    private Rigidbody2D rb;
    Animator m_Animator;
    PolygonCollider2D pc;

    [Header("Movement Settings")]
    public float Speed = 7f;
    public float JumpForce = 17f;


    [Header("Health Settings")]
    public int health = 3;
    public int damage = 1;


    [Header("Other Settings")]
    public bool isgrounded;
    public bool DoubleTap = false;
    public GameObject[] hearts;
    public int numberoftaps = 0;
    public GameObject PausePanel;

    private float speedonhit = 3;
    private float normalspeed = 7;
    private float normaljumpforce = 12f;
    private int level = 0;
    private int highscore = 0;
    private float fallMultiplierFloat = 2.5f;
    private float lowJumpMultiplierFloat = 2f;

    [Header("Sound Settings")]
    public AudioSource jump_sound;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        pc = GetComponent<PolygonCollider2D>();
        Speed = 3f;
        StartCoroutine(WaitTillAnimationIsOver(1f));
        highscore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        if (health > 0)
        {
          
            if (transform.position.x / 10 > 100 && level == 2)
        {

            normalspeed = 9.0f;
            speedonhit = 4.2f;
             normaljumpforce = 11.7f;
                Speed = normalspeed;
            JumpForce = normaljumpforce;
            
        }
       else if (transform.position.x / 10 > 50 && level == 1)
        {

            normalspeed = 8.4f;
            speedonhit = 4f;
            normaljumpforce = 11.5f;
                level++;
                Speed = normalspeed;
                JumpForce = normaljumpforce;
            }

        else if (transform.position.x / 10 > 30 && level == 0)
        {
            normalspeed = 7.7f;
            speedonhit = 3.5f;
            normaljumpforce = 11f;
                level++;
                Speed = normalspeed;
                JumpForce = normaljumpforce;

            }
            transform.rotation = Quaternion.identity;

            Vector3 Move = new Vector3(1, 0, 0);
            transform.position += Move * Time.deltaTime * Speed;


           
                foreach (Touch touch in Input.touches)
                {
                    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        EnablePausePanel();
                        return;
                    }
                if (numberoftaps < 2)
                {
                    jump_sound.Play();
                    if (numberoftaps == 1)
                        JumpForce = 8.6f;
                    rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    numberoftaps++;
                }
                if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
                }
                if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
                }


            }
            /* if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && numberoftaps < 2 || isgrounded && Input.GetMouseButtonDown(0))
             {
                 jump_sound.Play();
                 if (numberoftaps == 1)
                     JumpForce = 8.6f;
                 rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                 numberoftaps++;        
             }*/

        }
        
    }

    private void EnablePausePanel()
    {

        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
            numberoftaps = 0;
            JumpForce = normaljumpforce;

        }
        if (col.gameObject.CompareTag("Obstacle"))
        {
            health--;
            if (health == 0)
            {
                if (highscore < (int)(transform.position.x / 10))
                {
                    PlayerPrefs.SetInt("highscore", (int)transform.position.x / 10);
                    PlayerPrefs.Save();
                    PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_kilometers, (int)transform.position.x / 10);
                 
                }
                m_Animator.SetBool("IsDead", true);
                Speed = 0;
                return;
            }
            m_Animator.SetBool("OnHit", true);
            
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
        if (col.gameObject.CompareTag("Obstacle"))
        {      
            hearts[health - 1].SetActive(false);
            Speed = speedonhit;
            StartCoroutine(Disable_OnHit(1.5f));
        }


    }
    IEnumerator Disable_OnHit(float sec)
    {
       yield return new WaitForSeconds(sec);
        m_Animator.SetBool("OnHit", false);
        Speed = normalspeed;


    }
    IEnumerator WaitTillAnimationIsOver(float sec)
    {
        yield return new WaitForSeconds(sec);
        Speed = normalspeed;


    }
    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
}
