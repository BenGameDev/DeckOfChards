using UnityEngine;

public abstract class InputReciever : MonoBehaviour
{
    protected IInputHandler[] inputHandlers;

    public abstract void OnInputReceived();

    private void Awake()
    {
        inputHandlers = GetComponents<IInputHandler>();
    }
}
