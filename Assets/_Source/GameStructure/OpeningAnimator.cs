using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningAnimator : MonoBehaviour
{
    IEnumerator Start()
    {
        StateManager.ChangeState(State.openingAnimation);
        //animation operations

        yield return new WaitForSeconds(2);




        StateManager.ChangeState(State.gameplay);
    }

}
