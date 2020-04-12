using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGetsHit : MonoBehaviour
{
  
    Color defColor;
    float m_Red, m_Blue, m_Green;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
    }
}
