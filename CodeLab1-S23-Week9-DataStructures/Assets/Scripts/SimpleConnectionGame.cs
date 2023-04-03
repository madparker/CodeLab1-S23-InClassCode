using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleConnectionGame : MonoBehaviour
{
    public int width = 7;
    public int height = 6;
    
    private int[,] grid; // 0 be an empty space, 1 be blue, and 2 be red

    public Text display;
    
    private bool redTurn = false;

    private List<GameObject> spawnedPieces = new List<GameObject>();

    public GameObject redPrefab, bluePrefab;

    private void Start()
    {
        // Instantiate and initialize the grid.
        
        grid = new int[width, height];

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                grid[x, y] = 0;
            }
        }
    }

    private void Update()
    {
        // If you press space, it reloads the scene.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // If a space is 1, it's "blue"
    public bool ContainsBlue(int x, int y)
    {
        return grid[x, y] == 1;
    }

    // If a space is 2, it's "red"
    public bool ContainsRed(int x, int y)
    {
        return grid[x, y] == 2;
    }

    // If a space is 0, it's empty.
    public bool IsEmpty(int x, int y)
    {
        return grid[x, y] == 0;
    }

    // If the highest space in the column is empty, 
    // you can add another piece.
    public bool ColumnFilled(int column)
    {
        return !IsEmpty(column, height - 1);
    }

    // This function is used to add a piece to a column
    public void AddToColumn(int column)
    {
        // If a column is full, do nothing.
        if (ColumnFilled(column)) return;

        // If either player has already won, do nothing.
        if (BlueWin() || RedWin()) return;
        
        // Find the lowest empty space in the column, and add a piece.
        for (var y = 0; y < height; y++)
        {
            if (IsEmpty(column, y))
            {
                if (redTurn)
                    grid[column, y] = 2;
                else
                    grid[column, y] = 1;

                redTurn = !redTurn;

                // once a piece is added, update the display.
                UpdateDisplay();
                return;
            }
        }
    }

    private void UpdateDisplay()
    {
        // To update the display, first destroy all the pieces that were spawned.
        foreach (var piece in spawnedPieces)
        {
            Destroy(piece);
        }
        
        spawnedPieces.Clear();

        // Then, for everything in the grid, if it's not 0, spawn the correct piece.
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (ContainsRed(x, y))
                {
                    var redPiece = Instantiate(redPrefab);
                    redPiece.transform.position = new Vector3(x, y);
                    spawnedPieces.Add(redPiece);
                }
                if (ContainsBlue(x, y))
                {
                    var bluePiece = Instantiate(bluePrefab);
                    bluePiece.transform.position = new Vector3(x, y);
                    spawnedPieces.Add(bluePiece);
                }
            }
        }
        
        // check to see if red or blue won.
        if (RedWin())
        {
            display.text = "RED WINS!";
            display.color = Color.red;
        }
        else if (BlueWin())
        {
            display.text = "BLUE WINS!";
            display.color = Color.blue;
        }
        else
        {
            display.text = "";
        }
    }
    
    public bool RedWin()
    {
        return FourInARow() == 2;
    }

    public bool BlueWin()
    {
        return FourInARow() == 1;
    }

    // This function checks for four in a row, and returns the number that is four in a row.
    // 1 for blue
    // 2 for red
    public int FourInARow()
    {
        
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (y <= height - 4)
                    if (grid[x,y] != 0 &&
                        grid[x, y] == grid[x, y + 1] &&
                        grid[x, y] == grid[x, y + 2] &&
                        grid[x, y] == grid[x, y + 3])
                        return grid[x, y];
             
                if (x <= width - 4)               
                    if (grid[x,y] != 0 && grid[x, y] == grid[x + 1, y] && grid[x, y] == grid[x + 2, y] && grid[x, y] == grid[x + 3, y])
                        return grid[x, y];

                if (x <= width - 4 && y <= height - 4)
                    if (grid[x,y] != 0 && grid[x, y] == grid[x + 1, y + 1] && grid[x, y] == grid[x + 2, y + 2] && grid[x, y] == grid[x + 3, y + 3])
                        return grid[x, y];

                if (x >= width - 4 && y <= height - 4)
                    if (grid[x,y] != 0 && grid[x, y] == grid[x - 1, y + 1] && grid[x, y] == grid[x - 2, y + 2] && grid[x, y] == grid[x - 3, y + 3])
                        return grid[x, y];
            }
        }

        return 0;
    }
}
