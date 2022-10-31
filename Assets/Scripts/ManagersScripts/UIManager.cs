using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _monetCount;
    [SerializeField] private Text _timeLeft;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject GameMenu;
    [SerializeField] private Image ProgressBar;
    [SerializeField] private Image TimeBar;
    int progressBarCount = 0;
    int timeBarCount = 1;
    public void GetMonets(float AllMonets, float MonetsLeft)
    {
         _monetCount.text = "Monet left: " + MonetsLeft;
        ProgressBar.fillAmount = (AllMonets - MonetsLeft)/ AllMonets;
    }

    public void GetTime(float AllTime, float TimeLeft)
    {
        _timeLeft.text = "Seconds : " + TimeLeft;
        TimeBar.fillAmount = TimeLeft/AllTime ;
        
    }

    public void Win()
    {
        GameMenu.SetActive(false);
        WinMenu.SetActive(true);
    }

    public void Lose()
    {
        GameMenu.SetActive(false);
        LoseMenu.SetActive(true);
    }
}