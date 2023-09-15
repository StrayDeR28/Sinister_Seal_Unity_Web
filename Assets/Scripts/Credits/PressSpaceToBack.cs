using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToBack : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
           gameObject.GetComponent<SceneLoader>().StringToEnum("Map");
        }
    }
}
