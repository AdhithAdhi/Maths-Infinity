using System;
using System.Collections.Generic;

using UnityEngine;

public static class SaveAndLoad
{
    public static void SaveLevel(int level)
    {

        PlayerPrefs.SetInt("lvl", level);
    }
    public static int GetLevel()
    {

        return PlayerPrefs.GetInt("lvl", 1);
    }
    public static void SaveCanUseMinusValue(bool value)
    {

        PlayerPrefs.SetInt("Can_Minus", (value ? 1 : 0));
    }
    public static bool GetCanUseMinusValue()
    {

        return (PlayerPrefs.GetInt("Can_Minus", 0) == 1 ? true : false);
    }
    public static void SaveCanUseAddition(bool value)
    {

        PlayerPrefs.SetInt("Can_Add", (value ? 1 : 0));
    }
    public static bool GetCanUseAddition()
    {

        return (PlayerPrefs.GetInt("Can_Add", 1) == 1 ? true : false);
    }
    public static void SaveCanUseSubtraction(bool value)
    {

        PlayerPrefs.SetInt("Can_Sub", (value ? 1 : 0));
    }
    public static bool GetCanUseSubtraction()
    {

        return (PlayerPrefs.GetInt("Can_Sub", 1) == 1 ? true : false);
    }
    public static void SaveCanUseMultiplication(bool value)
    {

        PlayerPrefs.SetInt("Can_Multi", (value ? 1 : 0));
    }
    public static bool GetCanUseMultiplication()
    {

        return (PlayerPrefs.GetInt("Can_Multi", 1) == 1 ? true : false);
    }
    public static void SaveCanUseDivition(bool value)
    {

        PlayerPrefs.SetInt("Can_Div", (value ? 1 : 0));
    }
    public static bool GetCanUseDivition()
    {

        return (PlayerPrefs.GetInt("Can_Div", 0) == 1 ? true : false);
    }

    public static void SetBgmState(bool value)
    {
        PlayerPrefs.SetInt("bgmSound", (value ? 1 : 0));
    }
    public static void SetSfxState(bool value)
    {
        PlayerPrefs.SetInt("sfxSound", (value ? 1 : 0));
    }
    public static bool bgmState()
    {
        return (PlayerPrefs.GetInt("bgmSound", 1) == 1 ? true : false);
    }
    public static bool sfxState()
    {
        return (PlayerPrefs.GetInt("sfxSound", 1) == 1 ? true : false);
    }
}
