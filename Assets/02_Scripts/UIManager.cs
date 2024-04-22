using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 로딩
using UnityEngine.UI; // UGUI
using TMPro; // TextMeshPro

// using UnityEngine.AI; // 네비게이션

public class UIManager : MonoBehaviour
{
    public Button startGameBtn;
    public Button optionsBtn;
    public Button shopsBtn;

    public void OnStartGameButtonClick()
    {
        Debug.Log("Click StartGame");
    }
}
