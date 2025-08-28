using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class Car : MonoBehaviour
{
    public int x;
    public int y;
    public int xOrientation; // 1 is right, -1 is left
    public int yOrientation; // 1 is up, -1 is down
    private Vector2 prospectiveLocation;
    private Vector2 pastLocation;
    public bool isAtDestination;
    public GameManagement gameManager;
    public MapCreator map;
    public float coroutineLength;
    private bool atGoal = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GameObject.Find("GameOverCanvas"));
        
        pastLocation = MapCreator.GetPos(x, y);
    }
    public void ChangeDestinationStatus(bool a)
    {
        isAtDestination = a;
    }
    public virtual int GetCarAmount()
    {
        return 0;
    }
    public virtual void ReduceOneCar()
    {
        Debug.Log("oh nor");
    }
    //public virtual void Move()
    //{

    //}
    public void SetX(int a)
    {
        x = a;
    }
    public void SetY(int b)
    {
        y = b;
    }
    public void MoveToTile(int a, int b)
    {
        if (!MapCreator.IsOccupied(a, b))
        {
            MapCreator.Unoccupy(x, y);
            MapCreator.Occupy(a, b);
            pastLocation = MapCreator.GetPos(x, y);
            prospectiveLocation = MapCreator.GetPos(a, b);
            x = a;
            y = b;
            StartCoroutine(gameManager.MoveCar(this, Time.time));
            Debug.Log(MapCreator.GetTile(a, b));
            if (MapCreator.GetTile(a, b).IsGoal())
            {
                ChangeDestinationStatus(true);
                Debug.Log("I'm here!");
            }
            //Debug.Log("yep function call");

        }
        else
        {
            pastLocation = MapCreator.GetPos(x, y);
            prospectiveLocation = MapCreator.GetPos(a, b);
            x = a;
            y = b;
            StartCoroutine(gameManager.MoveCar(this, Time.time));
            gameManager.FailLevel();
        }
    }
    public float GetCoroutineLength()
    {
        return coroutineLength;
    }
    public bool isAtGoal()
    {
        return atGoal;
    }
    public Vector2 GetProspectiveLocation()
    {
        return prospectiveLocation;
    }
    public Vector2 GetPastLocation()
    {
        return pastLocation;
    }
    public virtual void IncrementOneCar()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public virtual IEnumerator Move()
    {
        return null;
    }
}
