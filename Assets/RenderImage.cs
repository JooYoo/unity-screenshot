using System;
using System.IO;
using UnityEngine;

public class RenderImage : MonoBehaviour
{
    public Camera RenderCamera;
    private int picIndex;

    void Start()
    {
        picIndex = 0;
    }
    
 
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenShot();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ScreenCapture.CaptureScreenshot(picIndex++ + "testPic.png");

            Debug.Log("Original Screenshot");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            global::ScreenShot.TakeScreenShot("/../Screenshots/Screenshot_", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), Camera.main);
        }
    }

    void ScreenShot()
    {
        if (!Directory.Exists("../Screenshots"))
        {
            Directory.CreateDirectory("../Screenshots");
        }
        
        RenderToImage();    
    }

    void RenderToImage()
    {
        // info print
        Debug.Log("In RenderCam");

        // capture the virtuCam and save it as a square PNG.
        RenderCamera.aspect = 1.65f;
        
        // recall that the height is now the "actual" size from now on

        RenderTexture tempRT = new RenderTexture(RenderCamera.pixelWidth, RenderCamera.pixelHeight, 24);
        // the 24 can be 0,16,24, formats like
        // RenderTextureFormat.Default, ARGB32 etc.

        RenderCamera.targetTexture = tempRT;
        RenderCamera.Render();

        RenderTexture.active = tempRT;
        Texture2D virtualPhoto =
            new Texture2D(RenderCamera.pixelWidth, RenderCamera.pixelHeight, TextureFormat.RGB24, false);
        // false, meaning no need for mipmaps
        virtualPhoto.ReadPixels(new Rect(0, 0, RenderCamera.pixelWidth, RenderCamera.pixelHeight), 0, 0);
        virtualPhoto.Apply();

        RenderTexture.active = null; //can help avoid errors 
        RenderCamera.targetTexture = null;
       Destroy(tempRT);

        byte[] bytes;
        bytes = virtualPhoto.EncodeToPNG();

    
        File.WriteAllBytes(Application.dataPath + "/../Screenshots/Screenshot_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".png", bytes);

        RenderCamera.targetTexture = null;

        }
}