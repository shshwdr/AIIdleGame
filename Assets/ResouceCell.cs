using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResouceCell : MonoBehaviour
{
    public TMP_Text nameLabel;
    public TMP_Text amountLabel;
    public TMP_Text rateLabel;

    
    public void updateLabels(string name,ResourceData data)
    {
        nameLabel.text = DataLoader.Instance.getResourceInfo(name).displayName;
        amountLabel.text = data.currentAmount +" / "+data.currentMax;
        rateLabel.text = data.ratePerSecond + " / s";
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
