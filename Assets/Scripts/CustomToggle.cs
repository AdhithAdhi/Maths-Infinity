using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CustomToggle : MonoBehaviour
{
    public Transform ToggleIcon;
    public Transform EnableTick;
    public Transform DisableTick;
    public bool isOn = false;
    //public Color EnableColor;
    //public Color DisableColor;
    public UnityEvent<bool> OnValueChanged;
    Button btn;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        image = GetComponent<Image>();

        btn.onClick.AddListener(OnButtonClick);
        ChangeToggleValue();
    }

    private void OnButtonClick()
    {
        isOn = !isOn;
        ChangeToggleValue();
        OnValueChanged.Invoke(isOn);
    }

    private void ChangeToggleValue()
    {
        Vector3 pos = ToggleIcon.GetComponent<RectTransform>().anchoredPosition;
        if (isOn)
        {
            pos.x = Math.Abs(pos.x);
            //image.color = EnableColor;
            ToggleIcon.SetParent(DisableTick.transform);
        }
        else
        {
            pos.x = -Math.Abs(pos.x);
            //image.color = DisableColor;
            ToggleIcon.SetParent(EnableTick.transform);
        }
        ToggleIcon.GetComponent<RectTransform>().anchoredPosition = pos;
    }



    public void SetIsOn(bool value)
    {
        isOn = value;
        ChangeToggleValue();
    }

}
