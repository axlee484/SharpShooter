using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.forward);
    }
}
