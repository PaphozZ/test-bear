using TMPro;
using UnityEngine;

public class OnObjectClick : MonoBehaviour
{
    public Transform panelUI;
    public TextMeshProUGUI textUI;
    public Material selectedMaterial;
    public Material baseMaterial;

    public bool isSelected;

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            panelUI.gameObject.SetActive(true);

            GetComponent<MeshRenderer>().material = selectedMaterial;
            isSelected = true;
        }
        else 
        {
            GetComponent<MeshRenderer>().material = baseMaterial;
            isSelected = false;
        }
    }
}
