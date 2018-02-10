using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MovePiece : MonoBehaviour, IInputClickHandler {

    public void OnInputClicked(InputClickedEventData eventData)
    {
        this.gameObject.SetActive(false); 
    }
}
