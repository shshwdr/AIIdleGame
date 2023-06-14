using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData
{
    public int ratePerSecond;
    public int currentAmount;
    public int currentMax;
}
public class ResourceManager : Singleton<ResourceManager>
{
    public Dictionary<string, ResourceData> resourceDatas;
    public void Init()
    {
        resourceDatas = new Dictionary<string, ResourceData>();
        foreach (var resourcePair in DataLoader.Instance.resourceDict)
        {
            var data = new ResourceData();
            data.currentMax = resourcePair.Value.originalMax;
            resourceDatas[resourcePair.Key] = data;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
