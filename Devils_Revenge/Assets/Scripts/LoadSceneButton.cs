using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void loadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void loadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void exitSceneButton()
    {
        Application.Quit();
    }
}
