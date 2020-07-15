using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class controllerArea : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{
    void Start(){
        if(PlayerPrefs.GetInt("TutorialController")<3){
            this.gameObject.SetActive(true);
            PlayerPrefs.SetInt("TutorialController", PlayerPrefs.GetInt("TutorialController")+1);
        }else{
            this.gameObject.SetActive(false);
        }
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
    }
}