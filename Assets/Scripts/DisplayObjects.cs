using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class DisplayObjects : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public Transform objectsHub;

    void Update()
    {
        Transform[] objects = { };
        Vector3[] positions = { };
        string text = "";

        for (int i = 0; i < objectsHub.childCount; i++)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[i] = objectsHub.GetChild(i);
        }

        foreach (Transform t in objects) 
        {
            if (t.GetComponent<OnObjectClick>().isSelected == true)
            { 
                text += t.name + '\n' + t.position + '\n';

                Array.Resize(ref positions, positions.Length + 1);
                positions[positions.Length - 1] = t.position;
            }
        }
        textUI.text = text;

        var lineRenderer = objectsHub.GetComponent<LineRenderer>();

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
