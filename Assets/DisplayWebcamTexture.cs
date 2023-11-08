using UnityEngine;
using UnityEngine.UI;
using Klak.TestTools;

public class DisplayWebcamTexture : MonoBehaviour
{
    public ImageSource imageSource;
    public RawImage rawImage;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }
    }
}