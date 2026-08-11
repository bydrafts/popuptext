using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Fade : IPopupTextAnimation
    {
        [Min(.1f)] public float inDuration = .25f;
        [Min(.1f)] public float waitDuration;
        [Min(.1f)] public float outDuration = .25f;

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.color = orig.color;
        }
        
        public IEnumerator Play(TMP_Text text)
        {
            var color = text.color;
            color.a = 0;
            text.color = color;

            yield return GoTo(text, inDuration, 1);
            yield return new WaitForSeconds(waitDuration);
            yield return GoTo(text, outDuration, 0);
        }

        static IEnumerator GoTo(TMP_Text text, float duration, float to)
        {
            var from = 1 - to;

            for (var i = 0f; i < duration; i += Time.deltaTime)
            {
                var color = text.color;
                color.a = Mathf.Lerp(from, to, i / duration);
                text.color = color;
                yield return null;
            }

            var finalColor = text.color;
            finalColor.a = to;
            text.color = finalColor;
        }
    }
}