using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MapCreator : MonoBehaviour
{
    public GameObject tile;
    
    public static List<Tile> occupied = new List<Tile>();
    public static List<Tile> unoccupied = new List<Tile>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        

        for (int x = 0; x < 11; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject a = Instantiate(tile, new Vector3(x * 1.2f - 6, y * 1.2f - 4), Quaternion.identity);
                Tile b = a.GetComponent<Tile>();
                b.ChangeX(x);
                b.ChangeY(y);
                unoccupied.Add(b.GetComponent<Tile>());

            }
        }
    }
    public static void Occupy(int x, int y)
    {
        //potentially add crashing method call if it fails to add anything
        for (int i = unoccupied.Count - 1; i >= 0; i--)
        {
            if (unoccupied[i].GetX() == x && unoccupied[i].GetY() == y)
            {
                unoccupied[i].ChangeOccupied(true);
                occupied.Add(unoccupied[i]);
                unoccupied.RemoveAt(i);
            }
        }
    }
    public static void Unoccupy(int x, int y)
    {
        for (int i = occupied.Count - 1; i >= 0; i--)
        {
            if (occupied[i].GetX() == x && occupied[i].GetY() == y)
            {
                occupied[i].ChangeOccupied(false);
                unoccupied.Add(occupied[i]);
                occupied.RemoveAt(i);
            }
        }
    }
    public static bool IsOccupied(int x, int y)
    {
        for (int i = 0; i < occupied.Count; i++)
        {
            if (occupied[i].GetX() == x && occupied[i].GetY() == y)
            {
                return true;
            }
            
        }
        for (int i = 0; i < unoccupied.Count; i++)
        {
            if (unoccupied[i].GetX() == x && unoccupied[i].GetY() == y)
            {
                return false;
            }
            
        }
        return true;
    }
    public static Vector2 GetPos(int x, int y)
    {
        return new Vector2(x * 1.2f - 6, y * 1.2f - 4);
    }
    public static Vector2 CoordFromPos(int x, int y)
    {
        return new Vector2((x + 6) / 1.25f, (y + 4) / 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
