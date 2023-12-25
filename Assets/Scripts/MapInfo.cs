using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public int[] CellInfo = new int[10]; // Store cell information.
    /*Rules:
    1. CellInfo[i] = [[x1, y1], [x2, y2], ...], [xn, yn] represents the coordinate of the cell; (BottomLeft = [0, 0])
    2. CellInfo[0] stores the info of START  cell;
    3. CellInfo[1] stores the info of END    cell;
    4. CellInfo[2] stores the info of NORMAL cell, and ACTUALLY we do not need to store them here;
    5. CellInfo[3] stores the info of WALL   cell;
    6. CellInfo[4] stores the info of SKILL  cell;
    7. CellInfo[5] stores the info of RIVER  cell;
    ...to be continued...
    */


    
}
