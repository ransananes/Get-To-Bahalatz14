using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rb;
    public float randomA;
    public float randomB;

    public GameObject effect;

    private bool rotating = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(randomA, randomB);

    }
     void Update()
    {
        if (rotating)
        {
            Vector3 to = new Vector3(0, 0, 140f);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * 0.5f);
            }
            else
            {
                transform.eulerAngles = to;
                rotating = false;
            }
        }

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            
            rb.bodyType = RigidbodyType2D.Static;

         
        }
        if(col.gameObject.CompareTag("Player"))
            effect.SetActive(false);

    }
}
