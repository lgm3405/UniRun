using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoops : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    //   �� ���͸� ���Ѵ�.
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        //transform.position = (Vector2)transform.position + offset;
        transform.position = transform.position.AddVector(offset);
    }
}