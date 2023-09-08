using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpecialTileObjects : MonoBehaviour
{
    [SerializeField] private GameObject _obWumpus;
    [SerializeField] private GameObject _obBats;
    [SerializeField] private GameObject _obPit;
    private GameObject _obSpawnWumpus;
    private GameObject[] _obSpawnBats = new GameObject[Constants.BatsCount];
    private GameObject _obSpawnPit;

    [SerializeField] private Transform trParent;
    private SpriteRenderer[] srBats = new SpriteRenderer[Constants.BatsCount];

    void Start()
    {
        _setObjectsPositions();
        for (int i = 0; i < Constants.currentBatsX.Length; i++)
        {
            Constants.currentBatsX[i] = Random.Range(0, Constants.MapSize);
            Constants.currentBatsY[i] = Random.Range(0, Constants.MapSize);
        }

        while (Constants.currentWumpusX == Constants.currentPlayerX && Constants.currentWumpusY == Constants.currentPlayerY)
        {
            Debug.Log("RandomizingWumpusPosition");
            Constants.currentWumpusX = Random.Range(0, Constants.MapSize);
            Constants.currentWumpusY = Random.Range(0, Constants.MapSize);
        }

        while (Constants.currentPitX == Constants.currentPlayerX && Constants.currentPitY == Constants.currentPlayerY
         || Constants.currentPitX == Constants.currentWumpusX && Constants.currentPitY == Constants.currentWumpusY)
        {
            Debug.Log("RandomizingPitPosition");
            Constants.currentPitX = Random.Range(0, Constants.MapSize);
            Constants.currentPitY = Random.Range(0, Constants.MapSize);
        }

        for (int i = 0; i < Constants.currentBatsX.Length; i++)
        {
            while (Constants.currentBatsX[i] == Constants.currentPlayerX && Constants.currentBatsY[i] == Constants.currentPlayerY
|| Constants.currentBatsX[i] == Constants.currentWumpusX && Constants.currentBatsY[i] == Constants.currentWumpusY
|| Constants.currentBatsX[i] == Constants.currentPitX && Constants.currentBatsY[i] == Constants.currentPitY)
            {
                Debug.Log("RandomizingBatPosition");
                Constants.currentBatsX[i] = Random.Range(0, Constants.MapSize);
                Constants.currentBatsY[i] = Random.Range(0, Constants.MapSize);

            }
        }


        _obSpawnWumpus = Instantiate(_obWumpus);
        _obSpawnWumpus.transform.SetParent(trParent);
        _obSpawnWumpus.name = "obWumpus";
        _obSpawnWumpus.transform.localScale = new Vector3(6.5f, 6.5f);
        SpriteRenderer srWumpus = _obSpawnWumpus.GetComponent<SpriteRenderer>();
        srWumpus.color = Color.clear;

        _obSpawnPit = Instantiate(_obPit);
        _obSpawnPit.transform.SetParent(trParent);
        _obSpawnPit.name = "obPit";
        _obSpawnPit.transform.localScale = new Vector3(6.5f, 6.5f);
        SpriteRenderer srPit = _obSpawnPit.GetComponent<SpriteRenderer>();
        srPit.color = Color.clear;

        for (int i = 0; i < Constants.currentBatsX.Length; i++)
        {
            _obSpawnBats[i] = Instantiate(_obBats);
            _obSpawnBats[i].transform.SetParent(trParent);
            _obSpawnBats[i].name = "obBats" + i;
            _obSpawnBats[i].transform.localScale = new Vector3(5.5f, 5.5f);
            srBats[i] = _obSpawnBats[i].GetComponent<SpriteRenderer>();
            srBats[i].color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            _funSetNewWumpusPosition();
            foreach (MatrixField item in Game_MakeMatrix.Map)
            {
                if (item.Cord_x == Constants.currentWumpusX && item.Cord_y == Constants.currentWumpusY)
                {
                    item.FieldType = FieldCategory.Wumpus;
                    _obSpawnWumpus.transform.localPosition = new Vector3(item.Cord_x *
                       item.FieldGameObject.GetComponent<RectTransform>().rect.height * Constants.Scale,
                       item.Cord_y * item.FieldGameObject.GetComponent<RectTransform>().rect.width * Constants.Scale);

                }

                if (item.Cord_x == Constants.currentPitX && item.Cord_y == Constants.currentPitY)
                {
                    item.FieldType = FieldCategory.Pit;
                    _obSpawnPit.transform.localPosition = new Vector3(item.Cord_x *
                       item.FieldGameObject.GetComponent<RectTransform>().rect.height * Constants.Scale,
                       item.Cord_y * item.FieldGameObject.GetComponent<RectTransform>().rect.width * Constants.Scale);
                }
                for (int i = 0; i < Constants.currentBatsX.Length; i++)
                {
                    if (item.Cord_x == Constants.currentBatsX[i] && item.Cord_y == Constants.currentBatsY[i])
                    {
                        item.FieldType = FieldCategory.Cave;
                        _obSpawnBats[i].transform.localPosition = new Vector3(item.Cord_x *
                           item.FieldGameObject.GetComponent<RectTransform>().rect.height * Constants.Scale,
                           item.Cord_y * item.FieldGameObject.GetComponent<RectTransform>().rect.width * Constants.Scale);
                    }
                }
            }
        }
    }

    private void _setObjectsPositions()
    {
        Constants.currentWumpusX = Random.Range(0, Constants.MapSize);
        Constants.currentWumpusY = Random.Range(0, Constants.MapSize);
        Constants.currentPitX = Random.Range(0, Constants.MapSize);
        Constants.currentPitY = Random.Range(0, Constants.MapSize);
    }

    private void _funSetNewWumpusPosition()
    {
        if (Constants.BoolChangeWumpusPosition)
        {
            Constants.currentWumpusX = Random.Range(0, Constants.MapSize);
            Constants.currentWumpusY = Random.Range(0, Constants.MapSize);
            Constants.BoolChangeWumpusPosition = false;
            Communicates.IsWumpusChangePosition = true;
        }
    }
}

