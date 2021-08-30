using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;

    // For Checking that this grid has tower or not
    public static bool[,] mapCheck;
    private GameObject[,] mapData;

    private int width;
    private int height;


    private void Start()
    {
        // Set size of 2D Array
        GenerateGrid();
        //Check();
    }

    private void GenerateGrid()
    {
        GameObject[] checkMapGrid;

        checkMapGrid = GameObject.FindGameObjectsWithTag("Platform");

        for (int j = 0; j < checkMapGrid.Length; j++)
        {
            int x = Mathf.Abs((int)checkMapGrid[j].transform.position.x);
            int y = Mathf.Abs((int)checkMapGrid[j].transform.position.y);
            width = (width < x) ? x : width;
            height = (height < y) ? y : height;
        }

        mapData = new GameObject[width+1, height+1];
        mapCheck = new bool[width+1, height+1];

        for (int j = 0; j < checkMapGrid.Length; j++)
        {
            int x = Mathf.Abs((int)checkMapGrid[j].transform.position.x);
            int y = Mathf.Abs((int)checkMapGrid[j].transform.position.y);
            mapData[x,y] = checkMapGrid[j];
        }
        cameraPos.transform.position = new Vector3(width / 2.0f, -height / 2.0f, -10.0f);
    }

    private void Check()
    {
        print(width + " " + height);
        for(int j=0;j<=width;j++)
        {
            for(int k=0;k<=height;k++)
            {
                print(j + " " + k + "  " + mapData[j,k]);
            }
        }
    }


    public Vector2 GetMapSize()
    {
        return new Vector2(width, height);
    }
}
