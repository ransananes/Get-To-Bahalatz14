using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Texts : MonoBehaviour
{
    public Text Score;
    public GameObject Player;

    private float score = 1;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        score = Player.transform.position.x / 10;
        Score.text = "מ''ק " + (int)(score);

    }
}
