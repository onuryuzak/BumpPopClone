#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ThrowControllerPair`. Inherits from `AtomDrawer&lt;ThrowControllerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ThrowControllerPairEvent))]
    public class ThrowControllerPairEventDrawer : AtomDrawer<ThrowControllerPairEvent> { }
}
#endif
