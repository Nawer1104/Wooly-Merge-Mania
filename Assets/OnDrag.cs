using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrag : MonoBehaviour
{
    private bool _dragging;

    private Vector2 _offset;

    public static bool mouseButtonReleased;

    public GameObject sheep;

    public GameObject mergeVFX;

    private void OnMouseDown()
    {
        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _dragging = false;
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (mouseButtonReleased && collision.gameObject.tag == "Player" && this.gameObject.tag == "Player")
        {
            Instantiate(sheep, transform.position, Quaternion.identity);
            GameObject explosion = Instantiate(mergeVFX, transform.position, transform.rotation);
            Destroy(explosion, .75f);

            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (mouseButtonReleased && collision.gameObject.tag == "black" && this.gameObject.tag == "black")
        {
            Instantiate(sheep, transform.position, Quaternion.identity);
            GameObject explosion = Instantiate(mergeVFX, transform.position, transform.rotation);
            Destroy(explosion, .75f);

            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}