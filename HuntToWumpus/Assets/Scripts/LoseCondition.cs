using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LoseCondition : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    public TextMeshProUGUI TextReturn;
    public SpriteRenderer _spriteRenderer;
    public AudioSource AudioMusicMenu;
    public AudioSource AudioFail;
    public AudioSource AudioBatWings;
    public AudioSource AudioWin;
    private bool _boolLost = false;
    private bool _boolWin = false;
    private bool _boolReturnIsClicked = false;
    private float _timer;


    // Start is called before the first frame update
    void Start()
    {
        AudioFail.volume = Constants.MusicVolume;
        AudioBatWings.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        //test();
        if ((Constants.currentPlayerX == Constants.currentWumpusX && Constants.currentPlayerY == Constants.currentWumpusY && !_boolLost) ||
            (Constants.currentPlayerX == Constants.currentPitX && Constants.currentPlayerY == Constants.currentPitY && !_boolLost))
        {
            AudioMusicMenu.mute = true;
            AudioFail.Play();
            _boolLost = true;
            StartCoroutine(EnuShowingText());
        }
        if (Input.GetKeyUp(KeyCode.Return) && (_boolLost || _boolWin))
            _boolReturnIsClicked = true;
        _funBatsEvent();
        if (Constants.BoolWin && !_boolWin)
        {
            _boolWin = true;
            AudioMusicMenu.mute = true;
            AudioWin.Play();
            TextMesh.text = "CONGRATULATION! YOU WIN!";
            TextMesh.fontSize = 100f;
            StartCoroutine(EnuShowingText());
        }
    }

    IEnumerator EnuShowingText()
    {
        yield return null;
        float i = 0;
        while (i < 3)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            i = i + 0.1f;
            TextMesh.color = new Color(1, 1, 1, i);
            _spriteRenderer.color = new Color(0, 0, 0, i);
        }
        while (!_boolReturnIsClicked)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            _timer = _timer + 0.3f;
            Debug.Log("timer" + _timer);
            if (_timer >= 0f)
                TextReturn.enabled = true;
            if (_timer >= 1f)
            {
                TextReturn.enabled = false;
            }
            if (_timer >= 2f)
            {
                _timer = 0;
            }
        }
        //Destroy all
        //_funDestroyAllObjInParent("Map");
        //_funDestroyAllObjInParent("SpecialTileObjects");
        Game_MakeMatrix.Map.Clear();
        StopAllCoroutines();
        _boolLost = false;
        _boolWin = false;
        Constants.BoolWin = false;
        Constants.BoolGameLost = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void _funDestroyAllObjInParent(string parent)
    {
        GameObject ObjParent = GameObject.Find(parent);
        Transform transform = ObjParent.transform;
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i++;
        }
        foreach (GameObject obj in allChildren)
            DestroyImmediate(obj.gameObject);
    }

    private void _funBatsEvent()
    {
        for (int k = 0; k < Constants.BatsCount; k++)
        {
            if (Constants.currentPlayerX == Constants.currentBatsX[k] && Constants.currentPlayerY == Constants.currentBatsY[k])
            {
                AudioBatWings.Play();
                Constants.currentPlayerX = Random.Range(0, Constants.MapSize);
                Constants.currentPlayerY = Random.Range(0, Constants.MapSize);
                foreach (MatrixField item in Game_MakeMatrix.Map)
                {
                    if (item.Cord_x == Constants.currentPlayerX && item.Cord_y == Constants.currentPlayerY)
                    {
                        item.FieldType = FieldCategory.Player;
                    }
                    else item.FieldType = FieldCategory.Default;
                    item.FieldGameObject.UpdateMapField();
                }
                Constants.BoolPlayerTeleport = true;
            }
        }

    }

    private void test()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            _funDestroyAllObjInParent("Map");
    }


}
