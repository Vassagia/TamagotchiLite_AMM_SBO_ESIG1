# TamagotchiLite_AMM_SBO_ESIG1
Projet console en C# – jeu Tamagotchi pour l’école ESIG

<<<<<<< Updated upstream
## Comment utiliser Git / GitHub / Git Desktop
=======
# Architecture et flux d’exécution

Le projet suit une séparation des responsabilités basique :

* **Program** démarre l’app et délègue tout au **MenuController**.
* **MenuController** affiche le menu, route l’utilisateur vers:

  * les **écrans** `SBO_*` et `AMM_*`(statiques),
  * puis lance la **boucle de jeu** orchestrée par **GameController**.
* **GameController** pilote la partie: affiche l’état, capte le choix, applique l’action via **GameService**, fait dériver les jauges, et décide fin/rejouer.
* **Models** porte les données (l’animal et ses jauges).
* **Ecrans** contient l’UI console.
* **Utils** regroupe l’I/O console robuste et les helpers d’affichage/rand, y compris des fonctions de compatibilité attendues par les `SBO_*` aprés l'ajout de son code.

Le Program lance le menu, tuon fait un choix, ça crée le Tamagotchi, la boucle se déroule jusqu’à ce qu’il aille bien, pas bien, ou très pas bien. 

---

# Dossiers et fichiers (rôle + contrat)

## 1) `/Controllers`

### `MenuController.cs`

* **Rôle:** point d’entrée UX. Affiche le menu “Commencer / Règles / Quitter”.
* **Contrat:**

  * `Run()` boucle tant que l’utilisateur ne quitte pas.
  * Appelle directement les écrans statiques `SBO_ReglesDuJeu.EcranAfficherReglesJeu()` et `SBO_Quitter.EcranAuRevoir()`.
  * Pour “Commencer”, on laisse s’afficher la naissance (`SBO_Naissance.EcranNaissance()`), puis on enchaîne sur la vraie partie via `new GameController().NouvellePartie()`.

### `GameController.cs`

* **Rôle:** cœur métier. Orchestration de la partie.
* **Contrat (méthode publique):** `NouvellePartie()`

  * Crée l’animal (`AnimalCompagnie`) à partir de deux entrées utilisateur: espèce (parmi 3) et nom (non vide).
  * Boucle:

    1. `AMM_JoueAvecMoi.AfficherEtatEtChoix(pet)` affiche l’état (Faim/Bonheur/Énergie) et retourne un choix [1..4].
    2. Selon le choix, appelle **GameService**:

       * Nourrir → `_game.AgirNourrir(pet)` + message `AMM_Faim_JoueAvecMoi`.
       * Jouer → `_game.AgirJouer(pet)` + message `AMM_Bonheur_JoueAvecMoi`.
       * Dormir → `_game.AgirDormir(pet)` + message `AMM_Energie_JoueAvecMoi`.
       * Quitter → sort de la boucle.
    3. Applique la **dérive naturelle**: `_game.DeriveNaturelle(pet)`.
    4. Test de fin: `_game.EstMort(pet)` → si oui, `AMM_FinDuJeu.AfficherEtRedemander(pet)` propose de rejouer (recrée un animal) ou de sortir.

 Toute logique de progression/équilibrage est centralisée dans le service des Controllers.

---

## 2) `/Ecrans`

### Écrans pédagogiques de ta collègue: `SBO_*`

* **`SBO_Naissance.cs`**
  Écran statique de naissance (choix visuel/texte + nom). Il ne renvoie rien, on ne le modifie pas. Il prépare mentalement le joueur, puis on lance la vraie partie dans `GameController`.
* **`SBO_ReglesDuJeu.cs`**
  Affiche les règles. Propose 1) commencer 2) retour 3) quitter. Appelle les écrans statiques correspondants.
* **`SBO_Quitter.cs`**
  Affiche “Au revoir”, temporise 5 secondes, et termine.

> Ces fichiers contiennent des appels à des helpers tels que `AfficherLigneHaut()`, `AfficherLigneBas()`, `Vide()` et `VerificationSaisie()`. Ils sont **fourni par nos Utils** (compatibilité), donc pas besoin de toucher aux `SBO_*`.

### Écrans feedback côté toi: `AMM_*`

* **`AMM_JoueAvecMoi.cs`**
  Affiche l’état courant (`pet.Stats`) et propose 1) Nourrir 2) Jouer 3) Dormir 4) Quitter. Retourne un `int` [1..4]. Pas de logique d’état ici, uniquement l’UI console.
* **`AMM_Faim_JoueAvecMoi.cs`**
  Message après l’action “Nourrir”.
* **`AMM_Bonheur_JoueAvecMoi.cs`**
  Message après l’action “Jouer”.
* **`AMM_Energie_JoueAvecMoi.cs`**
  Message après l’action “Dormir”.
* **`AMM_FinDuJeu.cs`**
  Écran de fin. Affiche le décès, propose de recommencer, retourne `true/false`.

**Principe:** les `AMM_*` sont “dumb UIs” qui n’implémentent que l’affichage. Toute modification d’état se fait ailleurs.

---

## 3) `/Models`

### `AnimalCompagnie.cs`

* **Rôle:** entité métier.
* **Champs/props:**

  * `Espece` (string), `Nom` (string), `Stats` (instance de `Stats`).
* **Contrat:** constructeur prend `espece` et `nom`, applique des valeurs par défaut si vide (“Axolotl”, “Tama”). Le modèle ne contient **aucune logique de jeu**: il porte seulement les données.

### `Stats.cs`

* **Rôle:** état numérique du pet.
* **Props:** `Faim`, `Energie`, `Bonheur`, initialisées à 70.
* **Invariants:** valeurs clampées entre 0 et 100 via `Clamp()`.
* **Interprétation:**

  * Faim: 0 = repu/mort de faim selon ton gameplay; 100 = affamé si tu inverses la sémantique, mais ici on travaille en “réserves” positives: 0 est critique.
  * Énergie/Bonheur: 0 = critique; 100 = en forme.
    En jeu, on reste pragmatiques: ce sont des jauges normalisées à 100.

---

## 4) `/Services`

### `GameService.cs`

* **Rôle:** logique métier pure et équilibrage.
* **APIs:**

  * `AgirNourrir(AnimalCompagnie)`, `AgirJouer(...)`, `AgirDormir(...)`: appliquent un **boost** constant (+20) à la jauge visée, **capé** à 100.
  * `DeriveNaturelle(AnimalCompagnie)`: applique une **baisse aléatoire** (min/max configurables) sur Faim/Bonheur/Énergie à chaque tour. C’est ta friction naturelle.
  * `EstMort(AnimalCompagnie)`: mort si **une** jauge tombe à 0 (Faim, Bonheur, Énergie). Simple, lisible.
* **Pourquoi ici:** si demain tu changes le balance (boost +25, dérive plus forte, mort si deux jauges à 0, etc.), tu touches **uniquement** ce fichier. Le reste ne bouge pas.

### `PersistenceService.cs`

* **Rôle:** placeholder pour sauvegarder/charger une partie (ex: JSON sur disque).
* **Statut:** volontairement stub, prêt à être branché sans parasiter la logique.

---

## 5) `/Utils`

### `Input.cs`

* **Rôle:** saisies console robustes.
* **APIs:**

  * `ReadInt(prompt, min, max)`: boucle jusqu’à un entier valide dans l’intervalle.
  * `ReadNonEmpty(prompt)`: boucle jusqu’à un texte non vide.
  * **Compat** `VerificationSaisie(min, max)`: clone simple de ce qui est attendu par le code `SBO_*`. Tu évites d’éditer leurs fichiers en leur fournissant l’outil qu’ils présupposent.

### `Rng.cs`

* **Rôle:** aléatoire et helpers d’affichage “cours”.
* **APIs:**

  * `Next(min, maxInclusive)`, `Chance(percent)` pour le hasard.
  * **Compat affichage**: `AfficherLigneHaut()`, `AfficherLigneBas()`, `Vide()` pour les cadres visuels utilisés par `SBO_*`.
    Zero magie: c’est juste pour que les écrans de ta collègue compilent tels quels.

---

## 6) Fichiers racine

### `Program.cs`

* **Rôle:** point d’entrée réel du projet. Configure l’encodage UTF-8 (accents), titre de la console, démarre `MenuController`.
* **Point à retenir:** dans les propriétés du projet, **Objet de démarrage** doit être `…Program`. Ça évite le `Main` d’un écran de démo.

### `SBO_GlobalUsings.cs`

* **Rôle:** `global using` utiles au compilateur pour rendre certaines fonctions accessibles partout sans `using` local.
* **Ici:** on importe `Compat` si tu gardes des extensions, ou on peut le laisser minimal. C’est surtout pour empêcher d’ajouter des `using` dans les `SBO_*`.

---

# Cycle d’un tour de jeu (résumé 15 secondes)

1. Menu → Naissance (pédago `SBO_`) → `GameController.NouvellePartie()`.
2. `AMM_JoueAvecMoi` affiche l’état et renvoie 1..4.
3. `GameService` applique l’action (+20 capé) puis la dérive aléatoire.
4. `GameService.EstMort()` décide la fin. Si mort → `AMM_FinDuJeu` propose de rejouer.
5. Retour au menu si l’utilisateur quitte.

---

# Décisions de design (arguments qui claquent)

* **Séparation nette UI / logique**: les écrans n’ont aucune “intelligence”. Toute la balance du jeu vit dans `GameService`. C’est testable, remplaçable, et ça t’évite un spaghetti console.
* **Compat “cours”**: on n’a **pas retouché** les fichiers `SBO_*`. On a exposé les helpers qu’ils attendent (`Vide`, `AfficherLigneHaut`, `VerificationSaisie`), donc ils tournent “as-is”. Tu préserves l’historique de ta binôme.
* **Modèle minifié mais suffisant**: `AnimalCompagnie` + `Stats` avec invariants [0..100]. Lisible en 1 minute, défendable en 10.
* **Extension facile**: ajouter une action “Laver”, “Soigner”, etc. = 3 pas:

  1. Ajouter une option dans `AMM_JoueAvecMoi`.
  2. Ajouter `AgirLaver` dans `GameService`.
  3. Ajouter un écran feedback `AMM_Proprete_JoueAvecMoi` si tu veux un message.

---

# Pièges classiques (et comment tu les as évités)

* **Appeler `new SBO_Naissance()` sans méthode → ne fait rien.**
  On appelle la **méthode statique**: `SBO_Naissance.EcranNaissance();`
* **Mélange de namespaces `Tamagotchi.*` vs `TamagotchiLite_AMM_SBO_ESIG1.*`.**
  Tout le projet est uniformisé. Un seul namespace, zéro surprise.
* **Plusieurs `Main`.**
  Objet de démarrage fixé sur `Program`, le reste est décoratif.

---

# TL;DR pour ton README

* **Controllers**: Menu et orchestration de la partie (routage + boucle de jeu).
* **Ecrans**: UI console pure. `SBO_*` = écrans pédagogiques inchangés; `AMM_*` = retours d’actions et fin.
* **Models**: données du Tamagotchi, jauges normalisées.
* **Services**: logique métier du jeu (actions, dérive, mort).
* **Utils**: entrées console sûres + helpers d’affichage et compatibilité.
* **Program**: point d’entrée, UTF-8, lance le menu.

Tu peux le présenter “comme ton bébé” sans cligner: c’est clean, cohérent et défense-proof.

>>>>>>> Stashed changes
