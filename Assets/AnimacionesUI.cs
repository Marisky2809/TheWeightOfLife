using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject elmp3;
    [SerializeField] private GameObject menuExtra;
    [SerializeField] private GameObject EconderExtra;
    

    //gamepad
    public GameObject opcionesFirst;
    public GameObject principalFirst;
    public GameObject back;
    public GameObject back2;
   

    private void Start()
    {
        LeanTween.moveX(titulo.GetComponent<RectTransform>(), -565, 1.5f).setEase(LeanTweenType.easeInOutElastic); ;

        LeanTween.moveY(elmp3.GetComponent<RectTransform>(), -244, 3f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void ActivarOpciones()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(opcionesFirst);
        LeanTween.moveX(menuExtra.GetComponent<RectTransform>(), 560, 0.5f);
    }

    public void DesactivarOpciones()
    {

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(principalFirst);
        LeanTween.moveX(EconderExtra.GetComponent<RectTransform>(), 1400, 0.5f);

    }

    public void ActivarCreditos()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(back2);
    }
    public void CreditosRegresar()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(principalFirst);
    }

}
