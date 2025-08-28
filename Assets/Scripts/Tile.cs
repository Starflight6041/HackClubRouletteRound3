using UnityEngine;

public class Tile : MonoBehaviour
{
    private int x = -1;
    private int y = -1;
    private bool isOccupied = false;
    private bool isGoal = false;
    private bool canPlace = false;
    public void ChangeOccupied(bool a)
    {
        isOccupied = a;
    }
    public bool IsGoal()
    {
        return isGoal;
    }
    public void ChangeGoalStatus(bool a)
    {
        isGoal = a;
        if (isGoal)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
        }

    }
    public bool IsPlaceable()
    {
        return canPlace;
        
    }
    public void ChangePlaceable(bool a)
    {
        canPlace = a;
        if (canPlace)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color,", Color.grey);
        }
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
        
        //GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
