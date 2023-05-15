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

    private void Start()
    {
        inputName.text = BestScoreManager.Instance.Name;
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
