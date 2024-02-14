using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalPatrol : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingX;
    int direction = 1;

    public bool right = true;

    void Start()
    {
        startingX = transform.position.x;

        if (!right)
        {
            direction = -1;
        }

    }

    void FixedUpdate()
    {

        /*if (right)
        {
            CamminaDestra();
        }
        else
        {
            CamminaSinistra();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        if (right && (transform.position.x < startingX || transform.position.x > startingX + range))
        {
            direction *= -1;
            Inverti();
        }
        else if(!right && (transform.position.x > startingX || transform.position.x < startingX - range))
        {
            direction *= -1;
            Inverti();
        }*/

        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        if (transform.position.x > startingX + range || transform.position.x < startingX - range)
        {
            direction *= -1;
            Inverti();
        }

    }

    void CamminaDestra()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        if (transform.position.x > startingX + range)
        {
            direction *= -1;
            Inverti();
        }

    }

    void CamminaSinistra()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        if (transform.position.x < startingX - range)
        {
            direction *= -1;
            Inverti();
        }

    }

    void Inverti()
    {
        right = !right;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
