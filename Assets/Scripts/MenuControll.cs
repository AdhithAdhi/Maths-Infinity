using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControll : MonoBehaviour
{
    public TextMeshProUGUI level;
    // Start is called before the first frame update
    void Start()
    {
        level.text = "Level " + SaveAndLoad.GetLevel();
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSettingsClick()
    {
        SceneManager.LoadScene(2);
    }
}
