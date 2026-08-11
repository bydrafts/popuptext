using System.Collections;
using TMPro;

namespace Drafts.TextPopups
{
    public interface IPopupTextAnimation
    {
        IEnumerator Play(TMP_Text text);
        void ResetText(TMP_Text orig, TMP_Text clone);
    }
}