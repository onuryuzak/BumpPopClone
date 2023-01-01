using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `ThrowController`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(ThrowControllerVariable))]
    public sealed class ThrowControllerVariableEditor : AtomVariableEditor<ThrowController, ThrowControllerPair> { }
}
