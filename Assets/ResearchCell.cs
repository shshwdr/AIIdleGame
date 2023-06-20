using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pool;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ResearchCell : MonoBehaviour
{
    public Button processButton;
    public Button extraButton;
    private string name;
    private ResearchInfo info;
    private ResearchData data;
    private bool isClickingButton = false;
    private ResearchMenu menu;
    public void init(string n,ResearchMenu m)
    {
        name = n;
        menu = m;
        info = DataLoader.Instance.getResearchInfo(name);
        data = ResearchManager.Instance.getProcesData(name);
        processButton.GetComponentInChildren<TMP_Text>().text = info.displayName;
        
        EventTrigger eventTrigger = processButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;

        // Define what actions to take when event is triggered
        pointerEnterEntry.callback.AddListener((eventData) => {
            menu.explainOb.SetActive(true);
            updateDetailText();
           // Debug.Log(info.desc);
        });

        eventTrigger.triggers.Add(pointerEnterEntry);
        
        // Entry for PointerExit event
        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;

        pointerExitEntry.callback.AddListener((eventData) => {
            menu.explainOb.SetActive(false);
        });

        eventTrigger.triggers.Add(pointerExitEntry);
        
        // processButton.onClick.AddListener(() =>
        // {
        //     if (info.isClick == 1)
        //     {
        //         //click to get resource
        //         ResourceManager.Instance.addResource(info.result);
        //     }
        //     else
        //     {
        //         if (data.isUnlocked)
        //         {
        //             
        //             ResourceManager.Instance.ConsumeResource(info.GetUpgradeCost(data.level));
        //         }
        //         else
        //         {
        //             
        //             ResourceManager.Instance.ConsumeResource(info.unlockCost);
        //         }
        //         
        //         ResearchManager.Instance.levelUp(name);
        //         ResourceManager.Instance.AddRate(info.result);
        //         updateLevels();
        //         
        //     }
        // });
        
        EventPool.OptIn("updateResource",updateResources);
        updateResources();
        updateLevels();
    }

    void updateDetailText()
    {
        
        var desc = info.desc;
        // if (info.isClick == 1)
        // {
        //         
        //     // desc += "\nClick to farm.";
        //     var dictAsString = string.Join(", ", info.result.Select(kv =>  kv.Value.ToString()+" "+kv.Key).ToArray());
        //
        //     desc += "\nEach Click benefit: " +  dictAsString;
        // }else if (data.isUnlocked)
        // {
        //     string dictAsString = string.Join(", ", info.GetUpgradeCost(data.level).Select(kv =>  kv.Value.ToString()+" "+kv.Key).ToArray());
        //
        //     desc += "\nUpgrade cost: " +  dictAsString;
        //         
        //     dictAsString = string.Join(", ", info.result.Select(kv =>  kv.Value.ToString()+" "+kv.Key).ToArray());
        //
        //     desc += "\nEach level benefit: " +  dictAsString;
        // }
        // else
        // {
        //     string dictAsString = string.Join(", ", info.unlockCost.Select(kv =>  kv.Value.ToString()+" "+kv.Key).ToArray());
        //
        //     desc += "\nUnlock cost: " + dictAsString;
        // }
        menu.explainOb.GetComponentInChildren<TMP_Text>().text = desc;
    }

    bool isClickable()
    {
        // if (info.isClick == 1)
        // {
        //     return true;
        // }
        //
        //
        //
        // //var data = ResearchManager.Instance.getProcesData(name);
        //
        // if (data.isAtMaxLevel)
        // {
        //     return false;
        // }
        //
        // if (data.isUnlocked)
        // {
        //     if (ResourceManager.Instance.hasResource(info.GetUpgradeCost(data.level)))
        //     {
        //         return true;
        //     }
        // }
        // else
        // {
        //     if (ResourceManager.Instance.hasResource(info.unlockCost))
        //     {
        //         return true;
        //     }
        // }

        return false;

    }
    
    public void updateResources()
    {
        processButton.interactable = isClickable();
    }
    public void updateLevels()
    {
        updateResources();
        extraButton.GetComponentInChildren<TMP_Text>().text = (data.level+1).ToString();
        updateDetailText();
    }
}
