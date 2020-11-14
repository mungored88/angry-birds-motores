﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuArmas : MonoBehaviour
{
    [Serializable]
    public struct SpecialWeapons
    {
        public string Nombre;
        public SpriteRenderer Imagen;
    }
    public SpecialWeapons[] SpecialWeaponsImages;

    public TextMeshPro nombreChar;

    public void SetSpecialHability(String nombre)
    {
        nombreChar.text = nombre;
        switch (nombre)
        {
            case "PinguQueen":
                activarSP("NestorInTheSky");
                break;
            case "Prn-3000":
                activarSP("RayoPeronizador");
                break;
            case "El Gato":
                activarSP("GatoVolador");
                break;
            case "Juana la dama":
                activarSP("BotellaMolotov");
                break;
            case "Albertito":
                activarSP("Domo");
                break;  
            case "50Centurion":
                activarSP("Falcon");
                break;  
            case "Del Faso":
                activarSP("Mortero");
                break;  
            case "Laremassa":
                activarSP("Botella");
                break;  
            case "D-Alegria":
                activarSP("PinguinosProtestantes");
                break;  
            case "El Pelonchas":
                activarSP("Micheti");
                break;

        }
    }

    public void activarSP(String nombreArma)
    {
        foreach (SpecialWeapons sp in SpecialWeaponsImages)
        {
            if (sp.Nombre == nombreArma) sp.Imagen.enabled = true;
        }
    }  
    public void desactivarSPS()
    {
        foreach (SpecialWeapons sp in SpecialWeaponsImages)
        {
            if (sp.Imagen) sp.Imagen.enabled = false;
        }
    }
}
