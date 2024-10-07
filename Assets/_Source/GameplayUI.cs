using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadGameplay()
    {
        SceneManager.LoadScene(1);
    }

    public void _setLosePanelVisible(bool v)
    {
        _losePanel.SetActive(v);
    }
    public void _setWinPanelVisible(bool v)
    {
        _winPanel.SetActive(v);
    }
}
