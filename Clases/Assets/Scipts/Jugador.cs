using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;


public class Jugador : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winText.text = "";
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void FixedUpdate()
    {
        // Vector3 (representa el vector 3D)
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("TriggerMeta"))
        {
            winText.text = "Game Over";

            other.gameObject.SetActive(false);
        }
    }
}
