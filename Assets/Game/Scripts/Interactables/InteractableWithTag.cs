using System.Collections.Generic;
using NaughtyAttributes;
using Sirenix.Utilities;
using UnityEngine;


public class InteractableWithTag : BaseInteractable
{
    [SerializeField] [Tag] private List<string> tags;
    protected override bool ValidateActor(GameObject g) => tags.IsNullOrEmpty() || tags.Contains(g.tag);
}