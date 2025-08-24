using UnityEngine;

public class Tile : MonoBehaviour
{
    private int x = -1;
    private int y = -1;
    private bool isOccupied = false;
    public void ChangeOccupied(bool a)
    {
        isOccupied = a;
    }
    public bool GetOccupied()
    {
        return isOccupied;
    }
    public void ChangeX(int a)
    {
        x = a;
    }
    public void ChangeY(int b)
    {
        y = b;
    }
    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
