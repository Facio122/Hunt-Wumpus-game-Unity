using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Communicates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNewCommunicate;
    [SerializeField] private Transform trParent;
    private bool _isPLayerNearWumpus = false;
    private bool _isPLayerNearPit = false;
    private bool _isPLayerNearBats = false;
    public static bool IsWumpusChangePosition = false;
    private float _scale = 5.2f;
    private int _messagesCount = 0;
    private float _sizedeltaX = 1100f;
    private float _sizedeltaY = 307f;
    private float _textPositionX = 5575f;
    private float _textPositionY = 850f;
    private float _textDeltaPositionY = 1400f;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        _funSpawnWumpusMessage();
        _funSpawnPitMessage();
        _funSpawnBatsMessage();
        _funSpawnTeleportMessage();
        _funSpawnWumpusChangePositionMessage();
        _funUpdateMessagePosition("WumpusMessage", "PitMessage", "BatsMessage", "teleportMessage", "ChangeWumpusPositionMessage");
        Debug.Log("messages : " + _messagesCount);
    }
    private void _funSpawnWumpusMessage()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int differenceColumn = (Constants.currentPlayerX + j) - Constants.currentWumpusX;
                int differenceRow = (Constants.currentPlayerY + i) - Constants.currentWumpusY;
                if (differenceColumn == 0 && differenceRow == 0 && !_isPLayerNearWumpus)
                {
                    _isPLayerNearWumpus = true;
                    TextMeshProUGUI spawnedCommunicate = Instantiate(_textNewCommunicate);
                    RectTransform rt = spawnedCommunicate.GetComponent<RectTransform>();
                    spawnedCommunicate.name = "WumpusMessage";
                    spawnedCommunicate.text = "You smell stinky Wumpus!";
                    spawnedCommunicate.transform.SetParent(trParent);
                    spawnedCommunicate.transform.localScale = new Vector3(_scale, _scale);
                    spawnedCommunicate.rectTransform.localPosition = new Vector3(_textPositionX, _textPositionY - _messagesCount * _textDeltaPositionY, 0);
                    rt.sizeDelta = new Vector2(_sizedeltaX, _sizedeltaY);
                    _messagesCount++;
                }
                else if ((differenceColumn > 2 || differenceColumn < -2)
                    || (differenceRow > 2 || differenceRow < -2))
                {
                    if (_isPLayerNearWumpus)
                        _messagesCount--;
                    _isPLayerNearWumpus = false;
                    Object.Destroy(GameObject.Find("WumpusMessage"));
                }
            }
        }
    }
    private void _funSpawnPitMessage()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int differenceColumn = (Constants.currentPlayerX + j) - Constants.currentPitX;
                int differenceRow = (Constants.currentPlayerY + i) - Constants.currentPitY;
                if (differenceColumn == 0 && differenceRow == 0 && !_isPLayerNearPit)
                {
                    _isPLayerNearPit = true;
                    TextMeshProUGUI spawnedCommunicate = Instantiate(_textNewCommunicate);
                    RectTransform rt = spawnedCommunicate.GetComponent<RectTransform>();
                    spawnedCommunicate.name = "PitMessage";
                    spawnedCommunicate.text = "You feel breeze!";
                    spawnedCommunicate.transform.SetParent(trParent);
                    spawnedCommunicate.transform.localScale = new Vector3(_scale, _scale);
                    spawnedCommunicate.rectTransform.localPosition = new Vector3(_textPositionX, _textPositionY - _messagesCount * _textDeltaPositionY, 0);
                    rt.sizeDelta = new Vector2(_sizedeltaX, _sizedeltaY);
                    _messagesCount++;
                }
                else if ((differenceColumn > 2 || differenceColumn < -2)
                    || (differenceRow > 2 || differenceRow < -2))
                {
                    if (_isPLayerNearPit)
                        _messagesCount--;
                    _isPLayerNearPit = false;
                    Object.Destroy(GameObject.Find("PitMessage"));
                    //Debug.Log("X : " + spawnedCommunicate.transform.position.x + " Y : " + spawnedCommunicate.transform.position.y);
                }
            }
        }
    }

    private void _funSpawnBatsMessage()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int differenceColumn0 = (Constants.currentPlayerX + j) - Constants.currentBatsX[0];
                int differenceRow0 = (Constants.currentPlayerY + i) - Constants.currentBatsY[0];
                int differenceColumn1 = (Constants.currentPlayerX + j) - Constants.currentBatsX[1];
                int differenceRow1 = (Constants.currentPlayerY + i) - Constants.currentBatsY[1];
                if (((differenceColumn0 == 0 && differenceRow0 == 0) || (differenceColumn1 == 0 && differenceRow1 == 0)) && !_isPLayerNearBats)
                {
                    _isPLayerNearBats = true;
                    TextMeshProUGUI spawnedCommunicate = Instantiate(_textNewCommunicate);
                    RectTransform rt = spawnedCommunicate.GetComponent<RectTransform>();
                    spawnedCommunicate.name = "BatsMessage";
                    spawnedCommunicate.text = "You hear flapping wings!";
                    spawnedCommunicate.transform.SetParent(trParent);
                    spawnedCommunicate.transform.localScale = new Vector3(_scale, _scale);
                    spawnedCommunicate.rectTransform.localPosition = new Vector3(_textPositionX, _textPositionY - _messagesCount * _textDeltaPositionY, 0);
                    rt.sizeDelta = new Vector2(_sizedeltaX, _sizedeltaY);
                    _messagesCount++;
                }
                else if (((differenceColumn0 > 2 || differenceColumn0 < -2)
                    || (differenceRow0 > 2 || differenceRow0 < -2))
                    && ((differenceColumn1 > 2 || differenceColumn1 < -2)
                    || (differenceRow1 > 2 || differenceRow1 < -2)))
                {
                    if (_isPLayerNearBats)
                        _messagesCount--;
                    _isPLayerNearBats = false;
                    Object.Destroy(GameObject.Find("BatsMessage"));
                    //Debug.Log("X : " + spawnedCommunicate.transform.position.x + " Y : " + spawnedCommunicate.transform.position.y);
                }
            }
        }
    }
    private void _funSpawnTeleportMessage()
    {
        if (Constants.BoolPlayerTeleport)
        {
            Debug.Log("Spawned teleport messsage");
            TextMeshProUGUI spawnedMessage = Instantiate(_textNewCommunicate);
            RectTransform rt = spawnedMessage.GetComponent<RectTransform>();
            spawnedMessage.transform.SetParent(trParent);
            spawnedMessage.text = "Cave's bats moved you to another place";
            spawnedMessage.name = "teleportMessage";
            spawnedMessage.transform.localScale = new Vector3(_scale, _scale);
            spawnedMessage.rectTransform.localPosition = new Vector3(_textPositionX, _textPositionY - _messagesCount * _textDeltaPositionY, 0);
            rt.sizeDelta = new Vector2(_sizedeltaX, _sizedeltaY);
            _messagesCount++;
            StartCoroutine(destroyMessage("teleportMessage"));
            Constants.BoolPlayerTeleport = false;
        }
    }
    private void _funUpdateMessagePosition(string stringObject0, string stringObject1, string stringObject2, string stringObject3, string stringObject4)
    {
        int count = 0;
        List<GameObject> text = new List<GameObject>();
        text.Add(GameObject.Find(stringObject0));
        text.Add(GameObject.Find(stringObject1));
        text.Add(GameObject.Find(stringObject2));
        text.Add(GameObject.Find(stringObject3));
        text.Add(GameObject.Find(stringObject4));
        foreach (GameObject message in text)
        {
            if (message != null)
            {
                var tmp = message.GetComponent<TextMeshProUGUI>();
                tmp.transform.localPosition = new Vector3(_textPositionX, _textPositionY - (count - 1) * _textDeltaPositionY);
                count++;
            }
        }
    }

    private void _funSpawnWumpusChangePositionMessage()
    {
        if (Constants.BoolChangeWumpusPosition && !IsWumpusChangePosition)
        {
            IsWumpusChangePosition = true;
            TextMeshProUGUI spawnedMessage = Instantiate(_textNewCommunicate);
            RectTransform rt = spawnedMessage.GetComponent<RectTransform>();
            spawnedMessage.transform.SetParent(trParent);
            spawnedMessage.text = "Wumpus awake and change his position";
            spawnedMessage.name = "ChangeWumpusPositionMessage";
            spawnedMessage.transform.localScale = new Vector3(_scale, _scale);
            spawnedMessage.rectTransform.localPosition = new Vector3(_textPositionX, _textPositionY - _messagesCount * _textDeltaPositionY, 0);
                    rt.sizeDelta = new Vector2(_sizedeltaX, _sizedeltaY);
            _messagesCount++;
            StartCoroutine(destroyMessage("ChangeWumpusPositionMessage"));
        }

    }
    IEnumerator destroyMessage(string messageName)
    {
        yield return new WaitForSecondsRealtime(3f);
        Object.Destroy(GameObject.Find(messageName));
        Debug.Log("Destroy teleport Message");
        _messagesCount--;
    }
}
