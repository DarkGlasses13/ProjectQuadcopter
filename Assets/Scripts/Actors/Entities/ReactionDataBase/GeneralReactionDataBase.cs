using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class GeneralReactionDataBase : SpecialReactionDataBase
{
    private Action GeneralReact;
 
    public void AddGeneralReaction(IReaction reaction)
    {
        GeneralReact += () => reaction.React();
    }
 
    private void InvokeGeneralReaction()
    {
        GeneralReact?.Invoke();
    }
 
    public override void InvokeReaction(Entity entity)
    {
        InvokeGeneralReaction();
        base.InvokeReaction(entity);
    }

    public override void InvokeReaction<T>()
    {
        InvokeGeneralReaction();
        base.InvokeReaction<T>();
    }
    
}
