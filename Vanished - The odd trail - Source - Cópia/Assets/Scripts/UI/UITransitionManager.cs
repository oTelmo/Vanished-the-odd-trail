using UnityEngine;
using Cinemachine;

public class UITransitionManager : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera.Priority++;
    }

    // Update is called once per frame
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;
    }
}
