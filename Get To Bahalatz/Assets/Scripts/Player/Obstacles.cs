using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
   private SpriteRenderer sprender;
    public GameObject Explosion;
    public GameObject Main_Obstacle;
    public GameObject OnTouchHead;
    private PolygonCollider2D pc2d;
    private PolygonCollider2D othpc2d;

    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        Explosion.SetActive(false);
        pc2d = gameObject.GetComponent<PolygonCollider2D>();
        othpc2d = OnTouchHead.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Ground"))
        {
            sprender.enabled = false;
            pc2d.enabled = false;
            othpc2d.enabled = false;
            Explosion.SetActive(true);
            StartCoroutine(Destroy_Explosion(1f));



        }


    }
    IEnumerator Destroy_Explosion(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(Main_Obstacle);
    }
  
}
