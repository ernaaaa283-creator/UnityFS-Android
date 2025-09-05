using UnityEngine;

public class FFStyleAimController : MonoBehaviour
{
    public Transform enemyHead;
    public float dragSpeed = 10f;
    public float recoilAmount = 2f;
    public float recoilRecovery = 5f;

    private Vector3 currentRecoil;

    void Update()
    {
        // Dragshot: geser aim ke kepala musuh
        if (Input.GetMouseButton(1)) // tahan tombol aim
        {
            Vector3 direction = enemyHead.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * dragSpeed);
        }

        // Tembak dan tambahkan recoil
        if (Input.GetMouseButtonDown(0)) // klik kiri untuk tembak
        {
            currentRecoil += new Vector3(-recoilAmount, Random.Range(-recoilAmount, recoilAmount), 0);
        }

        // Recoil recovery
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * recoilRecovery);
        transform.localEulerAngles += currentRecoil * Time.deltaTime;
    }
}