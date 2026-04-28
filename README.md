# GenZ Protest Simulator — Ghost of Kathmandu

![Game Cover](Assets/Pictures/main_logo.png)

> *"They took everything. Tonight, I take it back."*

---

## About

GenZ Protest Simulator: Ghost of Kathmandu is a cinematic stealth-action game built in Unity 6, inspired by the real 2024 Nepal Gen Z protests. You play as Rajan, a young man whose sister was killed during the September 8 protests outside Singha Durbar. Under army curfew, he returns alone to burn it all down.

---

## Stack

| Technology | Usage |
|---|---|
| Unity 6 (6000.0.58f2) | Game engine |
| C# | Game scripting |
| Universal Render Pipeline | Rendering |
| Cinemachine | Camera system |
| Unity Particle Pack | Fire & explosion VFX |
| AI Navigation (NavMesh) | Crowd & patrol AI |
| Timeline | Cinematic sequences |
| TextMesh Pro | UI & narration text |
| Mixamo | Character animations |
| Unity Starter Assets | Third person controller |
| Low Poly Weapons Pack | Molotov model |

---

## Controls

| Key | Action |
|---|---|
| `WASD` | Move |
| `Shift` | Sprint |
| `C` | Crouch |
| `V` | Toggle first/third person |
| `Left Click` | Throw Molotov |
| `E` | Interact |
| `G` | Detonate |
| `Escape` | Unlock cursor |

---

## Scenes

| Scene | Description |
|---|---|
| `StorylineIntro` | Cinematic opening |
| `SampleScene` | Main gameplay |
| `EndOutro` | Ending cinematic |

---

## Scripts

| Script | Description |
|---|---|
| `GameManager.cs` | Cursor lock & frame rate |
| `CameraSwitcher.cs` | First/third person toggle |
| `CrouchController.cs` | Crouch & crouch walk |
| `MolotovThrower.cs` | Throw mechanic & animation |
| `MolotovProjectile.cs` | Physics & fire on impact |
| `FireShooter.cs` | Raycast fire system |
| `ObjectiveManager.cs` | Mission tracking UI |
| `BombZone.cs` | Interaction trigger zones |
| `Detonator.cs` | Final detonation system |
| `NextScene.cs` | Scene transition |
| `CrouchController.cs` | Crouch system |

---

## Installation

1. Clone the repository:
```bash
git clone https://github.com/Sandesh-Basnet/GenZ-Protest-Simulator
```

2. Open in **Unity 6** (6000.0.58f2 or later)

3. Open **File → Build Settings** and add scenes in this order:
   - `StorylineIntro` (index 0)
   - `SampleScene` (index 1)
   - `EndOutro` (index 2)

4. Press **Play** or build for your platform

---

## System Requirements

| | Minimum |
|---|---|
| OS | Windows 10 / macOS / Linux |
| RAM | 8GB |
| GPU | NVIDIA GTX 960 or equivalent |
| Storage | 2GB |
| Unity | 6000.0.58f2 |

---

## Disclaimer

This game is a work of fiction created as an artistic tribute to the 2024 Nepal protests. It is not intended to glorify violence but to tell a human story of grief and resistance.

---

## License

Created for educational and artistic purposes. All third-party assets belong to their respective owners.

---

*"Some days just don't end."*
