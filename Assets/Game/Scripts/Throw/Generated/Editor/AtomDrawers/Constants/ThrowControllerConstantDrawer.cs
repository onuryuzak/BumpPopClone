#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `ThrowController`. Inherits from `AtomDrawer&lt;ThrowControllerConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ThrowControllerConstant))]
    public class ThrowControllerConstantDrawer : VariableDrawer<ThrowControllerConstant> { }
}
#endif
