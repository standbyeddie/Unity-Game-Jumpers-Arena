﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpeedUpItem : Item {

    public float speedRatio;

    public SpeedUpItem(Player p1) {
        this.player = p1;
        // 1 second = 50 timestemps
        delay = 250;
        speedRatio = 1.5f;
    }

    public override void finish() {
        player.speedRatio = 1;
    }

    public override void use(Player currentPlayer, List<Player> targetPlayers) {
        //SpeedDownItem.print("Speed Down Use");
        player.isAccelerated = true;
        player.isDecelerated = false;
        finishTime = player.time + delay;
        player.speedRatio = speedRatio;
        player.timeDic["speed"] = this;
        //StartCoroutine(waitAndPrint(4f, player));
    }

    IEnumerator waitAndPrint(float waitTime, Player player) {
        yield return new WaitForSeconds(waitTime);
        player.speedRatio = 1;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}