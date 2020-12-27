using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_BodyChanger : MonoBehaviour
{
    [Header("Body Settings")]
    public GameObject[] Body;
    [Header("Alien_Orange")]
    public Sprite[] OrangeBodyParts;
    [Header("Alien_Green")]
    public Sprite[] GreenBodyParts;
    void Start()
    {
        int Switch_Character = Random.Range(0, 3);
     
        switch(Switch_Character)
        {
            case 0:
                Alien_Orange();
                break;
            case 1:
                Alien_Green();
                break;
            default:
                break;
        }
    }

    void Alien_Orange()
    {
        for(int i =0; i<16;i++)
        Body[i].GetComponent<SpriteRenderer>().sprite = OrangeBodyParts[i];
    }
    void Alien_Green()
    {
        for (int i = 0; i < 16; i++)
            Body[i].GetComponent<SpriteRenderer>().sprite = GreenBodyParts[i];
    }
}
