using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager: MonoBehaviour
{

    public Button canUseAddBtn;
    public Button canUseSubBtn;
    public Button canUseMulBtn;
    public Button canUseDivBtn;
    public CustomToggle canUseMinus;
    public CustomToggle BgmToggle;
    public CustomToggle SfxToggle;
    public Color EnableColor;
    public Color DisableColor;

    private void Start()
    {
        BgmToggle.SetIsOn(SaveAndLoad.bgmState());
        SfxToggle.SetIsOn(SaveAndLoad.sfxState());

        for (int i = 0; i < 4; i++)
        {
            OnCanUseOperationViews(i);
        }
        canUseMinus.SetIsOn(SaveAndLoad.GetCanUseMinusValue());
    }
    public void OnBackBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void MuteBgm(bool bgmCheckbox)
    {
        SaveAndLoad.SetBgmState(bgmCheckbox);
        //if (SoundManager.Instance != null)
        //    SoundManager.Instance.IntializeBgmSoundsAsState(!bgmCheckbox);
    }
    public void MuteSfx(bool sfxCheckbox)
    {
        SaveAndLoad.SetSfxState(sfxCheckbox);
        //if (SoundManager.Instance != null)
        //    SoundManager.Instance.IntializeSfxSoundsAsState(!sfxCheckbox);
    }
    public void OnCanUseMinusClick(bool canUseMinus)
    {
        SaveAndLoad.SaveCanUseMinusValue(canUseMinus);
    }
    public void OnCanUseOperationClick(int val)
    {
        bool status = false;
        if (val == 0)
        {
            status = SaveAndLoad.GetCanUseAddition();
            SaveAndLoad.SaveCanUseAddition(!status);
            canUseAddBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 1)
        {
            status = SaveAndLoad.GetCanUseSubtraction();
            SaveAndLoad.SaveCanUseSubtraction(!status);
            canUseSubBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 2)
        {
            status = SaveAndLoad.GetCanUseMultiplication();
            SaveAndLoad.SaveCanUseMultiplication(!status);
            canUseMulBtn.image.color = !status ? EnableColor : DisableColor;
        }
        else if (val == 3)
        {
            status = SaveAndLoad.GetCanUseDivition();
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
            canUseAddBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 1)
        {
            status = SaveAndLoad.GetCanUseSubtraction();
            canUseSubBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 2)
        {
            status = SaveAndLoad.GetCanUseMultiplication();
            canUseMulBtn.image.color = status ? EnableColor : DisableColor;
        }
        else if (val == 3)
        {
            status = SaveAndLoad.GetCanUseDivition();
            canUseDivBtn.image.color = status ? EnableColor : DisableColor;
        }
    }
}
