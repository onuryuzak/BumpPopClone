#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `ThrowController`. Inherits from `AtomDrawer&lt;ThrowControllerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ThrowControllerVariable))]
    public class ThrowControllerVariableDrawer : VariableDrawer<ThrowControllerVariable> { }
}
#endif
