using UnityEngine;

public class OnCloseClick : MonoBehaviour
{
    private void Start()
    {
        transform.gameObject.SetActive(false);
    }
    public void OnClick()
    {
        transform.gameObject.SetActive(false);
    }
}
