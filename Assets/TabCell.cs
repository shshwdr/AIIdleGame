using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabCell : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            openMenu();
        });
    }

    public void openMenu()
    {
        foreach (var others in transform.parent. GetComponentsInChildren<TabCell>())
        {
            others.closeMenu();
        }

        
        menu.SetActive(true);
        
        
    }

    public void closeMenu()
    {
        
        menu.SetActive(false);
    }
}
