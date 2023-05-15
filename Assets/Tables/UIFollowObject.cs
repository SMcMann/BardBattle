using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowObject : MonoBehaviour
{
    public Transform objectToFollow; // The table that this UI text will follow
    public Vector3 offset; // Offset from the table position

    private Camera cam;
    private RectTransform rectTransform;

    private void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        objectToFollow = transform.parent.parent;
        // Debug.Log($"UIFollowObject Started. Camera: {cam.name}, Object to Follow: {objectToFollow.name}"); // Debug line
    }

    private void Update()
    {


        // Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position + offset);
        rectTransform.position = objectToFollow.position + offset;
        // Debug.Log("UI text position: " + rectTransform.position);
        // Debug.Log("Table position: " + objectToFollow.position);
        // Debug.Log($"UIFollowObject Update. ScreenPoint: {screenPoint}, AnchoredPosition: {rectTransform.anchoredPosition}"); // Debug line
    }
}
