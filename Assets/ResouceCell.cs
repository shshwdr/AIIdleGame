using System.Collections;
using System.Collections.Generic;
using Pool;
using TMPro;
using UnityEngine;

public class ResouceCell : MonoBehaviour
{
    public TMP_Text nameLabel;
    public TMP_Text amountLabel;
    public TMP_Text rateLabel;

    private string name;
    public void updateLabels()
    {
        var data = ResourceManager.Instance.getResourceData(name);
        amountLabel.text = data.currentAmount +" / "+data.currentMax;
        rateLabel.text = data.ratePerSecond + " / s";
    }

    public void initLabels(string n)
    {
        name = n;
        nameLabel.text = DataLoader.Instance.getResourceInfo(name).displayName;
        updateLabels();
        
        EventPool.OptIn("updateResource",updateLabels);
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
