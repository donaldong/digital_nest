using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class IngredientManager : MonoBehaviour {
  public GameObject top, bottom;
  public float gapBetweenIngredients = 0.0f;
  private LinkedList<GameObject> ingredients;

  public void Start() {
    ingredients = new LinkedList<GameObject>();
  }

  public void Add(GameObject obj, bool toTop) {
    // Instantiate a new ingredient object
    //  - Remove its rigid body
    GameObject newInstance = Instantiate(obj, transform);
    Destroy(newInstance.GetComponent<Rigidbody>());
    // `toTop` is passed by the Sandwich Triggers
    // This flag allows us to add ingredients at the top / bottom
    if (toTop) {
      ingredients.AddLast(newInstance);
    } else {
      ingredients.AddFirst(newInstance);
    }
    // Fix the position y components of the ingredients
    //   - The first item in the linked list has y value of 0.
    //   - Then we increase the heights when we iterate through the list
    FixPositionY();
  }

  private void FixPositionY() {
    bottom.transform.position = transform.position;
    float height = 0.0f;
    LinkedListNode<GameObject> node = ingredients.First;
    while (node != null) {
      GameObject obj = node.Value;
      Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
      Bounds bounds = mesh.bounds;
      float dy = obj.transform.localScale.y * bounds.extents.y;
      height += dy; 
      obj.transform.position = transform.position + new Vector3(0.0f, height, 0.0f);
      obj.transform.rotation = transform.rotation;
      height += dy;
      height += gapBetweenIngredients; 
      node = node.Next;
    }
    top.transform.position = transform.position + new Vector3(0.0f, height, 0.0f);
  }
}
