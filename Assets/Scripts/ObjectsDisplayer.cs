using System;
using TMPro;
using UnityEngine;


public class ObjectsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public Transform objectsHub;

    void Update()
    {
        var objects = GetSelectedObjects();
        var positions = WriteObjectsPositions(objects);
        DisplayLineRenderer(positions);
    }

    private Transform[] GetSelectedObjects() 
    {
        Transform[] objects = { };

        for (int i = 0; i < objectsHub.childCount; i++)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[i] = objectsHub.GetChild(i);
        }
        return objects;
    }

    private Vector3[] WriteObjectsPositions(Transform[] objects) 
    {
        Vector3[] positions = { };
        string text = "";

        foreach (Transform t in objects)
        {
            if (t.GetComponent<OnObjectClick>().IsSelected == true)
            {
                text += t.name + '\n' + t.position + '\n';

                Array.Resize(ref positions, positions.Length + 1);
                positions[positions.Length - 1] = t.position;
            }
        }
        textUI.text = text;

        return positions;
    }

    private void DisplayLineRenderer(Vector3[] positions) 
    {
        var lineRenderer = objectsHub.GetComponent<LineRenderer>();

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
