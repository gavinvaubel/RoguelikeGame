using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 6;
    public int numHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    void Update()
    {
        if(health > numHearts * 2)
        {
            health = numHearts * 2;
        }
        
        for(int i = 0; i < hearts.Length; i++)
        {

            if(i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if(i * 2 < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else if((i * 2 - health) == 1)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

}
