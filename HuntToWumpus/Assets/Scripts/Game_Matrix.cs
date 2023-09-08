using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MatrixField
{
    public int Cord_x = 0;
    public int Cord_y = 0;
    public FieldCategory FieldType = FieldCategory.None;
    public bool IsPlayerHere = false;
    public MapField FieldGameObject;

    public MatrixField(int cordX, int cordY, FieldCategory fieldType)
    {
        
        this.Cord_x = cordX;
        this.Cord_y = cordY;
        this.FieldType = fieldType;
    }
}

[Flags]
public enum FieldCategory
{
    None = 0,
    Player = 1,
    Visited = 2,
    Wumpus = 4,
    Cave = 8,
    Pit = 16,
    Default = 32,
}
