using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    #region Feilds
    public Transform targetPosition;
    #endregion

    #region Monodevelope
    private void Update()
    {
        rotateGun();

    }
    #endregion

    #region private Methods
    private void rotateGun()
    { 
        float angle = Mathf.Atan2(targetPosition.position.y, targetPosition.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    #endregion

}
