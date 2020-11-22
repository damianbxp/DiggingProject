using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager: MonoBehaviour
{
    public int width, height;
    public float squareSize = 1;

    private int[,] map;

    MeshGenerator meshGenerator;

    private void Start() {
        meshGenerator = GetComponent<MeshGenerator>();
        GenerateMap();
        meshGenerator.GenerateMesh(map, squareSize);
    }


    void GenerateMap() {
        map = new int[width, height];

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                map[i, j] = 1;
            }
        }

        map[2, 2] = 0;
        map[2, 3] = 0;
        map[3, 2] = 0;
        map[3, 3] = 0;

        map[6, 0] = 0;
        map[7, 0] = 0;
        map[8, 0] = 0;
        map[9, 0] = 0;

        map[7, 1] = 0;
        map[8, 1] = 0;
        map[8, 2] = 0;


    }
}
