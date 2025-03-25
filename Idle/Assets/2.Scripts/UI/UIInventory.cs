using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public const int unEquip = -1;

    public UISlot prefabSlot;

    public Transform slotPanel;
    public List<UISlot> uiSlotList;
    public TextMeshProUGUI txtSlot;

    public Button btnBack;
    public int equipIndex = -1;

    public void Awake()
    {
        InitInventoryUI();
        RefreshUI();
        gameObject.SetActive(false);
    }

    public void Start()
    {
        btnBack.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }

    public void InitInventoryUI()
    {
        for (int i = 0; i < 120; i++)
        {
            var slot = Instantiate(prefabSlot, slotPanel);
            slot.inventory = this;
            slot.index = i;
            uiSlotList.Add(slot);
        }
    }

    public void AddItem(ItemData itemData)
    {
        UISlot emptySlot = GetEmptySlot();

        // 빈 슬롯이 있다면
        if (emptySlot != null)
        {
            emptySlot.SetItem(itemData);
            RefreshUI();
            return;
        }
    }

    public void RefreshUI()
    {
        int hasSlot = 0;
        for (int i = 0; i < uiSlotList.Count; i++)
        {
            // 슬롯에 아이템 정보가 있다면
            if (uiSlotList[i].itemData != null)
            {
                hasSlot++;
                uiSlotList[i].RefreshUI();
            }
        }

        txtSlot.text = $"<color=\"orange\">{hasSlot}</color> <color=#aaaaaa>/ {uiSlotList.Count}</color>";
    }

    // 슬롯의 item 정보가 비어있는 정보 return
    UISlot GetEmptySlot()
    {
        for (int i = 0; i < uiSlotList.Count; i++)
        {
            if (uiSlotList[i].itemData == null)
            {
                return uiSlotList[i];
            }
        }
        return null;
    }

    public void SelectEquip(int index)
    {
        // 아이템이 아무것도 없다면 아무짓도 하지 않음
        if (uiSlotList[index].itemData == null)
        {
            return;
        }

        // 같은 아이템을 클릭했다면 장착 해제
        if (equipIndex == index)
        {
            UnEquip(index);
            equipIndex = unEquip;
            return;
        }

        // 장착된 것이 없다면
        if (equipIndex == unEquip)
        {
            Equip(index);
            equipIndex = index;
        }
        else // 장착된 것이 있다면
        {
            // 먼저 장착된 것 해제 후 장창
            UnEquip(equipIndex);
            Equip(index);
            equipIndex = index;
        }
    }

    public void Equip(int index)
    {
        if (uiSlotList[index].itemData != null)
        {
            GameManager.Instance.player.Equip(uiSlotList[index].itemData);
            uiSlotList[index].isEquip = true;
            uiSlotList[index].RefreshUI();
        }
    }
    public void UnEquip(int index)
    {
        if (uiSlotList[index].itemData != null)
        {
            GameManager.Instance.player.UnEquip(uiSlotList[index].itemData);
            uiSlotList[index].isEquip = false;
            uiSlotList[index].RefreshUI();
        }
    }
}
