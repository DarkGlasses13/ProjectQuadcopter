using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public interface IReactionDataBase
{
    public void InvokeReaction(Entity entity);
    public void InvokeReaction<T>() where T : Entity;
}
