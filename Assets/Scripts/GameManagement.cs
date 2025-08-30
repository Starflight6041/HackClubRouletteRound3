using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering.Universal;
using System;

public class GameManagement : MonoBehaviour
{
    public InputAction mousePos;
    private bool levelDone;
    public GameObject gameOverCanvas;
    public GameObject tourbus;
    private bool levelFed;
    public MapCreator map;
    PointerEventData m_PointerEventData;
    public InputAction click;
    public GraphicRaycaster raycaster;
    
    public EventSystem eventSystem;
    public GameObject racecar;
    public List<Car> carsPlaced = new List<Car>();
    private GameObject toBePlaced;
    private IEnumerator e;
    public Canvas aCanvas;
    public int numGoals;
    public int goalsReached = 0;
    public Canvas gameWinCanvas;
    //public int racecarCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelDone = false;
        levelFed = false;
        gameWinCanvas.gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
        mousePos = InputSystem.actions.FindAction("Point");
        e = RunPuzzle();
        click = InputSystem.actions.FindAction("Click");
    }
    public void SetGoalAmount(int a)
    {
        numGoals = a;
    }
    public void IncrementGoals()
    {
        goalsReached++;
        if (goalsReached == numGoals)
        {
            gameWinCanvas.gameObject.SetActive(true);
            levelDone = true;
        }
        
    }
    private void OnCancelAction()
    {
        if (!aCanvas.isActiveAndEnabled)
        {
            aCanvas.gameObject.SetActive(true);
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()), Vector2.zero);
        if (hit.collider)
        {
            if (hit.collider.gameObject.GetComponent<Car>())
            {
                GameObject carhit = hit.collider.gameObject;
                carhit.GetComponent<Car>().IncrementOneCar();
                carsPlaced.Remove(carhit.GetComponent<Car>());
                map.Unoccupy(carhit.GetComponent<Car>().GetX(), carhit.GetComponent<Car>().GetY());
                Destroy(carhit);
            }
        }
    }
    private void OnClick()
    {
        if (click.WasPressedThisFrame())
        {
            if (aCanvas.isActiveAndEnabled)
            {
                m_PointerEventData = new PointerEventData(eventSystem);
                m_PointerEventData.position = mousePos.ReadValue<Vector2>();
                List<RaycastResult> results = new List<RaycastResult>();
                raycaster.Raycast(m_PointerEventData, results);
                foreach (RaycastResult result in results)
                {



                    switch (result.gameObject.tag)
                    {

                        case "racecar":
                            //Debug.Log("Racecar");
                            if (racecar.GetComponent<Racecar>().GetCarAmount() > 0)
                            {
                                toBePlaced = racecar;
                            }

                            break;
                        case "tourbus":
                            //Debug.Log("Racecar");
                            if (tourbus.GetComponent<Tourbus>().GetCarAmount() > 0)
                            {
                                toBePlaced = tourbus;
                            }

                            break;
                    }
                    if (result.gameObject.tag == "start")
                    {
                        if (carsPlaced.Count == 0)
                        {
                            FailLevel();
                        }
                        StartCoroutine(e);
                    }



                }
                if (toBePlaced)
                {
                    aCanvas.gameObject.SetActive(false);
                }

            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()), Vector2.zero);
                if (hit.collider)
                {
                    if (hit.collider.gameObject.GetComponent<Tile>())
                    {
                        Tile t = hit.collider.gameObject.GetComponent<Tile>();
                        if (toBePlaced)
                        {
                            if (!t.GetOccupied() && t.IsPlaceable() && toBePlaced.GetComponent<Car>().GetCarAmount() > 0)
                            {
                                GameObject g = Instantiate(toBePlaced);
                                g.GetComponent<Car>().SetX(t.GetX());
                                g.GetComponent<Car>().SetY(t.GetY());
                                g.transform.position = MapCreator.GetPos(t.GetX(), t.GetY());
                                g.GetComponent<Car>().SetPlayerPlaced(true);
                                map.Occupy(t.GetX(), t.GetY());
                                toBePlaced.GetComponent<Car>().ReduceOneCar();
                                //                                Debug.Log(toBePlaced.GetComponent<Car>().GetCarAmount());
                                aCanvas.gameObject.SetActive(true);
                                carsPlaced.Add(g.GetComponent<Car>());
                                toBePlaced = null;

                            }
                        }
                    }
                }
            }




        }


    }
    public void PlaceMapCar(int x, int y, String s, float r)
    {
        switch (s)
        {
            case "racecar":
                GameObject g = Instantiate(racecar);
                g.GetComponent<Car>().SetX(x);
                g.GetComponent<Car>().SetY(y);
                g.transform.position = MapCreator.GetPos(x, y);
                g.GetComponent<Car>().SetPlayerPlaced(false);
                g.GetComponent<Car>().SetRotation(r);
                map.Occupy(x, y);
                carsPlaced.Add(g.GetComponent<Car>());
                break; 

            
        }
    }
    public bool StillRunning()
    {
        return !levelDone && !levelFed;
    }
    public void FailLevel()
    {

//        Debug.Log("setting");
        gameOverCanvas.SetActive(true);
        levelFed = true;
        
        
    }
    
    IEnumerator RunPuzzle()
    {
        //float startingTime;
        //while (!levelDone && !levelFailed)
        //{


            foreach (Car car in carsPlaced)
            {
                if (!car.isAtGoal())
                {
                    //startingTime = Time.time;
                    StartCoroutine(car.Move());
                    //yield return new WaitForSeconds(car.GetCoroutineLength());
                    //StartCoroutine(MoveCar(car, startingTime));
                }

                //Debug.Log(car.GetProspectiveLocation());
            }


            //Debug.Log("new pos");
        //}
        yield return new WaitForEndOfFrame();
        
        
    }
    public IEnumerator MoveCar(Car c, float t)
    {
//        Debug.Log("yep");
        while ((Vector2)c.gameObject.transform.position != c.GetProspectiveLocation())
        {
            c.gameObject.transform.position = new Vector2(Mathf.Lerp(c.GetPastLocation().x, c.GetProspectiveLocation().x, (Time.time - t) * 2.1f), Mathf.Lerp(c.GetPastLocation().y, c.GetProspectiveLocation().y, (Time.time - t) * 2.1f));
            yield return new WaitForEndOfFrame();

            //Debug.Log("yep");
        }
        
    }
    public void OnRotate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()), Vector2.zero);
        if (hit.collider)
        {
            if (hit.collider.gameObject.GetComponent<Car>())
            {
                if (hit.collider.gameObject.GetComponent<Car>().GetPlayerPlaced())
                {
                    hit.collider.gameObject.GetComponent<Car>().Rotate();
                }
                
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
