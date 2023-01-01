using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `ThrowController`. Inherits from `SetVariableValue&lt;ThrowController, ThrowControllerPair, ThrowControllerVariable, ThrowControllerConstant, ThrowControllerReference, ThrowControllerEvent, ThrowControllerPairEvent, ThrowControllerVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/ThrowController", fileName = "SetThrowControllerVariableValue")]
    public sealed class SetThrowControllerVariableValue : SetVariableValue<
        ThrowController,
        ThrowControllerPair,
        ThrowControllerVariable,
        ThrowControllerConstant,
        ThrowControllerReference,
        ThrowControllerEvent,
        ThrowControllerPairEvent,
        ThrowControllerThrowControllerFunction,
        ThrowControllerVariableInstancer>
    { }
}
