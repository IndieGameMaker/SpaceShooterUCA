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

    void OnEnable()
    {
        startGameBtn.onClick.AddListener(() =>
        {
            Debug.Log("시작버튼 클릭");
            SceneManager.LoadScene("Level01");
            SceneManager.LoadScene("Play", LoadSceneMode.Additive);
        });

        optionsBtn.onClick.AddListener(() =>
        {
            Debug.Log("옵션버튼 클릭");
        });
    }

    public void OnStartGameButtonClick()
    {
        Debug.Log("Click StartGame");
    }
}
