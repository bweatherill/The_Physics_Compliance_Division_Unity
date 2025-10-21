using UnityEngine;
using Cinemachine;
public class CameraZone : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera zoneCam;
    public int activePriority = 20;
    public int inactivePriority = 5;

    void Awake() => zoneCam.Priority = inactivePriority;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) zoneCam.Priority = activePriority;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) zoneCam.Priority = inactivePriority;
    }


}
