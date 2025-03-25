using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public UIInventory inventory;
    public int index;
    public ItemData itemData { get; private set; }
    public Image icon;
    public bool isEquip = false;
    public Image imgEquip;

    public void SetItem(ItemData itemData)
    {
        this.itemData = itemData;
        isEquip = false;
    }

    public void RefreshUI()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = itemData.icon;
        imgEquip.gameObject.SetActive(isEquip);
    }

    // 슬롯을 클릭했을 때 발생하는 함수.
    public void OnClickEquip()
    {
        // 인벤토리의 SelectItem 호출, 현재 슬롯의 인덱스만 전달.
        inventory.SelectEquip(index);
    }
}
