using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public Text BestPlayerText;
    public static bool isLoaded = false;

    private void Update()
    {
        if (!isLoaded)
        {
            BestScoreManager.Instance.LoadBestPlayer();
            BestPlayerText.text = "Best Score: " + BestScoreManager.Instance.BestPlayerName + 
            " : " + BestScoreManager.Instance.BestPlayerScore;
            inputName.text = BestScoreManager.Instance.Name;
            isLoaded = true;
        }
    }

    public void StartNew()
    {
        BestScoreManager.Instance.SaveBestPlayer();
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        BestScoreManager.Instance.Name = inputName.text;
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
