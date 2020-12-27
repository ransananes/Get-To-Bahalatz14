using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles_Spawner : MonoBehaviour
{
    public GameObject[] Tiles;
    public Transform player;
    public float distancebetween;
    private float platformwidth;
    private Player PlayerHealth;
    int playerhealth;
    int random;
    private bool HasTileSpawned = false;

    void Start()
    {
        PlayerHealth = player.GetComponent<Player>();
        platformwidth = Tiles[0].GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        playerhealth = PlayerHealth.health;
        if (playerhealth > 0)
        {
            if (transform.position.x < player.position.x)
            {
                 random = Random.Range(0, 3);
                transform.position = new Vector3(distancebetween + platformwidth + transform.position.x, transform.position.y, 0);
                Destroy(Instantiate(Tiles[random], transform.position, Quaternion.identity), 15f);
            }

        }
        else if(!HasTileSpawned)
        {
            Instantiate(Tiles[random], new Vector2(player.position.x, 0.2603498f), Quaternion.identity);
            HasTileSpawned = true;
        }
    }
    }
