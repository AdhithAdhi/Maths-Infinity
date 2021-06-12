using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Platform platform;
    public GameObject Emptyplatform;
    public GameObject Finalplatform;
    public float speed;
    public Obstacle Obtacle;
    public Material passMaterial;

    public int minValue =0;
    public int maxValue = 10;
    public List<Question> Questions = new List<Question>();
    public int minPlatforms = 5;
    public int maxPlatforms=5;
    public int spacing = 20;

    public Platform currentPlatform;
    public List<OprationType> PossibleOperations = new List<OprationType>();
    public static PlatformManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance= this;
    }


    public void SetUpPlatforms()
    {
        Vector3 pos = new Vector3(0, 0, -spacing);
        pos.z += spacing;
        Instantiate(Emptyplatform, pos, Quaternion.identity, transform);
        for (int i = 0; i < minPlatforms; i++)
        {
            pos.z += spacing;
            Platform plat = Instantiate(platform, transform).GetComponent<Platform>();

            plat.transform.position = pos;
            // pos.z += spacing;
            // Instantiate(Emptyplatform, pos, Quaternion.identity, transform);

            //Debug.LogError(pos);
            Questions.Add(plat.SpwanQuestion());
        }
        pos.z += spacing;
        Instantiate(Finalplatform, pos, Quaternion.identity, transform);
    }
    public void AddPlatformCount(int val)
    {
        minPlatforms += val;
        if (minPlatforms > maxPlatforms)
        {
            minPlatforms = maxPlatforms;
        }
    }
    public void EnableQuestion(Platform trans)
    {
        currentPlatform = trans;
        for (int i = 0; i < trans.transform.childCount; i++)
        {
            trans.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void DisableQuestion(Transform trans)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            trans.GetChild(i).gameObject.SetActive(false);
        }

    }
}
