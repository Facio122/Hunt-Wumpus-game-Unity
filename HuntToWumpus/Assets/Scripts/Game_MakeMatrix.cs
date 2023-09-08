using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_MakeMatrix : MonoBehaviour
{
    public static List<MatrixField> Map = new List<MatrixField>();
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform trTileParent;
    public FieldCategory cat = FieldCategory.Default;
    public AudioSource AudioInGameMusic;



    // Start is called before the first frame update
    void Start()
    {
        Constants.Scale = 6.5f * (1f / ((float)Constants.MapSize / 4f));
        AudioInGameMusic.volume = Constants.MusicVolume;
        AudioInGameMusic.Play();
        Constants.currentPlayerX = Random.Range(0, Constants.MapSize);
        Constants.currentPlayerY = Random.Range(0, Constants.MapSize);

        for (int i = 0; i < Constants.MapSize; i++)
        {
            for (int j = 0; j < Constants.MapSize; j++)
            {
                cat = FieldCategory.Default;

                if (j == Constants.currentPlayerX && i == Constants.currentPlayerY)
                    cat = FieldCategory.Player;

                MatrixField field = new MatrixField(j, i, cat);

                GameObject spawned = Instantiate(objectToSpawn);
                spawned.transform.SetParent(trTileParent);

                spawned.name = $"Tile X:{field.Cord_x} Y:{field.Cord_y}";

                spawned.GetComponent<MapField>().Init(field);
                spawned.transform.localScale = new Vector3(Constants.Scale, Constants.Scale);
                spawned.transform.localPosition = new Vector3(field.Cord_x * objectToSpawn.GetComponent<RectTransform>().rect.width * Constants.Scale,
                    field.Cord_y * objectToSpawn.GetComponent<RectTransform>().rect.height * Constants.Scale);
                field.FieldGameObject = spawned.GetComponent<MapField>();
                Map.Add(field);


            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Scale : " + Constants.Scale);
    }

}
