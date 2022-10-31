using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singletone { get; private set; }

    [SerializeField] private CameraManager _camera;
    [SerializeField] private MeshGenerator _meshGenerator;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private MonetGenerator _monetGenerator;
    [SerializeField] private PlayerControler _player;

    [SerializeField] int _seconds = 0;
    int cuurentSeconds = 0;
    int monet = 0;
    int cuurentMonet = 0;
    private void Awake()
    {
        singletone = this;
    }
    private void Start()
    {
        SettingSettings();
        cuurentSeconds = _seconds;
        StartCoroutine("Timer");
    }

    private void SettingSettings()
    {
        _meshGenerator.StartGaneration();
        monet = _camera.Calculations(_meshGenerator.GetSizeX, _meshGenerator.GetSizeZ);
        monet = _monetGenerator.InstatiateMonets(monet, _meshGenerator.GetSizeX, _meshGenerator.GetSizeZ);
        MonetChange(monet);
        _player.StartPosition(_meshGenerator.GetSizeX, _meshGenerator.GetSizeZ);
    }
    public void MonetChange(int Num)
    {
        cuurentMonet += Num;
        _UIManager.GetMonets(monet, cuurentMonet);
        if (cuurentMonet <= 0)
        {
            Win();
        }
    }
    IEnumerator Timer()
    {
        while (true)
        {
            _UIManager.GetTime(_seconds, cuurentSeconds);
            yield return new WaitForSeconds(1f);
            cuurentSeconds--;
            if (cuurentSeconds <= 0)
            {
                Lose();
            }
        }
    }


    private void Lose()
    {
        _player.ChangeSpeed = 0;
        StopAllCoroutines();
        _UIManager.Lose();
    }

    private void Win()
    {
        _player.ChangeSpeed = 0;
        StopAllCoroutines();
        _UIManager.Win();
    }
}
