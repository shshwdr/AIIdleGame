using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProcessMenu : MonoBehaviour
{
    public Transform parent;
    public GameObject cellPrefab;

    public GameObject explainOb;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var pair in ProcessManager.Instance.ProcessDatas)
        {
            var go = Instantiate(cellPrefab,parent);
            go.GetComponent<ProcessCell>().init(pair.Key, this);
        }
    }
}
