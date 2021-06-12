using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public TextMeshPro Ans;
    public bool isAns = false;

    private void OnTriggerEnter(Collider other)
    {

        if (!isAns && other.tag.Equals("Player"))
        {
            GameManager.Instance.GameOver(transform.parent.parent.GetComponent<Platform>());
        }
        else
        {
            GetComponent<MeshRenderer>().material = PlatformManager.Instance.passMaterial;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isAns && other.tag.Equals("Player"))
        {
            PlatformManager.Instance.DisableQuestion(transform.parent.parent);
        }
    }
}