using TMPro;
using UnityEngine;

public class OnObjectClick : MonoBehaviour
{
    public Transform panelUI;
    public TextMeshProUGUI textUI;
    public Material selectedMaterial;
    public Material baseMaterial;

    private bool _isSelected;
    public bool IsSelected => _isSelected;

    private void OnMouseDown()
    {
        if (!IsSelected)
        {
            panelUI.gameObject.SetActive(true);

            GetComponent<MeshRenderer>().material = selectedMaterial;
            _isSelected = true;
        }
        else 
        {
            GetComponent<MeshRenderer>().material = baseMaterial;
            _isSelected = false;
        }
    }
}
