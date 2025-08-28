using Unity.Collections;
using UnityEngine;
using System.Collections;
public class Racecar : Car
{
    public static int numCars = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutineLength = .5f;
        isAtDestination = false;
    }
    public override IEnumerator Move()
    {
        while (gameManager.StillRunning() && !isAtDestination)
        {
            MoveToTile(x + 1 * xOrientation, y + 1 * yOrientation);
            yield return new WaitForSeconds(coroutineLength);
            //MoveToTile(x, y + 1);
            //yield return new WaitForSeconds(coroutineLength);
        }
        
        //MoveToTile(x, y + 1);
//      Debug.Log("yes");
    }
    

    public override int GetCarAmount()
    {
        return numCars;
    }
    public override void ReduceOneCar()
    {
        numCars -= 1;
//        Debug.Log("mettaton oh yes");
    }
    public override void IncrementOneCar()
    {
        numCars += 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
