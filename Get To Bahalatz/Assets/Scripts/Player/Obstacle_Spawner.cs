using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [Header("Spawn - Parameters")]
    public Transform player;
    public float distancebetween;

    [Header("Obstacles List")]
    public GameObject[] Obstacles;

     void Start()
    {

    }
    void Update()
    {
        if (transform.position.x -17f < player.position.x)
        {
            int random = Random.Range(0, 7);
            transform.position = new Vector3(distancebetween + transform.position.x, transform.position.y, 0);
            Destroy(Instantiate(Obstacles[random], transform.position, Quaternion.identity), 15f);
        }

    }
   
    /*  void OnCollisionEnter2D(Collision2D coll)
      {
          if (coll.gameObject.CompareTag("Player"))
          {
              coll.gameObject.GetComponent<Player>().health -= damage;
              gameObject.GetComponent<PolygonCollider2D>().enabled = false;
              StartCoroutine(EnableCollider(1.25f));

          }
      }


      IEnumerator EnableCollider(float sec)
      {
              yield return new WaitForSeconds(sec);
              gameObject.GetComponent<PolygonCollider2D>().enabled = true;

      }
    */
}



