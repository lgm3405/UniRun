using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObj : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager_.instance.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
