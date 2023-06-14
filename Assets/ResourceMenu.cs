using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMenu : MonoBehaviour
{
    public Transform parent;
    public GameObject cellPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var pair in ResourceManager.Instance.resourceDatas)
        {
            var go = Instantiate(cellPrefab,parent);
            go.GetComponent<ResouceCell>().initLabels(pair.Key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
