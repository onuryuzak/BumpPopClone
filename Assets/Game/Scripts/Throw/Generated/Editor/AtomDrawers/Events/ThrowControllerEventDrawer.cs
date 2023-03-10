#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ThrowController`. Inherits from `AtomDrawer&lt;ThrowControllerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ThrowControllerEvent))]
    public class ThrowControllerEventDrawer : AtomDrawer<ThrowControllerEvent> { }
}
#endif
