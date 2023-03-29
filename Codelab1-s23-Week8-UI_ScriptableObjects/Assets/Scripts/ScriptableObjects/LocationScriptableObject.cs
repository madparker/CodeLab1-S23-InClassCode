using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (
   fileName = "New Location",
   menuName = "ScriptableObjects/Location",
   order = 0
   )]

public class LocationScriptableObject : ScriptableObject
{
   public string locationName;
   public string locationDescription;

   public LocationScriptableObject northLocation;
   public LocationScriptableObject southLocation;
   public LocationScriptableObject eastLocation;
   public LocationScriptableObject westLocation;
}
