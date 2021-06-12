using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public TextMeshProUGUI level;

    public int PlatformIncAtEach = 5;

    public GameObject GameOverScreen;
    public TextMeshProUGUI Question;
    public GameObject GamePauseScreen;
    public CustomToggle canUseMinus;
    public Button canUseAddBtn;
    public Button canUseSubBtn;
    public Button canUseMulBtn;
    public Button canUseDivBtn;
    public Color EnableColor;
    public Color DisableColor;
    Platform GameOverPlatform;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Start()
    {
        LoadLevel();
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver(Platform platform)
    {
        Time.timeScale = 0;
        GameOverPlatform = platform;
        GameOverScreen.SetActive(true);
        Question.text = platform.QuesText.text + " = "+ platform.question.Ans;
        //Question.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "is " + platform.question.Ans;

    }
    public void ContinueGamePlay()
    {
        foreach(Transform child in GameOverPlatform.transform)
        {
            child.gameObject.SetActive(false);
        }
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void CloseGameOverScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SaveLevel();
        SceneManager.LoadScene(1);
    }
    public void SaveLevel()
    {
        currentLevel++;
        SaveAndLoad.SaveLevel(currentLevel);
    }
    public void LoadLevel()
    {
        for(int i=0;i<4; i++)
        {
            OnCanUseOperationViews(i);
        }
        canUseMinus.SetIsOn(SaveAndLoad.GetCanUseMinusValue());
        Time.timeScale = 1;
        GameOverScreen.SetActive(false);
        GamePauseScreen.SetActive(false);
        currentLevel = SaveAndLoad.GetLevel();
        level.text = "Level " + currentLevel.ToString();
        int val = currentLevel / PlatformIncAtEach;
        if (val != 0)
        {
            PlatformManager.Instance.AddPlatformCount(val);
        }
        PlatformManager.Instance.SetUpPlatforms();
    }
    public void OnCanUseMinusClick(bool canUseMinus)
    {
        SaveAndLoad.SaveCanUseMinusValue(canUseMinus);
    }
    public void OnPauseClick()
    {

        Time.timeScale = 0;
        GamePauseScreen.SetActive(true);
    }
    public void OnCanUseOperationClick(int val)
    {
        bool status = false;
        if (val == 0)
        {
            status = SaveAndLoad.GetCanUseAddition();
            if (!status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Add);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Add))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Add);
            SaveAndLoad.SaveCanUseAddition(!status);
            canUseAddBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 1)
        {
            status = SaveAndLoad.GetCanUseSubtraction();
            if (!status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Sub);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Sub))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Sub);
            SaveAndLoad.SaveCanUseSubtraction(!status);
            canUseSubBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 2)
        {
            status = SaveAndLoad.GetCanUseMultiplication();
            if (!status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Mul);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Mul))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Mul);
            SaveAndLoad.SaveCanUseMultiplication(!status);
            canUseMulBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 3)
        {
            status = SaveAndLoad.GetCanUseDivition();
            if (!status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Div);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Div))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Div);
            SaveAndLoad.SaveCanUseDivition(!status);
            canUseDivBtn.image.color = !status ? EnableColor : DisableColor;
        }
    }
    public void OnCanUseOperationViews(int val)
    {
        bool status = false;
        if (val == 0)
        {
            status = SaveAndLoad.GetCanUseAddition();
            if (status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Add);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Add))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Add);

            canUseAddBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 1)
        {
            status = SaveAndLoad.GetCanUseSubtraction();

            if (status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Sub);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Sub))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Sub);

            canUseSubBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 2)
        {
            status = SaveAndLoad.GetCanUseMultiplication();

            if (status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Mul);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Mul))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Mul);

            canUseMulBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 3)
        {
            status = SaveAndLoad.GetCanUseDivition();

            if (status == true)
                PlatformManager.Instance.PossibleOperations.Add(OprationType.Div);
            else if (PlatformManager.Instance.PossibleOperations.Contains(OprationType.Div))
                PlatformManager.Instance.PossibleOperations.Remove(OprationType.Div);

            canUseDivBtn.image.color = status ? EnableColor : DisableColor;
        }
    }
}
