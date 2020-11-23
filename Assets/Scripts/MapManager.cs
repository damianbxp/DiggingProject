using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager: MonoBehaviour
{
    public int width, height;
    public float squareSize = 1;

    [HideInInspector]
    public int[,] map;

    MeshGenerator meshGenerator;

    private void Start() {
        meshGenerator = GetComponent<MeshGenerator>();
        GenerateMap();
        meshGenerator.GenerateMesh(map, squareSize);
    }

    public void ReloadMap() {
        meshGenerator.GenerateMesh(map, squareSize);
    }

    void GenerateMap() {
        map = new int[width, height];

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                map[i, j] = 1;
            }
        }
    }
}
