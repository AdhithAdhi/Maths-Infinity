using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Platform : MonoBehaviour
{
    public Question question;
    public TextMeshPro QuesText;
    public AnsType answerType;
    int First = 0;
    int Second = 0;
    // Start is called before the first frame update
    void Start()
    {
        //QuesText.transform.LookAt(Camera.main.transform);
    }
    public Question SpwanQuestion()
    {
        answerType = (AnsType)Random.Range(0, 1);


        First = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
        Second = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
        int OpType = Random.Range(0, PlatformManager.Instance.PossibleOperations.Count);
        int ans = 0;
        switch (PlatformManager.Instance.PossibleOperations[OpType])
        {
            case OprationType.Add:
                ans = First + Second;
                QuesText.text = First + "+" + Second;
                break;

            case OprationType.Sub:
                ans = First - Second;
                QuesText.text = First + "-" + Second;
                break;

            case OprationType.Mul:
                ans = First * Second;
                QuesText.text = First + "x" + Second;
                break;

            case OprationType.Div:
                GetRandomNumbersForDivision();
                ans = First / Second;
                QuesText.text = First + "/" + Second;
                break;
        }
        question = new Question(First, Second, PlatformManager.Instance.PossibleOperations[OpType], ans);


        switch (answerType)
        {
            case AnsType.Multi:
                int randvalue = Random.Range(1, 4);
                for (int i = 1; i < transform.childCount; i++)
                {
                    Obstacle ob = Instantiate(PlatformManager.Instance.Obtacle, transform.GetChild(i));
                    ob.Ans.text = GetRandomExclude(ans).ToString();
                    if (i == randvalue)
                    {
                        ob.isAns = true;
                        ob.Ans.text = ans.ToString();
                    }
                }
                break;

            case AnsType.Single:

                Instantiate(PlatformManager.Instance.Obtacle, transform.GetChild(0));
                break;
        }

        return question;
    }

    static int lastGenerated = 999;
    private static int GetRandomExclude(int ans)
    {
        //Random.InitState(Random.Range(0, 100));
        int value= Random.Range(ans - 10, ans + 10);
        if (value == ans || value == lastGenerated)
        {
            value = GetRandomExclude(ans);
        }
        lastGenerated = value;
        return value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlatformManager.Instance.EnableQuestion(this);

        }
    }

    void GetRandomNumbersForDivision()
    {
        int m = 0;
        if (Second == 0)
        {

            First = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
            Second = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
            GetRandomNumbersForDivision();
        }
        if (First > Second)
        {
            m = First % Second;
            if (m == 0)
            {
                return;
            }
            else if ((First - m) >= (SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0))
            {
                First = First - m;
            }
            else if((First+Second-m) < PlatformManager.Instance.maxValue)
            {
                First = First + Second - m;
            }
            else
            {
                First = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
                Second = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
                GetRandomNumbersForDivision();
            }
        }
        else
        {
            First = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
            Second = Random.Range(SaveAndLoad.GetCanUseMinusValue() ? PlatformManager.Instance.minValue : 0, PlatformManager.Instance.maxValue);
            GetRandomNumbersForDivision();
        }
    }
    

}

[System.Serializable]
public class Question
{
    public int First;
    public int Last;
    public OprationType type;
    public int Ans;
    public Question()
    {
    }
    public Question(int f,int l, OprationType op, int ans)
    {
        First = f;
        Last = l;
        type = op;
        Ans = ans;
    }
}
[System.Serializable]
public enum OprationType
{
    Add,
    Sub,
    Mul,
    Div
}
public enum AnsType
{
    Multi,
    Single
}
