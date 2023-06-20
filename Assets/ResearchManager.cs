using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResearchData
{
    public int level = -1;
    public bool isUnlocked => level>=0;
    public bool isAtMaxLevel => level >= 10;
}
public class ResearchManager : Singleton<ResearchManager>
{
    public Dictionary<string, ResearchData> ResearchDatas;

    public ResearchInfo clickResearch;

    public void levelUp(string name)
    {
        getProcesData(name).level += 1;
    }
    public ResearchData getProcesData(string name)
    {
        
        if (ResearchDatas.ContainsKey(name))
        {
            return ResearchDatas[name];
        }
        Debug.LogError("no research data "+name);
        return null;
    }
    // Start is called before the first frame update
    public void Init()
    {
        ResearchDatas = new Dictionary<string, ResearchData>();
        foreach (var resourcePair in DataLoader.Instance.researchDict)
        {
            var data = new ResearchData();
            ResearchDatas[resourcePair.Key] = data;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
