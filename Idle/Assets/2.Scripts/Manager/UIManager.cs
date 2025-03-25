using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public UIMainMenu uiMainMenu;
    [SerializeField] public UIStatus uiStatus;
    [SerializeField] public UIInventory uiInventory;

    public void OpenMainMenu()
    {
        uiMainMenu.goButtons.SetActive(true);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }


    public void OpenStatus()
    {
        uiMainMenu.goButtons.SetActive(false);
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        uiMainMenu.goButtons.SetActive(false);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);
    }

}
