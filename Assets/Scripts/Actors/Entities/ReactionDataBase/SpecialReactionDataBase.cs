using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SpecialReactionDataBase : ReactionDataBase, IReactionDataBase
{
    private Dictionary<Type, Action> _reactionOfEntity = new Dictionary<Type, Action>();

    public void AddReaction<T>(IReaction reaction) where T : Entity
    {
        Type entity = typeof(T);
       
        if (_reactionOfEntity.ContainsKey(entity) == false)
            _reactionOfEntity.Add(entity, new Action(() => reaction.React()));

        _reactionOfEntity[entity] += reaction.React;
    }

    public virtual void InvokeReaction(Entity entity)
    {
        Type typeEntity = entity.GetType();

        if (_reactionOfEntity.ContainsKey(typeEntity))
        {
            _reactionOfEntity[typeEntity]?.Invoke();
            return;
        }

       // Debug.Log("Ошибка, на " + typeEntity + " нету реакции у");
    } 
    
    public virtual void InvokeReaction<T>() where T : Entity
    {
        Type entity = typeof(T);

        if (_reactionOfEntity.ContainsKey(entity))
        {
            _reactionOfEntity[entity]?.Invoke();
            return;
        }

       // Debug.Log("Ошибка, на " + entity + " нету реакции у");
    }
}
