using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPratrol : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int direction = 1;

    public bool up = true;

    void Start()
    {
        startingY = transform.position.y;
    }

    void FixedUpdate()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime * direction);

        if (transform.position.y < startingY || transform.position.y > startingY + range)
        {
            direction *= -1;
            Inverti();
        }
       

    }

    void Inverti()
    {
        up = !up;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
