using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    [SerializeField] GameObject computerGameObj;
    void OnMouseDown()
    {
        computerGameObj.SetActive(true);
    }
}
