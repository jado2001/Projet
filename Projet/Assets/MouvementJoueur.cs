using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    public CharacterController controleurJoueur;
    public float speed = 12f;
    public float gravite = -9.81f;
    public float hauteurSaut = 100;
    Vector3 rapidite;
    public Transform checkPlancher;
    public float distanceCheck=0.4f;
    bool estGrounded;
    public LayerMask couchePlancher;
    // Update is called once per frame
    void Update()
    {
        //Inputs Joueur
        float deplacementX= Input.GetAxis("Horizontal");
        float deplacementZ= Input.GetAxis("Vertical");
        //Modification des vecteurs de deplacement
        rapidite.y += gravite * Time.deltaTime;
        Vector3 deplacement = transform.right*deplacementX + transform.forward*deplacementZ;
        //Verifier si le joueur est sur le plancher
        estGrounded = Physics.CheckSphere(checkPlancher.position, distanceCheck, couchePlancher);
        if (estGrounded)
        {
            rapidite.y = -2f;
        }
        //Sauter
        if (Input.GetButtonDown("Jump") && estGrounded)
        {
            rapidite.y += Mathf.Sqrt(hauteurSaut * -2 * gravite);
        }
        //Mouvement Joueur
        controleurJoueur.Move(deplacement * Time.deltaTime*speed);
        controleurJoueur.Move(rapidite * Time.deltaTime);


    }
}
