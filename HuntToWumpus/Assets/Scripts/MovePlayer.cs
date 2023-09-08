using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioMovePlayer;
    void Start()
    {
        AudioMovePlayer.volume = Constants.MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
    bool pressedUp = Input.GetKeyDown(KeyCode.W);
    bool pressedDown = Input.GetKeyDown(KeyCode.S);
    bool pressedRight = Input.GetKeyDown(KeyCode.D);
    bool pressedLeft = Input.GetKeyDown(KeyCode.A);
    bool pressedEsc = Input.GetKeyDown(KeyCode.Escape);

        if (pressedEsc)
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        if (Constants.currentPlayerX != 0)
            if (pressedLeft)
            {
                FuMovePlayer(-1, 0);
                AudioMovePlayer.Play();
            }
        if (Constants.currentPlayerX != Constants.MapSize - 1)
            if (pressedRight)
            {
                FuMovePlayer(1, 0);
                AudioMovePlayer.Play();
            }
        if (Constants.currentPlayerY != 0)
            if (pressedDown)
            {
                FuMovePlayer(xOffset: 0, yOffset: -1);
                AudioMovePlayer.Play();
            }
        if (Constants.currentPlayerY != Constants.MapSize - 1)
            if (pressedUp)
            {
                FuMovePlayer(xOffset: 0, 1);
                AudioMovePlayer.Play();
            }
    }

    public void FuMovePlayer(int xOffset, int yOffset)
    {
        Constants.currentPlayerX += xOffset;
        Constants.currentPlayerY += yOffset;

        foreach (MatrixField item in Game_MakeMatrix.Map)
        {
            if (item.Cord_x == Constants.currentPlayerX && item.Cord_y == Constants.currentPlayerY)
            {
                item.FieldType = FieldCategory.Player;
            }
            else item.FieldType = FieldCategory.Default;
            item.FieldGameObject.UpdateMapField();
        }


    }


}
