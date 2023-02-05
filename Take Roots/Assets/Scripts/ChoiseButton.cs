using TMPro;
using UnityEngine;

public class ChoiseButton : MonoBehaviour
{
    [SerializeField] private TMP_Text choiseText;
    [SerializeField] private GameObject pointer;

    public void SetText(string text) => choiseText.text = text;
    public void SetActivePointer(bool active) => pointer.SetActive(active);
}
