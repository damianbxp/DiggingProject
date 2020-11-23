using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        move *= speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + move);
    }
}
