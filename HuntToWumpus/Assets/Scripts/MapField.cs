using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapField : MonoBehaviour
{
    private MatrixField _fieldInfo;
    private SpriteRenderer _spriteRenderer;

    public void Init(MatrixField fieldInfo)
    {
        _fieldInfo = fieldInfo;
        UpdateMapField();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateMapField()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_fieldInfo != null)
        {
            if (_fieldInfo.FieldType == FieldCategory.Player)
            {
                _spriteRenderer.color = Color.red + new Color(0, 0, 0, 60);
            }
            else _spriteRenderer.color = Color.white;
        }
        _spriteRenderer.sortingLayerName = "Fields";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
