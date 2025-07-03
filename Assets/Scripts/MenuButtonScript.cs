using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Palyatoltes(string sceneNev)
    {
        SceneManager.LoadScene(sceneNev);
    }

    public void Kilepes()
    {
        Application.Quit();
    }
}
