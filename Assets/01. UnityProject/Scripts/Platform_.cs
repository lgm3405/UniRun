using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_ : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] Circle;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }

        for (int i = 0; i < Circle.Length; i++)
        {
            if (Random.Range(0, 10) == 0)
            {
                Circle[i].SetActive(true);
            }
            else
            {
                Circle[i].SetActive(false);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player") && stepped == false)
        {
            stepped = true;
            GameManager_.instance.AddScore(1);
        }
    }
}
