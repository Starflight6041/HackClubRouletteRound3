using UnityEngine;
using System.Collections;
public class Tile : MonoBehaviour
{
    private int x = -1;
    private int y = -1;
    private bool isOccupied = false;
    private bool isGoal = false;
    public Sprite goalSprite;
    private bool canPlace = false;
    public Sprite initialSprite;
    private int amountOccupied = 0;
    public Animator animator;
    public bool isRotator = false;
    public float rotationAmount = 0;
    public GameObject rotatorVisual;
    public void AddOccupied()
    {
        isOccupied = true;
        amountOccupied += 1;
    }
    public void RemoveOccupied()
    {
        isOccupied = false;
        amountOccupied -= 1;
    }
    public bool Rotates()
    {
        return isRotator;
    }
    public float GetRotation()
    {
        return rotationAmount;
    }
    public void SetRotator(float f)
    {
        rotationAmount = f;
        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
        Debug.Log("wahooooooooo");
        
        
        rotatorVisual.SetActive(true);
        isRotator = true;
        
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
            GetComponent<SpriteRenderer>().sprite = goalSprite;
            //animator.enabled = true;
            //animator.Play("Goal");
            Debug.Log("yeppers");
            //StartCoroutine(DelayBecauseUnityIsDumb());
        }

    }
    public void PlayAnimation()
    {
        animator.Play("Goal");
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
    public int GetOccupiedAmount()
    {
        return amountOccupied;
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
        //animator.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = initialSprite;
        //rotatorVisual.SetActive(false);
        //GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
