using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    private string inputName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName (string input){
        inputName = input;
        Debug.Log(inputName);
    MainManager.Instance.playerName = input;
}

    public void StartNew()
{
    SceneManager.LoadScene(1);
}

public void Exit()
{
   // MainManager.Instance.SaveColor(); 
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif// original code to quit Unity player
}
}
