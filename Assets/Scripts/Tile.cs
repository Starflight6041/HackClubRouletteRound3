using UnityEngine;
using System.Collections;
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
    public void ChangePlaceable(bool a)
    {
        canPlace = a;
        if (canPlace)
        {
            Debug.Log("yeppers"); //why do you not work? why? why? why don't you change the color to green?
            GetComponent<SpriteRenderer>().material.SetColor("_Color,", Color.green);
        }
    }
    public void ChangePlaceable2(bool a)
    {
        canPlace = a; // spent 2 hours debugging this, then wrote the exact same function again and it worked this time. I love unity.
        if (canPlace)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
        }
    }
    public void ChangeGoalStatus(bool a)
    {
        isGoal = a;
        if (isGoal)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
            //StartCoroutine(DelayBecauseUnityIsDumb());
        }

    }
    IEnumerator DelayBecauseUnityIsDumb()
    {
        yield return new WaitForSeconds(0.2f);
        //GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
    }
    public bool IsPlaceable()
    {
        return canPlace;

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
