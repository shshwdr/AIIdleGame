using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataLoader.Instance.Init();
        ResourceManager.Instance.Init();
        ProcessManager.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
