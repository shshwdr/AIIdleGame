using System;
using System.Collections;
using System.Collections.Generic;
using Pool;
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

    public ResourceData getResourceData(string name)
    {
        if (resourceDatas.ContainsKey(name))
        {
            return resourceDatas[name];
        }
        Debug.LogError("no resource data "+name);
        return null;
    }

    public bool hasResource(Dictionary<string, int> result)
    {
       
        foreach (var pair in result)
        {
            if (resourceDatas.ContainsKey(pair.Key))
            {
                if (resourceDatas[pair.Key].currentAmount < pair.Value)
                {
                    return false;
                }
            }
            else
            {
                Debug.LogError("no resource to add "+pair.Key);
            }
        }

        return true;
    }
    
    public void ConsumeResource(Dictionary<string, int> result)
    {
        foreach (var pair in result)
        {
            if (resourceDatas.ContainsKey(pair.Key))
            {
                if (resourceDatas[pair.Key].currentAmount < pair.Value)
                {
                    Debug.LogError("how");
                }
                resourceDatas[pair.Key].currentAmount -= pair.Value;
                updateResource();
            }
            else
            {
                Debug.LogError("no resource to add "+pair.Key);
            }
        }
    }
    public void AddRate(Dictionary<string, int> result)
    {
        foreach (var pair in result)
        {
            if (resourceDatas.ContainsKey(pair.Key))
            {
                resourceDatas[pair.Key].ratePerSecond += pair.Value;
            }
            else
            {
                Debug.LogError("no resource to add "+pair.Key);
            }
        }
    }
    public void addResource(Dictionary<string, int> result)
    {
        foreach (var pair in result)
        {
            if (resourceDatas.ContainsKey(pair.Key))
            {
                resourceDatas[pair.Key].currentAmount += pair.Value;
                resourceDatas[pair.Key].currentAmount = Math.Min(resourceDatas[pair.Key].currentAmount,
                    resourceDatas[pair.Key].currentMax);
                updateResource();
            }
            else
            {
                Debug.LogError("no resource to add "+pair.Key);
            }
        }
    }

    void updateResource()
    {
        EventPool.Trigger("updateResource");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float currentTime;

    private float harvestTime = 1;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= harvestTime)
        {
            currentTime -= harvestTime;
            foreach (var pair in resourceDatas)
            {
                if (pair.Value.ratePerSecond > 0)
                {
                    pair.Value.currentAmount += pair.Value.ratePerSecond;
                    
                    resourceDatas[pair.Key].currentAmount = Math.Min(resourceDatas[pair.Key].currentAmount,
                        resourceDatas[pair.Key].currentMax);
                    updateResource();
                }
            }
        }
    }
}
