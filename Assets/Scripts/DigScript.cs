using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour
{
    float squareSize;
    float width, height;
    public MapManager mapManager;
    Vector3 digRayDirection;
    public float aimSpeed;
    public float shovelSize;
    public float digRange;

    float aimAngle = 3.14f;

    private void Start() {
        squareSize = mapManager.squareSize;
        width = mapManager.width;
        height = mapManager.height;
    }

    private void Update() {

        if(Input.GetKey(KeyCode.Keypad1)) aimAngle += aimSpeed*Time.deltaTime;
        if(Input.GetKey(KeyCode.Keypad2)) aimAngle -= aimSpeed*Time.deltaTime;
        

        digRayDirection = new Vector3(Mathf.Sin(aimAngle),Mathf.Cos(aimAngle)).normalized;

        Debug.DrawLine(transform.position, transform.position + digRayDirection * 3, Color.red);
        
        if(Input.GetKeyDown(KeyCode.Q)) {
            Dig();
        }
    }

    void Dig() {
        
        if(Physics.Raycast(transform.position, digRayDirection, out RaycastHit hit, digRange)) {

            Vector3 boundaryLeftBot = hit.point - shovelSize * 0.5f * Vector3.right - shovelSize * 0.5f * Vector3.up;
            Vector3 boundaryLeftTop = hit.point - shovelSize * 0.5f * Vector3.right + shovelSize * 0.5f * Vector3.up;
            Vector3 boundaryRightBot = hit.point + shovelSize * 0.5f * Vector3.right - shovelSize * 0.5f * Vector3.up;
            Vector3 boundaryRightTop = hit.point + shovelSize * 0.5f * Vector3.right + shovelSize * 0.5f * Vector3.up;


            Debug.DrawLine(boundaryLeftBot, boundaryLeftTop, Color.blue, 10f);
            Debug.DrawLine(boundaryLeftTop, boundaryRightTop, Color.blue, 10f);
            Debug.DrawLine(boundaryRightTop, boundaryRightBot, Color.blue, 10f);
            Debug.DrawLine(boundaryRightBot, boundaryLeftBot, Color.blue, 10f);



            int xMin = getSquareX(boundaryLeftBot.x);
            int xMax = getSquareX(boundaryRightBot.x);

            int yMin = getSquareY(boundaryLeftBot.y);
            int yMax = getSquareY(boundaryLeftTop.y);


            for(int x = 0; x < xMax-xMin; x++) {
                for(int y = 0; y < yMax-yMin; y++) {
                    if(x + xMin > 0 && x + xMin < width - 1 && y + yMin >0 && y + yMin < height) {
                        //Debug.Log(new Vector2(x + xMin, y + yMin));
                        mapManager.map[x + xMin, y + yMin] = 0;
                    } else {
                        Debug.LogWarning("Digging out of array");
                    }
                }
            }


            mapManager.ReloadMap();
        }

    }

    int getSquareX(float xPos) {
        float tempX = (width * squareSize + squareSize) / 2;
        tempX += xPos;
        tempX /= squareSize;

        return Mathf.RoundToInt(tempX) - 1;
    }

    int getSquareY(float yPos) {
        float tempY = (height * squareSize + squareSize) / 2;
        tempY += yPos;
        tempY /= squareSize;


        return Mathf.RoundToInt(tempY) - 1;
    }

}
