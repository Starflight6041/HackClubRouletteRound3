using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
