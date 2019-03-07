using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public void MoveUp()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    public void MoveDown()
    {
        transform.Translate(Vector2.up * Time.deltaTime * -speed);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.left * Time.deltaTime * -speed);
    }


}
