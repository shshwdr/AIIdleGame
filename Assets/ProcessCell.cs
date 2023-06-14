using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ProcessCell : MonoBehaviour
{
    public Button processButton;
    public Button explainButton;
    private string name;
    private ProcessInfo info;
    private bool isClickingButton = false;
    private ProcessMenu menu;
    public void init(string n,ProcessMenu m)
    {
        name = n;
        menu = m;
        info = DataLoader.Instance.getProcessInfo(name);
        processButton.GetComponentInChildren<TMP_Text>().text = info.displayName;
        
        EventTrigger eventTrigger = processButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;

        // Define what actions to take when event is triggered
        pointerEnterEntry.callback.AddListener((eventData) => {
            menu.explainOb.SetActive(true);
            menu.explainOb.GetComponentInChildren<TMP_Text>().text = info.desc;
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
        
        processButton.onClick.AddListener(() =>
        {
            if (info.isClick == 1)
            {
                //click to get resource
                ResourceManager.Instance.addResource(info.result);
            }
            else
            {
                
            }
        });
    }
    public void update()
    {
        
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
