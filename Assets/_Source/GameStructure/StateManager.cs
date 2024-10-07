using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateManager
{
    private static List<IStateChanger> _subscribers = new List<IStateChanger>();

    public static void Subscribe(IStateChanger newSub)
    {
        _subscribers.Add(newSub);
    }

    public static void ChangeState(State newState)
    {
        foreach(IStateChanger changer in _subscribers)
        {
            changer.ChangeState(newState);
        }
    }
}
