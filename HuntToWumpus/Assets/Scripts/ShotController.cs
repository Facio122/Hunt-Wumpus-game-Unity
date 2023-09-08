using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShotController : MonoBehaviour
{
    private int Ammunation = 6;
    [SerializeField] TextMeshProUGUI TextAmmunationCount;
    public AudioSource AudioShot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerShot();
        _funTextController();
    }

    private void PlayerShot()
    {
        Debug.Log("Ammunation left : " + Ammunation);
        if (_hasAmmunation())
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                _funPlayerShot(Constants.currentPlayerX, Constants.currentWumpusX, Constants.currentWumpusY, Constants.currentPlayerY);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                _funPlayerShot(Constants.currentWumpusX, Constants.currentPlayerX, Constants.currentWumpusY, Constants.currentPlayerY);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _funPlayerShot(Constants.currentPlayerY, Constants.currentWumpusY, Constants.currentWumpusX, Constants.currentPlayerX);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                _funPlayerShot(Constants.currentWumpusY, Constants.currentPlayerY, Constants.currentWumpusX, Constants.currentPlayerX);
        }
    }

    private void _funWinGame()
    {
        Constants.BoolWin = true;
        Debug.Log("Wumpus was haunted");
    }

    private bool _hasAmmunation()
    {
        if (Ammunation > 0)
            return true;
        else return false;
    }
    private void _funPlayerShot(int wumpusX, int playerX, int wumpusY, int playerY)
    {
        AudioShot.Play();
        if (wumpusX < playerX && wumpusY == playerY)
        {
            _funWinGame();
        }
        else
        {
            Ammunation--;
            Debug.Log("Miss shot!");
            _changeWumpusposition();
        }
    }
    private void _funTextController()
    {
        TextAmmunationCount.text = "Ammo left : " + Ammunation;
    }

    private void _changeWumpusposition()
    {
        int x = 2;
        if (Random.Range(0, 3) == x)
            Constants.BoolChangeWumpusPosition = true;
    }
}
