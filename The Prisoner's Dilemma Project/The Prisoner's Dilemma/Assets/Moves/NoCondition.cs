using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCondition : Moves    // do RETALIATION
{
    public Retaliation _retaliation;
    public override Action Play(MatchData data)
    {
        return GetAction(data, _retaliation);
    }
}
