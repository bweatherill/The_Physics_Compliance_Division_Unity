using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] SlidingDoor sd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() => sd = GetComponentInParent<SlidingDoor>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") sd.OpenDoor();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") sd.CloseDoor();
    }

}
