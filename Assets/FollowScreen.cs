using UnityEngine;

public class FollowScreen : MonoBehaviour
{
    public Transform P1Goblin;
    public Transform P2Goblin;
    public Transform P1Tiefling;
    public Transform P2Tiefling;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 5f;

    private Transform P1;
    private Transform P2;

    private Camera MainCamera;

    private int frameCount = 0;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if (frameCount < 30)
        {
            frameCount++;
            if (P1Goblin.gameObject.activeSelf)
            {
                P1 = P1Goblin;
            }
            else if (P1Tiefling.gameObject.activeSelf)
            {
                P1 = P1Tiefling;
            }

            if (P2Goblin.gameObject.activeSelf)
            {
                P2 = P2Goblin;
            }
            else if (P2Tiefling.gameObject.activeSelf)
            {
                P2 = P2Tiefling;
            }
            return;
        }

        // Finds distance between the two players
        float distance = Vector3.Distance(P1.position, P2.position);

        // Find orthographic size based on distance
        float targetOrthoSize = Mathf.Clamp(distance * 0.5f, minZoom, maxZoom);

        // Smoothly adjust the camera's orthographic size towards the targets
        MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);

        // Move the CameraTarget to the midpoint between the players
        Vector3 midpoint = (P1.position + P2.position) * 0.5f;
        midpoint.z = -1f; // For some reason the camera fell out of the Z axis needed for a 2d environment
        transform.position = midpoint;
    }
}