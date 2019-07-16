using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 3.0f;
    public bool vertical;

    public float changeTime = 3.0f;
    float timer;
    int direction = 1; // -1 or 1

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction; // switch direction
            timer = changeTime; // reset timer
        }

        Vector2 position = rigidbody2d.position;

        // y-axis
        if(vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        // x-axis
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2d.MovePosition(position);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();
        if(player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}

