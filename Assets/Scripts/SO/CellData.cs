using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "CellData_n", menuName = "CellData", order = 0)]
public class CellData : ScriptableObject {
    public Dictionary<NormalItem.eNormalType, Sprite> dictionary = new Dictionary<NormalItem.eNormalType,Sprite>();

    private void OnEnable() {
        dictionary = new Dictionary<NormalItem.eNormalType,Sprite>(){
            {NormalItem.eNormalType.TYPE_ONE, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_ONE)},
            {NormalItem.eNormalType.TYPE_TWO, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_TWO)},
            {NormalItem.eNormalType.TYPE_THREE, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_THREE)},
            {NormalItem.eNormalType.TYPE_FOUR, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_FOUR)},
            {NormalItem.eNormalType.TYPE_FIVE, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_FIVE)},
            {NormalItem.eNormalType.TYPE_SIX, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_SIX)},
            {NormalItem.eNormalType.TYPE_SEVEN, Resources.Load<Sprite>(Constants.SPRITE_FISH_TYPE_SEVEN)},
        };
    }
}
