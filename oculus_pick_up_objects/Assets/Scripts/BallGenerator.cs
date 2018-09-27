using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour {
  public Transform parentTransform;
  public GameObject ball;
  public Vector3 range = new Vector3(1, 1, 1);
  public float massCoef = 1.0f;
  public int numOfBalls = 1;

  float randPos() {
    return Random.value - 0.5f;
  }

  void Start() {
    for (int i = 0; i < numOfBalls; ++i) {
      GameObject ins = Instantiate(
        // object
        ball,
        // new position (random values)
        parentTransform.position + new Vector3(
          randPos() * range.x,
          randPos() * range.y,
          randPos() * range.z
        ),
        // no rotation
        Quaternion.identity,
        // parent transform
        parentTransform
      );
      Rigidbody rb = ins.GetComponent<Rigidbody>();
      rb.mass = Random.value * massCoef;
    }
  }
}
