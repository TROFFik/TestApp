using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{  
    public int Calculations(int SizeX, int SizeZ)
    {
        float AngleQ = Camera.main.GetComponent<Camera>().fieldOfView;
        float AngelO = Camera.main.gameObject.transform.position.y;
        float Height = Camera.main.gameObject.transform.rotation.eulerAngles.x;
        float B = Height / Mathf.Cos(AngelO * Mathf.PI / 180);
        float A = Mathf.Sqrt(Mathf.Pow(B, 2) - Mathf.Pow(Height, 2));
        float K = B * Mathf.Tan((AngleQ * Mathf.PI / 180) / 2);
        float Y = Height * Mathf.Tan((AngleQ * Mathf.PI / 180) / 2);
        float S = (K + Y) * A;
        int N = (int)((SizeX * SizeZ) / S);
        return N;
    }
}
