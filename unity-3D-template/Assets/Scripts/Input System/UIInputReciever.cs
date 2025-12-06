using UnityEngine;
using UnityEngine.Events;

public class UIInputReciever : InputReciever
{
    [SerializeField] private UnityEvent clickEvenet;
    public override void OnInputReceived()
    {
        foreach(var handler in inputHandlers)
        {
            handler.ProcessInput(Input.mousePosition, gameObject, () => clickEvenet.Invoke());
        }
    }
}
