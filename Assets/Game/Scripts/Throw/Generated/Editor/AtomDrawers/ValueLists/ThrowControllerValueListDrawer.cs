#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `ThrowController`. Inherits from `AtomDrawer&lt;ThrowControllerValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ThrowControllerValueList))]
    public class ThrowControllerValueListDrawer : AtomDrawer<ThrowControllerValueList> { }
}
#endif
