using UnityEngine;

public class Desktop : MonoBehaviour
{
    void Awake()
    {
        CloseDesktop();
    }

    void CloseDesktop()
    {
        gameObject.SetActive(false);
    }
}
