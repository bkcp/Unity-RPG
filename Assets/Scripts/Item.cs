﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor; 
    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite; 
[Header("Item Effects")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr, affectDef;
    public int weaponStr, armorStr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
