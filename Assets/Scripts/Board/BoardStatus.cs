using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardStatus{
    public Dictionary<NormalItem.eNormalType, int> itemTypeCounts = new Dictionary<NormalItem.eNormalType,int>(){
        {NormalItem.eNormalType.TYPE_ONE, 0},
        {NormalItem.eNormalType.TYPE_TWO, 0},
        {NormalItem.eNormalType.TYPE_THREE, 0},
        {NormalItem.eNormalType.TYPE_FOUR, 0},
        {NormalItem.eNormalType.TYPE_FIVE, 0},
        {NormalItem.eNormalType.TYPE_SIX, 0},
        {NormalItem.eNormalType.TYPE_SEVEN, 0}
    };

    // public List<NormalItem.eNormalType> Get4LowestCounts(NormalItem.eNormalType current){
    //     List<NormalItem.eNormalType> lowestFourEnums = itemTypeCounts
    //         .Where(pair => pair.Key != current)
    //         .OrderBy(pair => pair.Value)  
    //         .Take(4)                      
    //         .Select(pair => pair.Key)      
    //         .ToList();

    //     return lowestFourEnums;
    // }

    public NormalItem.eNormalType GetDiffFromSurrounding (List<NormalItem.eNormalType> surroundCells){
        NormalItem.eNormalType lowestCountSideBarSurround = itemTypeCounts
            .Where(pair => !surroundCells.Contains(pair.Key))
            .OrderBy(pair => pair.Value)  
            .FirstOrDefault().Key; 

        return lowestCountSideBarSurround;
    }

    public void UpdateTypeCount(NormalItem.eNormalType type, int modAmt){
        itemTypeCounts[type] += modAmt;
        // string str = "";
        // int total = 0;
        // foreach(var kvp in itemTypeCounts){
        //     str += kvp.Key.ToString() + " " + kvp.Value.ToString() + "\n";
        //     total += kvp.Value;
        // }
        // str += "\n" + "total: " + total.ToString();
        // Debug.Log(str);
    }

    public void Clear(){
        itemTypeCounts = new Dictionary<NormalItem.eNormalType,int>(){
            {NormalItem.eNormalType.TYPE_ONE, 0},
            {NormalItem.eNormalType.TYPE_TWO, 0},
            {NormalItem.eNormalType.TYPE_THREE, 0},
            {NormalItem.eNormalType.TYPE_FOUR, 0},
            {NormalItem.eNormalType.TYPE_FIVE, 0},
            {NormalItem.eNormalType.TYPE_SIX, 0},
            {NormalItem.eNormalType.TYPE_SEVEN, 0}
        };
    }
}