using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class controllerArea : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
 {
     public void OnPointerDown (PointerEventData eventData) 
     {
         Debug.Log (this.gameObject.name + " Was Clicked.");
         this.gameObject.SetActive(false);
     }
 }
    /**
    public GameObject controllerAreaCanvas;
    
    public Image controllerAreaImg;
    public Text text;
    
    void Start()
    {
        StartCoroutine(ShowControllerArea(seconds));
    }

    IEnumerator ShowControllerArea(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        controllerAreaImg.enabled = false;
        text.enabled = false;

    }
    
    public void OnInfoClick()
    {
        //controllerAreaImg.enabled = false;
        //text.enabled = false;
        Debug.Log("clicked00");
        controllerAreaCanvas.SetActive(false); 
    }
    

    private Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        btn.gameObject.SetActive(false);
    }
    

    void OnPointerDown(){
        Debug.Log("fuck");
    }
    
}
**/
