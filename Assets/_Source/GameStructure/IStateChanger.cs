using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public interface IStateChanger
{
    public void ChangeState(State newState);
}
