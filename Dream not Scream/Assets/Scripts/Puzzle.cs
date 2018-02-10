using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Puzzle : MonoBehaviour, IInputClickHandler {

    
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Hello");
    }
}
