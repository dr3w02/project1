using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkullSmash;

public class HammerAnim : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;


    public void ImageChange()
    {
        oldImage.sprite = newImage;
    }
}
