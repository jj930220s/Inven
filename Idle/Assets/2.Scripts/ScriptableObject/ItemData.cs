using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public Sprite icon;
    public string displayName;

    [Header("Plus Status")]
    public int attack;
    public int armor;
    public int hp;
    public int critical;
}