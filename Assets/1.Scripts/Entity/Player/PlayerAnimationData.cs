using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string attackParameterName = "isAttack";


    public int AttackParameterName { get; private set; }

    public void Initialize()
    {
        AttackParameterName = Animator.StringToHash(attackParameterName);
    }
}