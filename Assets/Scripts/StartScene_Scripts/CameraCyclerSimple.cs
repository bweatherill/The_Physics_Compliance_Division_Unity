using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraCyclerSimple : MonoBehaviour
{
    [Tooltip("Drop in your 3 Cinemachine Virtual Cameras.")]
    public CinemachineVirtualCamera[] vcams;

    [Tooltip("How many seconds between camera changes.")]
    public float interval = 10f;

    private int current = 0;

    void Start()
    {
        if (vcams == null || vcams.Length == 0)
        {
            Debug.LogError("No VCams assigned!");
            return;
        }

        // Set the first camera active
        SetActiveCamera(0);

        // Start the looping coroutine
        StartCoroutine(CycleCameras());
    }

    IEnumerator CycleCameras()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // Move to the next camera index
            current = (current + 1) % vcams.Length;

            SetActiveCamera(current);
        }
    }

    void SetActiveCamera(int index)
    {
        for (int i = 0; i < vcams.Length; i++)
        {
            if (vcams[i] != null)
            {
                // Cinemachine uses Priority to decide which camera is active
                vcams[i].Priority = (i == index) ? 20 : 5;
            }
        }
    }
}
