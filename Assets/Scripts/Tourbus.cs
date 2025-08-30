using UnityEngine;
using System.Collections;
public class Tourbus : Car
{
    public static int numCars = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutineLength = .5f;
        isAtDestination = false;
        amountText.text = numCars.ToString();
    }
    public override void SetCarAmount(int a)
    {
        numCars = a;
    }
    public override IEnumerator Move()
    {
        while (gameManager.StillRunning() && !isAtDestination)
        {
            MoveToTile(x + 1 * xOrientation, y + 1 * yOrientation);
            yield return new WaitForSeconds(coroutineLength);
            if (map.GetTile(x, y))
            {
                if (map.GetTile(x, y).GetOccupiedAmount() > 1)
                {
                    gameManager.FailLevel();
                }

            }
            else
            {
                gameManager.FailLevel();
            }
            map.RemoveIntersectionFromList(intersection);
            yield return new WaitForSeconds(0.001f);
            if (!isAtDestination && gameManager.StillRunning())
            {
                MoveToTile(x + 1 * xOrientation, y + 1 * yOrientation);
                yield return new WaitForSeconds(coroutineLength);
                if (map.GetTile(x, y))
                {
                    if (map.GetTile(x, y).GetOccupiedAmount() > 1)
                    {
                        gameManager.FailLevel();
                    }

                }
                else
                {
                    gameManager.FailLevel();
                }
                map.RemoveIntersectionFromList(intersection);
                yield return new WaitForSeconds(0.001f);
            }

            if (!isAtDestination && gameManager.StillRunning())
            {
                Vector2 modified = Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(0, 0, rotation), 360) * Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, rotation - 90);
                Debug.Log(modified.y);
                MoveToTile(x + 1 * Mathf.RoundToInt(modified.x), y + 1 * (int)Mathf.RoundToInt(modified.y));
                yield return new WaitForSeconds(coroutineLength);
                if (map.GetTile(x, y))
                {
                    if (map.GetTile(x, y).GetOccupiedAmount() > 1)
                    {
                        gameManager.FailLevel();
                    }

                }
                else
                {
                    gameManager.FailLevel();
                }
                map.RemoveIntersectionFromList(intersection);
                yield return new WaitForSeconds(0.001f);
            }
            if (!isAtDestination && gameManager.StillRunning())
            {
                Vector2 modified = Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(0, 0, rotation), 360) * Vector2.down;
                Debug.Log(modified.y);
                transform.rotation = Quaternion.Euler(0, 0, rotation - 180);
                MoveToTile(x + 1 * Mathf.RoundToInt(modified.x), y + 1 * (int)Mathf.RoundToInt(modified.y));
                yield return new WaitForSeconds(coroutineLength);
                if (map.GetTile(x, y))
                {
                    if (map.GetTile(x, y).GetOccupiedAmount() > 1)
                    {
                        gameManager.FailLevel();
                    }

                }
                else
                {
                    gameManager.FailLevel();
                }
                map.RemoveIntersectionFromList(intersection);
                yield return new WaitForSeconds(0.001f);
                transform.rotation = Quaternion.Euler(0, 0, rotation);
            }

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
        amountText.text = numCars.ToString();
//        Debug.Log("mettaton oh yes");
    }
    public override void IncrementOneCar()
    {
        numCars += 1;
        amountText.text = numCars.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
