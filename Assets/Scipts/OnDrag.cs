using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrag : MonoBehaviour
{
    [SerializeField] GameObject particleVFX;

    private bool _dragging;

    private Vector2 _offset;

    public static bool mouseButtonReleased;

    private float min_X = -5.3f;

    private float max_X = 5.3f;

    private float min_Y = -11.5f;

    private float max_Y = 11.5f;

    int ID;

    private void Start()
    {
        ID = GetInstanceID();
    }

    private void OnMouseDown()
    {
        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;

        GetComponent<Sheep>().canMove = false;
    }

    private void OnMouseDrag()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void Update()
    {
        if (transform.position.x < min_X)
        {
            Vector3 moveDirX = new Vector3(min_X, transform.position.y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X)
        {
            Vector3 moveDirX = new Vector3(max_X, transform.position.y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(transform.position.x, min_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(transform.position.x, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x < min_X && transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(min_X, min_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x < min_X && transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(min_X, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X && transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(max_X, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X && transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(max_X, min_Y, 0f);
            transform.position = moveDirX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {

            if (ID < collision.gameObject.GetComponent<OnDrag>().ID) { return; }

            GameManager.Instance.sheeps.Remove(collision.gameObject);
            GameManager.Instance.sheeps.Remove(gameObject);

            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
            Destroy(explosion, 2f);

            GameObject sheepRespawn = (GameObject)Instantiate(Resources.Load("Sheep"), transform.position, Quaternion.identity);
            sheepRespawn.GetComponent<Sheep>().ChangeColor();
        }
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;

        GetComponent<Sheep>().canMove = true;
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}