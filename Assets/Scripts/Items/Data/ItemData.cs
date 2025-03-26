using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Head,
    Hand,
    BodyTop,
    BodyBottom,
    Leg,
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    public ItemType type;
    public string objectName;
    public string description;

    public int attack;
    public float attackSpeed;
    public float moveSpeed;
    public float maxHP;

    public Sprite icon;
}
