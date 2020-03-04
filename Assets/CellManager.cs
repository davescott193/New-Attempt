using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{

    public int mapWidth = 50, mapHeight = 50;

    public GameObject cellPrefab;
    public Dictionary<Vector3, GameObject> cells = new Dictionary<Vector3, GameObject>();

    private void Start()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                GameObject localCell = Instantiate(cellPrefab, new Vector3(x, y), Quaternion.identity);
                localCell.AddComponent<Cell>().cellManager = this;
                cells.Add(new Vector3(x, y), localCell);
            }

        }
    }
}