#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ThrowController`. Inherits from `AtomEventEditor&lt;ThrowController, ThrowControllerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ThrowControllerEvent))]
    public sealed class ThrowControllerEventEditor : AtomEventEditor<ThrowController, ThrowControllerEvent> { }
}
#endif
