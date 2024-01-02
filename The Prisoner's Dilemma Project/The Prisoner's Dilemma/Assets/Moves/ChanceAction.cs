using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceAction : Moves   // at any point during the match randomly do RETALIATION
{
    [Range(0f, 100f)] public float _chance;
    public override Action Play(MatchData data)
    {
        float rand = Random.Range(0f, 100f);
        if (rand <= _chance)
        {
            return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>());
        }

        return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>()) == Action.Defect ? Action.Cooperate : Action.Defect;
    }

    public void EditChance(float n)
    {
        _chance = n;
    }

    public override bool CheckMove()
    {
        if (_retaliation == Retaliation.None && _customRetaliation.Count == 0)
        {
            return false;
        }

        return true;
    }

    public override void LoadData(Moves m)
    {
        base.LoadData(m);

        if (m is ChanceAction chanceMove)
        {
            _chance = chanceMove._chance;
        }
    }
}
