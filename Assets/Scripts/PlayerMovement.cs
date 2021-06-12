using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0f;
    Rigidbody rb;

    public Vector2 _mousePos;


    public float isPressed = 0f;
    public float timer=0f,interval=1f;
    public float speedInc = 0f;
    public void OnMousePosition(InputValue value)
    {
        _mousePos = value.Get<Vector2>();
    }
    public void OnMouseClick(InputValue value)
    {
        isPressed = value.Get<float>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer >= interval)
        {
            speed += speedInc;
            timer = 0;
        }
        timer += Time.deltaTime;
        if (isPressed > 0.5f)
        {
            if (_mousePos.x < Screen.width / 2 && transform.position.x > -1.5)
                transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            else if (_mousePos.x > Screen.width / 2 && transform.position.x < 1.5)
                transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

            isPressed = 0;
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Final"))
        {
            GameManager.Instance.NextLevel();
        }
    }
}
