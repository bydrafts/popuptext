using System;
using System.Collections;
using TMPro;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Format : IPopupTextAnimation
    {
        public string format = "{0}";

        public void ResetText(TMP_Text orig, TMP_Text clone) { }

        public IEnumerator Play(TMP_Text text)
        {
            text.text = string.Format(format, text.text);
            yield break;
        }
    }
}