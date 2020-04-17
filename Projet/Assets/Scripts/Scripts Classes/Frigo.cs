using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigo : Objet
{
    List<MiniObjet> inventaire; //Liste d'objets que contient le frigo
    bool estOuvert; //Savoir si le frigo est ouvert
    
    // Update is called once per frame
    void Update()
    {
        
    }

    //Méthode pour intéragir avec le frigo
    override
    public Transform interaction(GameObject interaction)
    {
        return null;    
    }

    override
   public void utiliser()
    {
    }

    //Ouvrir/Fermer le frigo
    void ouvrir()
    {

    }

    //Rafraichir les items dans le frigo
    void rafraichir()
    {

    }

}
