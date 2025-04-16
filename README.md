# Beam of The Dead

**Beam of The Dead** is a 3D zombie shooter game built in Unity, where players control a tank to fend off waves of zombies on a dynamic terrain. The game features robust tank movement, modular shooting mechanics, efficient object pooling, and a dynamic main menu with dancing zombies.

## Features

- **Dynamic Tank Movement**: Control a tank with WASD/Arrow keys for movement, and Space to shoot. The tank uses physics-based movement with a Rigidbody, smoothly navigating slopes and obstacles on a dynamic map with acceleration/deceleration and a turret vibration effect for realism.
- **Tank Variants**: Four tank types (Basic, Rapid, Heavy, Spread), each with unique stats (speed, fire rate, ammo capacity) stored in ScriptableObjects, selectable via a spawner system.
- **Bullet System**: Four bullet types (Basic, Rapid, Heavy, Spread) with distinct damage and prefabs, managed via a generic object pool for performance.
- **Zombie AI**: Basic zombies spawn around the tank, using NavMesh for pathfinding to chase the player across varied terrain. Zombies take damage from bullets, play death animations, and return to a generic object pool.
- **Command Pattern for Shooting**: Shooting is implemented using a Command Pattern, decoupling logic for modularity and future extensibility (e.g., special abilities).
- **Core Architecture**:
  - **Singleton**: `GameManager` manages game state and score as a persistent singleton.
  - **Service Locator**: Centralized access to services like `InputManager`, `AudioManager`, and `UIManager`.
  - **MVC Pattern**: Tank system uses Model-View-Controller for clean separation of data (`TankModel`), visuals (`TankView`), and logic (`TankController`).
- **Main Menu Scene**:
  - Features a Play button to start the game, transitioning to the main game scene.
  - Includes dancing zombies with animations for a lively atmosphere.
- **Main Game Scene**: Contains the tank, zombie spawner, dynamic terrain with slopes, and all gameplay systems.
- **Generic Object Pooling**: A reusable `ObjectPool<T>` base class manages both bullets and zombies, optimizing performance by reusing objects instead of instantiating/destroying.

## Project Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── ServiceLocator.cs
│   │   ├── AudioManager.cs
│   │   ├── InputManager.cs
│   │   └── UIManager.cs
│   ├── TankSystem/
│   │   ├── TankModel.cs
│   │   ├── TankView.cs
│   │   ├── TankController.cs
│   │   └── TankSpawner.cs
│   ├── BulletSystem/
│   │   ├── BulletModel.cs
│   │   ├── BulletView.cs
│   │   ├── BulletController.cs
│   │   ├── BulletPoolManager.cs
│   │   └── BulletTypeManager.cs
│   ├── ZombieSystem/
│   │   ├── ZombieModel.cs
│   │   ├── ZombieView.cs
│   │   ├── ZombieController.cs
│   │   └── ZombiePoolManager.cs
│   ├── CommandSystem/
│   │   ├── ICommand.cs
│   │   └── ShootCommand.cs
│   └── PoolingSystem/
│       └── ObjectPool.cs
├── Prefabs/
│   ├── Tanks/
│   │   ├── BasicLaserTank.prefab
│   │   ├── RapidFireTank.prefab
│   │   ├── HeavyBeamTank.prefab
│   │   └── SpreadShotTank.prefab
│   ├── Bullets/
│   │   ├── BasicBullet.prefab
│   │   ├── RapidBullet.prefab
│   │   ├── HeavyBullet.prefab
│   │   └── SpreadBullet.prefab
│   └── Zombies/
│       └── BasicZombie.prefab
├── Scenes/
│   ├── MainMenu.unity
│   └── MainGame.unity
```

## Setup Instructions

1. **Unity Version**: Use Unity 2022.3 LTS or later.
2. **Scenes**:
   - **MainMenu.unity**: Contains the main menu with a Play button and dancing zombies. Add to Build Settings (index 0).
   - **MainGame.unity**: The main gameplay scene with tank, zombies, and terrain. Add to Build Settings (index 1).
3. **NavMesh**:
   - Bake NavMesh for `MainGame.unity` terrain:
     - Set terrain/objects as Navigation Static.
     - Agent settings: Radius=0.5, Height=2, Step Height=0.5.
4. **Prefabs**:
   - Ensure tank prefabs have `TankController`, `TankView`, `BulletPoolManager`, `Rigidbody`, and `FirePoint`.
   - Bullet prefabs need `BulletController`, `BulletView`, `Rigidbody`.
   - Zombie prefab requires `ZombieController`, `ZombieView`, `NavMeshAgent`, `Animator`.
5. **ScriptableObjects**:
   - Configure `TankModel`, `BulletModel`, and `ZombieModel` in their respective folders with appropriate stats and prefab references.
6. **Testing**:
   - Start in `MainMenu.unity`, click Play to load `MainGame.unity`.
   - Controls: WASD/Arrows (move), Space (shoot).
   - Verify zombies spawn, pathfind, and die; check console for pooling logs.

## How to Play

- **Main Menu**: Click the Play button to start, enjoy dancing zombies in the background.
- **Gameplay**:
  - Drive the tank across dynamic terrain with WASD/Arrow keys.
  - Shoot zombies with Space.
  - Zombies spawn every 2 seconds, chasing the tank via NavMesh until shot down.

## Future Plans
- Add a shop system to unlock tank and bullet types with scores.
- Implement game states (e.g., paused, game over) with a state machine.
- Enhance audio and UI for polish.

## License
This project is for educational purposes and not licensed for commercial use. Assets (e.g., models, animations) may require separate licensing if sourced externally.

---

**Beam of The Dead** is a work in progress, showcasing design patterns like Singleton, Service Locator, MVC, Command, and generic object pooling. Contributions and feedback are welcome!