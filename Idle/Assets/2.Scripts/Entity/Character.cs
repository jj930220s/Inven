using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
    public string name { get; private set; }
    public int lv { get; private set; }
    public int expMax { get; private set; }
    public int exp { get; private set; }
    public int money { get; private set; }
    public int attack { get; private set; }
    public int armor { get; private set; }
    public int hp { get; private set; }
    public int critical { get; private set; }
    public List<ItemData> inventory;

    public Character(string name, int lv, int expMax, int exp, int money, int attack, int armor, int hp, int critical)
    {
        this.name = name;
        this.lv = lv;
        this.expMax = expMax;
        this.exp = exp;
        this.money = money;
        this.attack = attack;
        this.armor = armor;
        this.hp = hp;
        this.critical = critical;
        inventory = new List<ItemData>();
    }

    public void Additem(ItemData itemData)
    {
        inventory.Add(itemData);
        UIManager.Instance.uiInventory.AddItem(itemData);
    }

    public void Equip(ItemData itemData)
    {
        attack += itemData.attack;
        armor += itemData.armor;
        hp += itemData.hp;
        critical += itemData.critical;
        UIManager.Instance.uiStatus.RefreshUI();
    }
    public void UnEquip(ItemData itemData)
    {
        attack -= itemData.attack;
        armor -= itemData.armor;
        hp -= itemData.hp;
        critical -= itemData.critical;
        UIManager.Instance.uiStatus.RefreshUI();
    }
}
