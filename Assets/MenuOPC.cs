using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOPC : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    //brillo
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, 0);
    }

    public void PantallaCom(bool pantallaComp)
    {
        Screen.fullScreen = pantallaComp;
    }

    public void ChangeVolume(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void CambiarBrillo(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r,panelBrillo.color.g,panelBrillo.color.b, 1 - slider.value);
    }
}
