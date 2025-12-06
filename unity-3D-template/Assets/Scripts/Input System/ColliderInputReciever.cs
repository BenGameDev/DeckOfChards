using UnityEngine;

public class ColliderInputReciever : InputReciever
{
    private Vector3 clickPosition;
    public Camera blackCamera, whiteCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (whiteCamera.enabled == true)
            {
                RaycastHit hit;
                Ray ray = whiteCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;
                    OnInputReceived();
                }
            }
            else if (blackCamera.enabled == true)
            {
                RaycastHit hit;
                Ray ray = blackCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;
                    OnInputReceived();
                }
            }
        }
    }

    public override void OnInputReceived()
    {
        foreach (var handler in inputHandlers)
        {
            handler.ProcessInput(clickPosition, null, null);
        }
    }
}
