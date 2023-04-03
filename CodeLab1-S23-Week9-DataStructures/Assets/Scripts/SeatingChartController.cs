using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatingChartController : MonoBehaviour
{
    private int numRows = 5;
    private int numCols = 4;

    private string[,] seatingChart;

    public Text display;
    
    void Start()
    {
        seatingChart = new string[numCols, numRows];

        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                seatingChart[x, y] = "";
            }
        }

        seatingChart[0, 0] = "Wei Kang";
        seatingChart[2, 2] = "Amber";
        seatingChart[1, 3] = "Jay";
        seatingChart[3, 1] = "Mo";
        seatingChart[0, 3] = "Kaitlin";
        seatingChart[2, 3] = "Ina";
        seatingChart[1, 1] = "Alessia";
        seatingChart[0, 4] = "Joy";
        seatingChart[3, 4] = "Laura";
        seatingChart[3, 3] = "Yanxi";
        seatingChart[3, 2] = "Walid";
        seatingChart[2, 1] = "Nate";
        seatingChart[1, 2] = "Beau";
        seatingChart[0, 2] = "George";
        

        PrintWhereSeated();
    }

    public void PrintWhereSeated()
    {
        string toPrint = "~~~~ FRONT ~~~~\n";
        for (int y = 0; y < seatingChart.GetLength(1); y++)
        {
            for (int x = 0; x < seatingChart.GetLength(0); x++)
            {
                if (seatingChart[x, y] != "")
                {
                    toPrint += " X ";
                }
                else
                {
                    toPrint += " _ ";
                }
            }

            toPrint += "\n";
        }

        toPrint += "~~~~ BACK ~~~~";

        display.text = toPrint;
    }

}
