using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    public event Action<Entity> OnDetect;
    private IReactionDataBase _reaction;
    
    public void SetParametrs(ReactionDataBase reactionDataBase)
    {
        if (_reaction != null)
            OnDetect -= _reaction.InvokeReaction;
        
        _reaction = reactionDataBase as IReactionDataBase;
        OnDetect += _reaction.InvokeReaction;
    }

    protected void InvokeDetector(Entity entity)
    {
        OnDetect?.Invoke(entity);
    }
    
    
}
