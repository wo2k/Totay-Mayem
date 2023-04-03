using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : SingletonTemplate<PostProcessing>
{
    public Volume volume;
    public float fadeInTime = 1f;
    public float fadeOutTime = 1f;
    public float fadeDelay = 0.3f;

    public IEnumerator ColorLerpIn(Color endColor)
    {
        ColorAdjustments colorAdjustment;
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustment))
        {         
            for(float t = 0.1f; t <fadeInTime; t+= 0.1f)
           {
                colorAdjustment.colorFilter.Interp(Color.white, endColor, t/fadeInTime);
                yield return null; 
            }
            yield return new WaitForSeconds(fadeDelay);
            StartCoroutine(ColorLerpOut(endColor, Color.white));
        }
    }

    public IEnumerator ColorLerpOut(Color startColor, Color endColor)
    {
        ColorAdjustments colorAdjustment;
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustment))
        {
            for (float t = 0.1f; t < fadeOutTime; t += 0.1f)
            {
                colorAdjustment.colorFilter.Interp(startColor, endColor, t/fadeOutTime);
                yield return null;
            }
        }
    }

}
