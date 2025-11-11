---

```markdown
#  Tamagotchi Lite — ESIG1

##  Objectif du projet
Ce projet est une **application console en C#** inspirée du célèbre Tamagotchi.  
Le joueur doit **prendre soin de son animal virtuel** en le nourrissant, en jouant avec lui et en le faisant dormir.  
Le but : **le garder en vie le plus longtemps possible**.

Chaque action influence trois jauges :
-  **Faim**
-  **Énergie**
-  **Bonheur**

Si l’une des jauges atteint zéro, l’animal **meurt** et le jeu propose de recommencer.

---

##  Structure générale du projet

###  `Program.cs`
Point d’entrée du jeu.  
Configure la console (UTF-8, titre de la fenêtre) puis lance le **Menu principal** via `MenuController`.

---

###  `Controllers/`
Les **contrôleurs** gèrent la logique du jeu et la navigation entre les écrans.

####  `GameController.cs`
C’est le **cœur du jeu** :
1. Appelle l’écran **Naissance** (`SBO_Naissance`) pour choisir l’animal et son nom.  
2. Lance la boucle principale :
   - Affiche les jauges du Tamagotchi.  
   - Propose les actions : **Nourrir**, **Jouer**, **Dormir** ou **Quitter**.  
3. Fait évoluer naturellement les jauges.  
4. Vérifie si l’animal est encore en vie.  
5. Si mort → affiche l’écran **Fin du jeu** (`AMM_FinDuJeu`) et propose de recommencer.

####  `MenuController.cs`
Affiche le menu principal du jeu :
```

1. Commencer une partie
2. Règles du jeu
3. Quitter

````

Le menu ne gère **que la navigation**.  
Quand on choisit "Commencer une partie", il appelle le `GameController`, qui lui-même appelle l’écran **Naissance**.  
➡️ Cela évite tout doublon d’écran.

---

###  `Ecrans/`
Contient tous les écrans visibles par le joueur.

| Fichier | Rôle |
|----------|------|
| `SBO_Naissance.cs` | Écran principal pour choisir l’espèce et le nom du Tamagotchi. |
| `SBO_ReglesDuJeu.cs` | Affiche les règles et les conseils. |
| `SBO_Quitter.cs` | Écran d’au revoir avant la fermeture du jeu. |
| `AMM_JoueAvecMoi.cs` | Affiche les jauges et les actions possibles. |
| `AMM_Faim_JoueAvecMoi.cs` | Message de feedback après avoir nourri l’animal. |
| `AMM_Energie_JoueAvecMoi.cs` | Message après que l’animal ait dormi. |
| `AMM_Bonheur_JoueAvecMoi.cs` | Message après avoir joué. |
| `AMM_FinDuJeu.cs` | Écran de fin quand l’animal meurt. |

>  L’écran **Naissance** est désormais **le seul fonctionnel** et utilisé partout.  
> Aucun autre écran ne repose la même question.

---

### `Models/`
Les **classes de données** du jeu.

- `AnimalCompagnie` → représente le Tamagotchi (nom, espèce, statistiques).  
- `Stats` → contient les jauges : `Faim`, `Énergie`, `Bonheur`.

---

###  `Services/`
Les classes qui contiennent la **logique du jeu**.

#### `GameService.cs`
Gère toutes les actions et leur impact sur les jauges :
- `AgirNourrir()` augmente la faim.  
- `AgirJouer()` augmente le bonheur.  
- `AgirDormir()` augmente l’énergie.  
- `DeriveNaturelle()` fait baisser les jauges avec le temps.  
- `EstMort()` vérifie si l’animal est toujours en vie.  



---

###  `Utils/`
Les outils généraux utilisés dans tout le projet.

- `Rng` ou le Random Number Generator → gère les nombres aléatoires et l’affichage esthétique :  
  cadres (`AfficherTexteCadre`), lignes, espaces, etc.  
- `Input` → gère la lecture des entrées clavier (chiffres valides, texte non vide, vérification des bornes).

---

##  Arborescence du projet

```bash
TamagotchiLite_AMM_SBO_ESIG1/
├── Controllers/
│   ├── GameController.cs
│   └── MenuController.cs
│
├── Ecrans/
│   ├── AMM_Bonheur_JoueAvecMoi.cs
│   ├── AMM_Energie_JoueAvecMoi.cs
│   ├── AMM_Faim_JoueAvecMoi.cs
│   ├── AMM_FinDuJeu.cs
│   ├── AMM_JoueAvecMoi.cs
│   ├── SBO_Naissance.cs
│   ├── SBO_Quitter.cs
│   └── SBO_ReglesDuJeu.cs
│
├── Models/
│   ├── AnimalCompagnie.cs
│   └── Stats.cs
│
├── Services/
│   ├── GameService.cs
│   └── (PersistenceService.cs)  supprimé
│
├── Utils/
│   ├── Input.cs
│   └── Rng.cs
│
├── Program.cs
└── README.md
````

---

##  Fonctionnement du jeu

1. Le programme démarre (`Program.cs`).
2. Affichage du **menu principal** (`MenuController`).
3. Si le joueur choisit **Commencer une partie** :

   * L’écran **Naissance** s’affiche.
   * Le joueur choisit un animal et lui donne un nom.
4. Le jeu commence : le joueur choisit des actions pour maintenir les jauges.
5. Si une jauge tombe à 0 → le Tamagotchi meurt.
6. L’écran de fin propose de rejouer ou de quitter.

---

##  Exemple d’utilisation

```text
╔════════════════════════════════════════╗
║           Tamagotchi Lite              ║
╚════════════════════════════════════════╝

1. Commencer une partie
2. Règles du jeu
3. Quitter

Votre choix : 1
```

Puis :

```text
╔════════════════╗
║    Naissance   ║
╚════════════════╝

1. Raton laveur
2. Fennec
3. Écureuil

Choisissez votre animal (1,2 ou 3) :
Votre œuf éclot...
Donnez-lui un nom :
> Pépito

Bienvenue à Pépito ! Prenez bien soin de lui !
```

---

##  Points importants à retenir

* ✅ L’écran **Naissance** de SBO est celui utilisé par tout le jeu.
* ✅ Le menu appelle uniquement le `GameController`.
* ✅ Aucun doublon d’écran.
* ✅ Le code fonctionne entièrement en **console .NET / Visual Studio**.
* ✅ Les cadres et caractères spéciaux s’affichent bien grâce à **l’encodage UTF-8**.
* ✅ ...

---

##  Crédits

Projet développé par :

* **Ana Maria Voisard**
* **Sophie Borgeaud**

> Réalisé dans le cadre du cours **ESIG1 – Développement C# : Tamagotchi Lite**.

---

##  Dernière mise à jour

**Novembre 2025 — version stable, sans doublons d’écran**

```

---

