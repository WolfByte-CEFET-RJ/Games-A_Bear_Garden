using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject objectToToggle;

    private void OnMouseDown()
    {
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}