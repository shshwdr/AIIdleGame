using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProcessData
{
    public int level = -1;
    public bool isUnlocked => level>=0;
}
public class ProcessManager : Singleton<ProcessManager>
{
    public Dictionary<string, ProcessData> ProcessDatas;

    public ProcessInfo clickProcess;
    // Start is called before the first frame update
    public void Init()
    {
        ProcessDatas = new Dictionary<string, ProcessData>();
        foreach (var resourcePair in DataLoader.Instance.processDict)
        {
            if (resourcePair.Value.isClick == 1)
            {
                clickProcess = resourcePair.Value;
            }
            var data = new ProcessData();
            ProcessDatas[resourcePair.Key] = data;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
