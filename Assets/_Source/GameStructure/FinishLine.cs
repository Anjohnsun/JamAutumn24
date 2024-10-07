using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameplayUI _ui;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StateManager.ChangeState(State.closingAnimation);
            StartCoroutine(DelayedSwtichToMenu());
            Debug.Log("finish");
        }
    }


    private IEnumerator DelayedSwtichToMenu()
    {
        yield return new WaitForSeconds(3);

        _ui._setWinPanelVisible(true);
    }
}
