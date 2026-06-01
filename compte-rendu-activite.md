# COMPTE RENDU D'ACTIVITÉ PROFESSIONNELLE

**Projet : MediaTek86 - Application de gestion du personnel des médiathèques**

---

## 1. Identification

| Champ | Valeur |
|---|---|
| **Nom et prénom** | Sebbaghi Adil |
| **Session** | 2026 |
| **Année** | 1ère année |
| **Spécialité** | BTS SIO option SLAM (Solutions Logicielles et Applications Métiers) |
| **Centre de formation** | CNED |
| **Date de réalisation** | Mai 2026 |
| **Durée du projet** | 3 jours (29 heures de travail effectif) |

---

## 2. Contexte de la situation professionnelle

### 2.1 L'organisation

L'association **MediaTek86** gère quatre médiathèques publiques sur le département de la Vienne (86). Elle emploie une dizaine de personnes réparties dans trois services distincts (administratif, médiation culturelle, prêt).

### 2.2 Le besoin exprimé

Le service des ressources humaines de l'association souhaite informatiser deux activités jusqu'alors gérées manuellement :
- La gestion des membres du personnel (informations professionnelles, rattachement au service)
- Le suivi des absences (congés, maladie, motifs familiaux, congé parental)

L'application devra être utilisée exclusivement par un responsable RH identifié par un système d'authentification.

### 2.3 La problématique technique

L'application doit :
- Garantir la sécurité des données (authentification, mot de passe haché, requêtes paramétrées)
- Empêcher les saisies incohérentes (notamment le chevauchement de périodes d'absence)
- Être facilement déployable sur le poste du responsable RH

---

## 3. Description de l'activité réalisée

### 3.1 Objectifs

Concevoir et développer une application Windows Forms en C# .NET Framework respectant une architecture en couches **MVC + DAO + Singleton**, permettant la gestion CRUD complète du personnel et des absences, avec authentification sécurisée.

### 3.2 Travail réalisé étape par étape

**Étape 1 - Conception de la base de données**
- Élaboration du Modèle Conceptuel de Données (MCD) avec l'outil Looping
- Génération automatique du Modèle Logique de Données (MLD)
- Création de la base MySQL `bdmediatek86` (5 tables : personnel, service, absence, motif, responsable)
- Insertion des données de test (10 personnels, 50 absences, 1 responsable avec mot de passe haché en SHA-256)

**Étape 2 - Mise en place du projet**
- Création d'un projet Windows Forms .NET Framework 4.7.2
- Organisation MVC en dossiers (vue, controleur, modele, dal, bddmanager)
- Initialisation du dépôt Git et création du dépôt distant sur GitHub
- Mise en place d'un kanban de suivi avec 18 issues
- Codage du visuel des 3 formulaires (connexion, gestion du personnel, gestion des absences)

**Étape 3 - Couche modèle et accès aux données**
- Implémentation du singleton `BddManager` (connexion MySQL, méthodes ReqSelect/ReqUpdate avec requêtes paramétrées)
- Création de la classe DAL `Access` (gestion de la chaîne de connexion via App.config)
- Création des 4 classes métier (Personnel, Service, Motif, Absence)
- Génération de la documentation technique avec **SandCastle Help File Builder** (248 fichiers HTML, exportés en ZIP)

**Étape 4 - Implémentation des 8 cas d'utilisation**
- UC1 : Authentification du responsable (avec hachage SHA-256 côté SQL)
- UC2-3-4 : CRUD complet des personnels (ajout, modification, suppression avec confirmation)
- UC5 : Affichage antichronologique des absences
- UC6-7-8 : CRUD des absences avec détection automatique de chevauchement

**Étape 5 - Documentation utilisateur en vidéo**
- Enregistrement d'une vidéo de démonstration présentant l'ensemble des fonctionnalités

**Étape 6 - Déploiement et livrables**
- Génération du script SQL complet (CREATE + INSERT + utilisateur applicatif)
- Création d'un installeur MSI avec Visual Studio Installer Projects
- Rédaction du README détaillé sur le dépôt
- Création de la page portfolio dédiée à la mission

---

## 4. Conditions de réalisation

### 4.1 Environnement de développement

- **Système d'exploitation** : Windows 11
- **IDE** : Visual Studio 2022 Community
- **SGBD** : MySQL 8.4 via WampServer 3.4
- **Modélisation** : Looping (MCD et MLD)
- **Versionnage** : Git + GitHub (dépôt public)
- **Suivi de projet** : GitHub Projects (kanban)
- **Documentation** : SandCastle Help File Builder

### 4.2 Technologies mises en œuvre

| Domaine | Technologies |
|---|---|
| **Langage** | C# 7.3 |
| **Framework** | .NET Framework 4.7.2 |
| **UI** | Windows Forms |
| **Base de données** | MySQL 8.4 |
| **ORM/Accès** | MySql.Data (Connector .NET, requêtes paramétrées via MySqlParameter) |
| **Sécurité** | SHA-256 (fonction SQL SHA2) |
| **Versionnage** | Git, GitHub CLI |
| **Déploiement** | MSI (Visual Studio Installer Projects) |

---

## 5. Compétences mises en œuvre

### 5.1 Bloc 1 - Support et mise à disposition de services informatiques
- Gestion d'un environnement de développement (Wamp, Visual Studio)
- Configuration d'un SGBD MySQL et création d'un utilisateur applicatif avec droits restreints

### 5.2 Bloc 2 - SLAM : Conception et développement d'applications
- Modélisation d'un système d'information (MCD, MLD avec Looping)
- Programmation orientée objet en C# (encapsulation, héritage, polymorphisme)
- Architecture logicielle en couches (MVC + DAO + Singleton)
- Développement d'interfaces graphiques avec Windows Forms et data binding
- Manipulation de bases de données relationnelles via ADO.NET
- Sécurité applicative (authentification, requêtes paramétrées contre les injections SQL)
- Génération de documentation technique automatisée
- Création d'un installeur Windows (MSI)

### 5.3 Compétences transversales
- Gestion de projet (kanban, jalonnement par étapes)
- Utilisation d'un gestionnaire de versions (Git, branches, commits explicites)
- Rédaction de documentation utilisateur et technique (README, vidéo)

---

## 6. Bilan

### 6.1 Difficultés rencontrées

La principale difficulté a été la **compréhension fine de l'architecture MVC + DAO + Singleton**, et notamment l'articulation entre les couches : pourquoi un singleton pour la connexion, comment le contrôleur reste indépendant de la source de données, et pourquoi passer des objets métier plutôt que des identifiants entiers entre les couches.

Cette difficulté a été levée par l'étude du projet de référence "Habilitations" fourni par le CNED, qui m'a permis de visualiser concrètement l'application du pattern.

D'autres difficultés techniques ont également été rencontrées et résolues :
- **Compatibilité MySQL 8 / .NET Connector** : l'erreur "RSA public key not enabled" a nécessité l'ajout du paramètre `AllowPublicKeyRetrieval=true` dans la chaîne de connexion, et la configuration de l'utilisateur applicatif avec `mysql_native_password`.
- **Clé primaire composite** pour la table absence (idpersonnel + datedebut) : la modification d'une absence dont on change la date de début a nécessité de conserver l'ancienne date pour cibler la bonne ligne dans la clause WHERE.
- **Logique de chevauchement** : implémentation d'une méthode `EstChevauchante` qui exclut l'absence en cours d'édition en mode modification, pour éviter qu'une absence se chevauche avec elle-même.

### 6.2 Apports personnels

Ce projet m'a permis de consolider plusieurs notions essentielles du BTS SIO option SLAM. **L'apprentissage principal a été l'importance de l'architecture en couches et de la séparation des responsabilités** : isoler la couche de connexion à la base permet, par exemple, de changer de SGBDR en ne modifiant qu'une seule classe (`BddManager`). Cette séparation rend également le code plus testable et plus maintenable.

J'ai également mesuré l'importance des bonnes pratiques de développement :
- **Requêtes paramétrées systématiques** (via `MySqlParameter`) pour se prémunir contre les injections SQL
- **Hachage des mots de passe** côté SGBD pour ne jamais stocker de mot de passe en clair
- **Documentation technique** automatisée via les commentaires XML pour faciliter la maintenance
- **Gestion de version rigoureuse** avec des commits commentés et un kanban à jour

### 6.3 Perspectives

Une évolution naturelle du projet serait l'ajout d'une **gestion multi-utilisateurs** (plusieurs responsables avec différents niveaux de droits), et le **portage de l'interface** vers une technologie plus moderne (WPF, MAUI ou même une application web ASP.NET Core).

---

## 7. Annexes - Liens utiles

- **Dépôt GitHub** : https://github.com/Flowzer5/MediaTek86
- **README détaillé** : https://github.com/Flowzer5/MediaTek86/blob/main/README.md
- **Script SQL complet** : https://github.com/Flowzer5/MediaTek86/blob/main/bdd/mediatek86-complet.sql
- **Installeur MSI** : https://github.com/Flowzer5/MediaTek86/blob/main/installeur/Mediatek86Setup.msi

---

*Document rédigé dans le cadre de l'atelier B2 du parcours BTS SIO option SLAM (CNED) - 2026*
