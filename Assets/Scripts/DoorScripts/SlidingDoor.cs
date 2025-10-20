using System;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float slideDistance = 2f;
    public float speed = 2f;
    public Transform axisSource;

    Vector3 leftClosed, rightClosed, leftOpen, rightOpen;
    bool isOpen;
    float t;

    void Awake()
    {
        if (axisSource == null) axisSource = transform;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftClosed = leftDoor.position;
        rightClosed = rightDoor.position;

        Vector3 dir = axisSource.forward;

        leftOpen = leftClosed - dir * slideDistance;
        rightOpen = rightClosed + dir * slideDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float target = isOpen ? 1f : 0f;
        t = Mathf.Lerp(t, target, Time.deltaTime * speed);

        leftDoor.position = Vector3.Lerp(leftClosed, leftOpen, t);
        rightDoor.position = Vector3.Lerp(rightClosed, rightOpen, t);
    }

    public void ToggleDoor() => isOpen = !isOpen;
    public void OpenDoor() => isOpen = true;
    public void CloseDoor() => isOpen = false;
}
