﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PATIO.MAIN.Classes
{
    public enum Direction
    {
        ARS, D3SE, DOS, DOMS, DPPS, DST
    }

    public enum TypeUtilisateur
    {
        DOSSIER, UTILISATEUR, PILOTE, ADMINISTRATEUR
    }

    public enum TypeLicence
    {
        ADMINISTRATEUR, PILOTE, VISITEUR
    }

    public enum TypePlan
    {
        DOSSIER, NATIONAL, REGIONAL, TERRITORIAL, LOCAL, TRANSVERSE
    }

    public enum NiveauPlan
    {
        Niveau_2, Niveau_3, Niveau_4, Niveau_5
    }

    public enum TypeObjectif
    {
        DOSSIER, AXE, STRATEGIQUE, GENERAL, OPERATIONNEL
    }

    public enum Meteo
    {
        SOLEIL, SOLEIL_NUAGES, NUAGES, ORAGE
    }

    public enum TxAvancement
    {
        PCT_0_25, PCT_25_50, PCT_50_75, PCT_75_100
    }

    public enum TypeAction
    {
        DOSSIER, ACTION, OPERATION
    }

    public enum TypeIndicateur
    {
        DOSSIER, MOYEN, IMPACT, RESULTAT
    }

    public enum TypeGroupe
    {
        DOSSIER, GROUPE
    }

    //Modeles
    public enum Type_Modele
    {
        DOSSIER, MODELE, ZONE, LIGNE, COLONNE
    }

    public enum Alignement
    {
        Gauche, Centré, Droit, Justifié
    }

    //Processus
    public enum TypeProcessus
    {
        DOSSIER, GROUPE, PROCESSUS
    }

    //OMEGA
    public enum TypeEnveloppe
    {
        FIR, MIGAC, FISS
    }

    public enum TypePeriode
    {
        Année, Campagne
    }

    public enum TypeFlux
    {
        Recettes, Dépenses
    }

    public enum TypeMontant
    {
        CP, AE
    }

    public enum TypeBudget
    {
        Initial, Rectificatif, Final
    }

    public enum TypeVirement
    {
        Normal, Fongibilité
    }

    public enum TypeFiche
    {
        DOSSIER, Normal, Reprogrammation
    }

    public enum TypeLigne
    {
        DOSSIER, Normal, Reprogrammation
    }

    public enum TypeDecision
    {
        DOSSIER, Arrêté, Convention
    }

    public enum TypeEcheance
    {
        DOSSIER, Normal, Avance, Douzième
    }

    public enum TypeLiquidation
    {
        DOSSIER, Normal, Reprogrammation
    }

    public enum TypeOrdrePaiement
    {
        DOSSIER, Normal
    }

}
