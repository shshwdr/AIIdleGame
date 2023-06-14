using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sinbad;
using UnityEngine;

public class BaseInfo
{
    
    public string name;
    public string displayName;
    public string desc;
    public int startUnlocked;
}

public class ResourceInfo:BaseInfo
{
    public int originalMax;
}
public class ProcessInfo:BaseInfo
{
    public Dictionary<string,string>  lockedBy;
    public Dictionary<string,int> unlockCost;
    public Dictionary<string,int>  upgradeCost;

    public Dictionary<string, int> GetUpgradeCost(int level){
        var scaledDict2 = upgradeCostIncrease.ToDictionary(entry => entry.Key, entry => entry.Value *level);

        var merged = upgradeCost.Concat(scaledDict2)
            .GroupBy(i => i.Key)
            .ToDictionary(i => i.Key, i => i.Sum(v => v.Value));
            return merged ;
    }
    public Dictionary<string,int>  upgradeCostIncrease;
    public Dictionary<string,int> result;
    public int isClick; 
    public int startUnlocked;

}
public class DataLoader : Singleton<DataLoader>
{
    public Dictionary<string, ResourceInfo> resourceDict = new Dictionary<string, ResourceInfo>();
    public Dictionary<string, ProcessInfo> processDict = new Dictionary<string, ProcessInfo>();
    // Start is called before the first frame update
    public void Init()
    {
        var resourceInfos = CsvUtil.LoadObjects<ResourceInfo>("resource");
        var processInfos = CsvUtil.LoadObjects<ProcessInfo>("process");
        foreach (var resource in resourceInfos)
        {
            resourceDict[resource.name] = resource;
        }
        foreach (var resource in processInfos)
        {
            processDict[resource.name] = resource;
        }
    }

    public ResourceInfo getResourceInfo(string name)
    {
        if (!resourceDict.ContainsKey(name))
        {
            Debug.LogError("no resource "+name);
        }
        return resourceDict[name];
    }
    public ProcessInfo getProcessInfo(string name)
    {
        if (!processDict.ContainsKey(name))
        {
            Debug.LogError("no process "+name);
        }
        return processDict[name];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
