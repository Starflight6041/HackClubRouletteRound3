using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class MapCreator : MonoBehaviour
{
    public GameObject tile;
    
    public List<Tile> occupied = new List<Tile>();
    public List<Tile> unoccupied = new List<Tile>();
    //public GameManagement gameManager;
    public List<Vector2> intersections = new List<Vector2>();
    public LevelSetup levelSetup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



        for (int x = 0; x < 11; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject a = Instantiate(tile, new Vector3(x * 1.2f - 6, y * 1.2f - 4, 3), Quaternion.identity);
                Tile b = a.GetComponent<Tile>();
                b.ChangeX(x);
                b.ChangeY(y);
                //b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, -1);
                b.ChangeGoalStatus(false);
                b.ChangePlaceable2(false);
                unoccupied.Add(b.GetComponent<Tile>());

            }
        }
        
        levelSetup.SetLevelGoals();
    }
    
    
    public void Occupy(int x, int y)
    {
        //potentially add crashing method call if it fails to add anything
        for (int i = unoccupied.Count - 1; i >= 0; i--)
        {
            if (unoccupied[i].GetX() == x && unoccupied[i].GetY() == y)
            {
                unoccupied[i].AddOccupied();
                occupied.Add(unoccupied[i]);
                unoccupied.RemoveAt(i);
            }
        }
    }
    public void AddIntersectionToList(Vector2 a)
    {
        intersections.Add(a);
    }
    public void RemoveIntersectionFromList(Vector2 a)
    {
        intersections.Remove(a);
    }
    public bool IsOverlappingIntersection()
    {
        for (int i = 0; i < intersections.Count - 1; i++) //ooooh sick -1 for increased time efficiency so we don't have to check the last one!!!
        {
            for (int a = i + 1; a < intersections.Count; a++)
            {
                if (intersections[i] == intersections[a])
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void Unoccupy(int x, int y)
    {
        for (int i = occupied.Count - 1; i >= 0; i--)
        {
            if (occupied[i].GetX() == x && occupied[i].GetY() == y)
            {
                occupied[i].RemoveOccupied();
                unoccupied.Add(occupied[i]);
                occupied.RemoveAt(i);
            }
        }
    }
    public bool IsOccupied(int x, int y)
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
    public Tile GetTile(int x, int y)
    {
        for (int i = 0; i < occupied.Count; i++)
        {
            if (occupied[i].GetX() == x && occupied[i].GetY() == y)
            {
                return occupied[i];
            }

        }
        for (int i = 0; i < unoccupied.Count; i++)
        {
            if (unoccupied[i].GetX() == x && unoccupied[i].GetY() == y)
            {
                return unoccupied[i];
            }


        }
        return null;
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
