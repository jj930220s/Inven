using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Character player;
    public List<ItemData> itemDataList;

    new void Awake()
    {
        SetData("Player", 10, 12, 9, 20000, 35, 40, 100, 25);
    }

    public void SetData(string name, int lv, int expMax, int exp, int money, int attack, int armor, int hp, int critical)
    {
        player = new(name, lv, expMax, exp, money, attack, armor, hp, critical); // 35, 40, 100, 25

        for (int i = 0; i < itemDataList.Count; i++)
        {
            player.Additem(itemDataList[i]);
        }
    }
}
