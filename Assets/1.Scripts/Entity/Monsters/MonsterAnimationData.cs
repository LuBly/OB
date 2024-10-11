using System;
using UnityEngine;

[Serializable]
public class MonsterAnimationData
{
    [SerializeField] private string HitParameterName = "isHit";
    [SerializeField] private string DieParameterName = "isDie";

    public int HitParameterHash { get; private set; }
    public int DieParameterHash { get; private set; }

    public void Initialize()
    {
        HitParameterHash = Animator.StringToHash(HitParameterName);
        DieParameterHash = Animator.StringToHash(DieParameterName);
    }
}