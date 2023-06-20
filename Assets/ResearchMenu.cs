using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMenu : MonoBehaviour
{
    public Transform parent;
    public GameObject cellPrefab;

    public GameObject explainOb;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var pair in ResearchManager.Instance.ResearchDatas)
        {
            var go = Instantiate(cellPrefab,parent);
            go.GetComponent<ResearchCell>().init(pair.Key, this);
        }
    }
}
