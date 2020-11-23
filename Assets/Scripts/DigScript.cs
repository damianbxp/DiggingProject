using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour
{
    float squareSize;
    float width, height;
    public MapManager mapManager;
    Vector3 digRayDirection;

    private void Start() {
        squareSize = mapManager.squareSize;
        width = mapManager.width;
        height = mapManager.height;
    }

    private void Update() {
        float horizontal = 0;
        float vertical = 0;

        if(Input.GetKey(KeyCode.Keypad4)) horizontal--;
        if(Input.GetKey(KeyCode.Keypad6)) horizontal++;

        if(Input.GetKey(KeyCode.Keypad1)) {
            horizontal-=0.5f;
            vertical -= 0.5f;
        }

        if(Input.GetKey(KeyCode.Keypad3)) {
            horizontal += 0.5f;
            vertical -= 0.5f;
        }

        if(Input.GetKey(KeyCode.Keypad2)) vertical--;
        if(Input.GetKey(KeyCode.Keypad8)) vertical++;

        digRayDirection = new Vector3(horizontal, vertical).normalized;

        Debug.DrawLine(transform.position, transform.position + digRayDirection * 3, Color.red);
        
        if(Input.GetKeyDown(KeyCode.Q)) {
            Dig();
        }
    }

    void Dig() {
        
        if(Physics.Raycast(transform.position, digRayDirection, out RaycastHit hit, 5)) {
            Debug.DrawLine(transform.position, hit.point, Color.green);

            int x = Mathf.RoundToInt((hit.point.x + (width * squareSize) / 2 - squareSize/2) / squareSize);
            int y = Mathf.RoundToInt((hit.point.y + (height * squareSize) / 2 - squareSize/2) / squareSize);
            Debug.Log(new Vector2(x, y));

            mapManager.map[x, y] = 0;
            mapManager.ReloadMap();
        }

    }
}
