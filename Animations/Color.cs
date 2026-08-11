using System;
using System.Collections;
using TMPro;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Color : IPopupTextAnimation
    {
        public UnityEngine.Color color;

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.color = orig.color;
        }

        public IEnumerator Play(TMP_Text text)
        {
            color.a = 1;
            text.color = color;
            yield break;
        }
    }
}