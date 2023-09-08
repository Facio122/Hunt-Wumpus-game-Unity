using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Options : MonoBehaviour
{
    public Slider MapSlider;
    public Slider VolumeSlider;
    public Text matrixText;
    public Text volumeText;
    // Start is called before the first frame update
    void Start()
    {
        MapSlider.value = Constants.DefaultMapSize;
        VolumeSlider.value = Constants.DefaultMusicVolume * 100f;
        SetMatrixSliderValueToText();
        SetVolumeSliderValueToText();
    }

    // Update is called once per frame
    void Update()
    {
        Constants.MusicVolume = VolumeSlider.value / 100f;

    }

    public void SetMatrixSliderValueToText()
    {
        matrixText.text = $"Map size is : " + MapSlider.value.ToString() + " x " + MapSlider.value.ToString();
        Constants.MapSize = Mathf.FloorToInt(MapSlider.value);
    }
    public void SetVolumeSliderValueToText()
    {
        volumeText.text = $"Volume is : " + VolumeSlider.value.ToString() + "%";
    }
}
