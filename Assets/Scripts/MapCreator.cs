using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject tile;
    public List<Tile> occupied = new List<Tile>();
    public List<Tile> unoccupied = new List<Tile>();
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
    public void Occupy(int x, int y)
    {
        for (int i = unoccupied.Count - 1; i >= 0; i--)
        {
            
        }
    }
    public static Vector2 GetPos(int x, int y)
    {
        return new Vector2(x * 1.2f - 6, y * 1.2f - 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
