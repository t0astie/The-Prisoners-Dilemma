using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChance : Moves
{
    [Range(0f, 100f)] public float _chance;
    public Retaliation _retaliation;
    public override Action Play(GameData data)
    {
        float rand = Random.Range(0f, 100f);
        if (rand <= _chance)
        {
            return GetAction(data, _retaliation);
        }

        return Action.None;
    }
}
