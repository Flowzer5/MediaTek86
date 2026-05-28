# CLAUDE.md — MediaTek86

## Contexte

Atelier BTS SIO CNED — application de gestion du personnel d'une médiathèque.
Projet C# WinForms calqué **exactement** sur l'application de référence `habilitations2024` (CNED-SLAM).
Le dépôt de référence analysé se trouve dans `C:\Dev\reference-habilitations`.

---

## Stack technique

| Élément | Valeur |
|---|---|
| Framework | .NET Framework 4.8 |
| Langage | C# 7.3 maximum |
| Type de projet | WinForms (`OutputType=WinExe`) |
| Base de données | MySQL — `bdmediatek86` |
| Driver MySQL | MySql.Data (MySQL Connector NET 9.1) |
| Logs | Aucun (pas de Serilog) — `try/catch` simples |

---

## Architecture — 5 packages

```
Mediatek86/
├── bddmanager/      → singleton BDD, exécution des requêtes SQL
├── controller/      → un contrôleur par formulaire, couche mince entre vue et dal
├── dal/             → Access (singleton), XxxAccess par entité métier
├── model/           → classes métier pures (pas de logique)
├── view/            → formulaires WinForms (préfixe Frm)
├── App.config       → chaîne de connexion MySQL
└── Program.cs
```

### Rôle de chaque package

- **bddmanager** : unique classe `BddManager` (singleton), ouvre la connexion MySQL et exécute toutes les requêtes.
- **dal** : `Access` (singleton) instancie `BddManager` à partir d'`App.config` ; chaque `XxxAccess` gère les requêtes d'une entité.
- **model** : classes métier (Personnel, Absence, Service, Motif) — propriétés + constructeur, rien d'autre.
- **controller** : `FrmXxxController` instancié par la vue ; délègue aux `XxxAccess`.
- **view** : formulaires WinForms ; ne contiennent AUCUNE logique métier ni SQL.

---

## BddManager — 4 méthodes publiques

```csharp
// Singleton
public static BddManager GetInstance(string stringConnect)

// LCT (begin transaction, commit, rollback) — sans paramètres
public void ReqControle(string stringQuery)

// LMD (insert, update, delete)
public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)

// LIT (select) — retourne une List<Object[]>, chaque Object[] = une ligne
public List<Object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
```

Les paramètres SQL sont TOUJOURS passés via `Dictionary<string, object>` avec des clés préfixées `@`.

---

## Chaîne d'appels complète

```
FrmXxx (view)
  └─► FrmXxxController (controller)
        └─► XxxAccess (dal)
              └─► Access.GetInstance().Manager (dal)
                    └─► BddManager.ReqSelect / ReqUpdate / ReqControle (bddmanager)
```

### Règles de la couche dal

1. Chaque `XxxAccess` déclare `private readonly Access access = Access.GetInstance();`
2. Chaque méthode commence par `if (access.Manager != null)`
3. Chaque `catch(Exception e)` : `Console.WriteLine(e.Message)` + `Environment.Exit(0)`
4. Pour SELECT : cast des colonnes par index (`(int)record[0]`, `(string)record[1]`, etc.)
5. Jamais d'`async/await` dans la dal

---

## Format des classes métier (model)

```csharp
public class Personnel
{
    public int Idpersonnel { get; }          // id → lecture seule
    public string Nom { get; set; }          // champs modifiables
    public string Prenom { get; set; }
    public string Tel { get; set; }
    public string Mail { get; set; }
    public Service Service { get; set; }     // référence à l'objet lié (pas un int)

    public Personnel(int idpersonnel, string nom, string prenom,
                     string tel, string mail, Service service)
    {
        this.Idpersonnel = idpersonnel;
        // ...
    }
}
```

- L'`id` est toujours en `{ get; }` (lecture seule).
- Les champs modifiables sont en `{ get; set; }`.
- Les **références à d'autres entités** sont des propriétés d'objet (ex: `Service Service`, `Motif Motif`), jamais un simple `int idservice`.
- `ToString()` overridé sur les classes affichées dans les `ComboBox`/`ListBox` (retourne le champ de libellé).

---

## Base de données

```
Serveur   : localhost
Utilisateur : adminmediatek
Mot de passe : mediatek86
Base      : bdmediatek86
```

### Tables

| Table | Clé primaire | Relations |
|---|---|---|
| service | idservice | — |
| motif | idmotif | — |
| personnel | idpersonnel | FK → service |
| absence | (idpersonnel, datedebut) | FK → personnel, FK → motif |
| responsable | login | — (login/pwd hashé SHA2) |

### Chaîne de connexion dans App.config

```xml
<connectionStrings>
    <add name="Mediatek86.Properties.Settings.bdmediatek86ConnectionString"
         connectionString="server=localhost;user id=adminmediatek;password=mediatek86;database=bdmediatek86;SslMode=REQUIRED"
         providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

Le nom suit toujours le pattern : `<NomProjet>.Properties.Settings.<NomBdd>ConnectionString`

---

## Cas d'utilisation (8 UC)

| UC | Description |
|---|---|
| UC1 | S'authentifier (responsable — login/pwd SHA2) |
| UC2 | Afficher la liste du personnel |
| UC3 | Ajouter un membre du personnel |
| UC4 | Modifier les informations d'un membre du personnel |
| UC5 | Supprimer un membre du personnel |
| UC6 | Afficher les absences d'un membre du personnel |
| UC7 | Ajouter une absence |
| UC8 | Modifier / Supprimer une absence |

---

## Conventions de nommage

- **Formulaires** : préfixe `Frm` — ex: `FrmAuthentification`, `FrmPersonnel`, `FrmAbsences`
- **Contrôleurs** : `FrmXxxController` (même nom que le formulaire + `Controller`)
- **Classes dal** : `XxxAccess` — ex: `PersonnelAccess`, `AbsenceAccess`
- **Classes model** : PascalCase, singulier — ex: `Personnel`, `Absence`, `Service`, `Motif`
- **Méthodes dal** : verbe + entité — ex: `GetLesPersonnels()`, `AddPersonnel()`, `DelPersonnel()`, `UpdatePersonnel()`
- **Commentaires** : XML (`/// <summary>`) en français sur toutes les classes et méthodes publiques
- **Langue** : français pour les noms de méthodes et commentaires ; anglais toléré pour les conventions C#

---

## Interdictions absolues

- Pas d'ORM (Entity Framework, Dapper, etc.)
- Pas de C# > 7.3 (pas de `record`, pas de `switch expression`, pas d'`init`)
- Pas de Serilog ni aucune librairie de logs
- Pas d'`async/await` dans la couche dal
- Toujours utiliser `MySqlParameter` via `Dictionary<string, object>` (jamais de concaténation de chaînes SQL)
- Jamais de logique métier dans les vues ou dans `BddManager`
- Jamais de `int idXxx` à la place d'une référence objet dans les classes métier
