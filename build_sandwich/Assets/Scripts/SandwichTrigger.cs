using UnityEngine;
using System.Collections;
    
public class SandwichTrigger: MonoBehaviour {
  public IngredientManager ingredientManager;
  public bool topTrigger;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag != "SandwichIngredient") {
      return;
    }
    other.gameObject.tag = "Untagged";
    ingredientManager.Add(other.gameObject, topTrigger);
    Destroy(other.gameObject);
  }
}
