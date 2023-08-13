using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private SpriteRenderer sprite;

    private float min_X = -5.3f;

    private float max_X = 5.3f;

    private float min_Y = -11.5f;

    private float max_Y = 11.5f;

    public float speed = 5;

    private Vector3 destination;

    public bool canMove = true;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        if (sprite != null)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);

            sprite.color = newColor;
        }
    }

    private void Start()
    {
        destination = GetNewDestination();
    }

    private void Update()
    {
        if (canMove)
        {
            Vector3 newPos = GetNewPos(destination);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05f)
            {
                destination = GetNewDestination();
                Vector3 new_Pos = GetNewPos(destination);
                transform.position = new_Pos;
            }
        }
    }

    private Vector3 GetNewDestination()
    {
        Vector3 destination = new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), 0f);
        return destination;
    }

    private Vector3 GetNewPos(Vector3 destination)
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        return newPos;
    }
}
