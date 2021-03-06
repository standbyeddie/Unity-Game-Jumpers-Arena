﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Powerup : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    //public abstract Item getItemObject(Player player);
    public abstract string getItemObject();

    void OnTriggerEnter2D(Collider2D e) {
        if (e.gameObject.tag.CompareTo("Player") == 0) {
            Powerup.print("meet powerup");
            Player player = e.gameObject.GetComponent<Player>();
            Powerup.print(player.alias);
            Powerup.print("Slots : " + player.slots);
            Powerup.print(player.isLocalPlayer + " " + player.items.Count);
            if (player.isLocalPlayer && player.items.Count < player.slots) {
                //Item item = getItemObject(player);
                string item = getItemObject();
                int itemIndex = player.items.Count;
                player.items.Add(item);
                //item.use(null, null);
                GameObject buttonSlot = GameObject.Find("ButtonSlot");
                Button btn = buttonSlot.GetComponent<Button>();
                SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
                Powerup.print(spriteRenderer.sprite.name);
                btn.GetComponent<Image>().sprite = spriteRenderer.sprite;
                BaseButton baseBtn = btn.GetComponent<BaseButton>();
                baseBtn.setParam(player, itemIndex, item);
                Destroy(gameObject);
            }


        }
    }
}
