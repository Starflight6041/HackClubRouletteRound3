using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
