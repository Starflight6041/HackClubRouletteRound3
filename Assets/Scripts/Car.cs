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
    private float rotation; 
    public float coroutineLength;
    private bool atGoal = false;
    public Vector2 intersection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation = 0;
        xOrientation = 0;
        yOrientation = 1;
        //Debug.Log(GameObject.Find("GameOverCanvas"));

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
    public void Rotate()
    {
        xOrientation = 0;
        yOrientation = 0;
        rotation = (rotation + 90);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        if (rotation % 360 == 270 || rotation % 360 == -90)
        {
            xOrientation = 1;
            
        }
        else if (rotation % 360 == 90 || rotation % 360 == -270)
        {
            xOrientation = -1;
        }
        else if (rotation % 360 == 0)
        {
            yOrientation = 1;
        }
        else if (Mathf.Abs(rotation) % 360 == 180)
        {
            yOrientation = -1; // if I was going to do this why didn't I just do this from the start instead of division lmfao
        }
        
    }
    public void MoveToTile(int a, int b)
    {
        intersection = new Vector2(x + (float) (a - x) / 2, y + (float) (b - y) / 2);
        map.AddIntersectionToList(intersection);
        if (!map.IsOverlappingIntersection()) //used to be other condition
        {

            map.Unoccupy(x, y);
            map.Occupy(a, b);
            pastLocation = MapCreator.GetPos(x, y);
            prospectiveLocation = MapCreator.GetPos(a, b);
            x = a;
            y = b;
            StartCoroutine(gameManager.MoveCar(this, Time.time));
            Debug.Log(map.GetTile(a, b));
            if (map.GetTile(a, b))
            {
                if (map.GetTile(a, b).IsGoal())
                {
                    ChangeDestinationStatus(true);
                    Debug.Log("I'm here!");
                }

            }
            //Debug.Log("yep function call");

        }
        else
        {

            pastLocation = MapCreator.GetPos(x, y);
            prospectiveLocation = MapCreator.GetPos(a, b);
            Debug.Log(intersection);
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
