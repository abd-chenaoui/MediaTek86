MediaTek86
  
 Cest une Application de bureau Windows Forms en C# pour gérer le personnel et les absences du réseau de médiathèques MediaTek86.

  Contexte

  Projet réalisé dans le cadre du BTS SIO SLAM au CNED.
  Entreprise : ESN InfoTech Services 86
  Client : Réseau MediaTek86

  Fonctionnalités

  - Authentification du responsable
  - Affichage de la liste du personnel
  - Ajout, modification et suppression d'un personnel
  - Affichage, ajout et suppression des absences d'un personnel

  Technologies utilisées

  - C# / Windows Forms / .NET Framework
  - MySQL (WampServer)
  - Visual Studio 2022

  Installation

  1. Installer WampServer et lancer les services
  2. Importer le fichier mediatek86.sql dans phpMyAdmin
  3. Créer un utilisateur MySQL avec les droits sur la base mediatek86
  4. Adapter la chaîne de connexion dans dal/Access.cs
  5. Ouvrir MediaTek86.sln dans Visual Studio et lancer l'application

  Connexion par défaut

  - Login : admin
  - Mot de passe : 1234

  Structure du projet

  MediaTek86/
  ├── bddmanager/   → classe singleton de connexion MySQL
  ├── dal/          → accès aux données (requêtes SQL)
  ├── modele/       → classes métiers
  ├── vue/          → formulaires Windows Forms
  └── controleur/   → contrôleur MVC

  
