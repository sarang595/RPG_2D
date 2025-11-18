# 2D RPG Game - Work in Progress

![Unity Version](https://img.shields.io/badge/Unity-2022.3%2B-black?logo=unity)
![Status](https://img.shields.io/badge/Status-WIP-yellow)
![License](https://img.shields.io/badge/License-MIT-blue)

## 🎮 Project Overview

A **modular 2D RPG** built in Unity, focusing on clean architecture, scalable systems, and polished gameplay. This project demonstrates professional game development practices through well-structured state machines, dynamic combat, and immersive environmental systems.

## ⚠️ Development Status

**🚧 Work in Progress** - Active development with core systems implemented and tested.

## 🌟 Completed Features

### ✅ Player State Machine & Controller
- Robust state machine architecture using the State Machine design pattern
- New Input System integration (keyboard, gamepad, touch support)
- Smooth animation blending with Blend Trees
- Combo attack system with Sub-State Machines
- Animation Event-driven combat timing
- **Branch:** `(feature/player-state-machine)`

### ✅ Parallax & Endless Background
- Multi-layer parallax scrolling for visual depth
- Seamless endless background system
- Cinemachine integration for professional camera control
- Optimized Tilemap system with collision compositing
- **Branch:** `(feature/parallax-endless-background)`

### ✅ Enemy State Machine & AI
- Unified Entity-based architecture
- Shared state machine framework for player and enemies
- Multiple enemy type support (Patrol, Chase, Attack states)
- Scalable design for bosses and special enemy types
- Demo level for testing interactions
- **Branch:** `(feature/enemy-state-machine)`

### ✅ Modular Combat System
- Precision entity detection with Physics2D
- Animation Event-synchronized damage application
- Dynamic knockback system (health-ratio based)
- Visual feedback with material flash effects
- Integrated death states with physics variations
- **Branch:** `(feature/combat-system)`

## 🏗️ Architecture Highlights

### State Machine Pattern
```
EntityState (Base)
├── PlayerState
│   ├── Idle, Move, Jump, Attack, Combo
└── EnemyState
    ├── Patrol, Chase, Attack

Entity (Base Controller)
├── PlayerController
└── EnemyController
```

### Combat Component Separation
```
Entity
├── Entity_Combat   → Attack logic, detection
├── Entity_Health   → HP, knockback, death
└── Entity_Vfx      → Visual effects, feedback
```

### OOP Principles
- **Inheritance**: Shared functionality in base classes
- **Encapsulation**: Component isolation and data hiding
- **Abstraction**: Clear interfaces between systems
- **Separation of Concerns**: Modular, maintainable code

## 🔧 Technical Stack

| Technology | Purpose |
|------------|---------|
| **Unity 2022.3+** | Game engine |
| **C#** | Primary language |
| **New Input System** | Flexible input handling |
| **Cinemachine** | Advanced camera control |
| **Physics2D** | Combat detection & collision |
| **Tilemap** | Environment optimization |
| **Animation Events** | Frame-perfect timing |
| **Coroutines** | Async operations & effects |

## 📂 Project Structure

```
Assets/
├── Scripts/
│   ├── StateMachine/
│   │   ├── Entity/          # Base entity classes
│   │   ├── Player/          # Player states & controller
│   │   └── Enemy/           # Enemy states & AI
│   ├── Combat/
│   │   ├── Entity_Combat.cs
│   │   ├── Entity_Health.cs
│   │   └── Entity_Vfx.cs
│   └── Environment/
│       ├── ParallaxBackground.cs
│       └── EndlessBackground.cs
├── Animations/              # Animation controllers & clips
├── Prefabs/                 # Player, enemies, environment
├── Scenes/
│   ├── DemoLevel.unity      # Testing environment
│   └── MainGame.unity       # Primary game scene
└── Art/                     # Sprites, tilemaps, VFX
```

## 🎯 Design Philosophy

### Scalability First
Every system is designed to extend easily without refactoring:
- New enemy types = derive from EnemyState
- New attacks = add states to combat
- New mechanics = plug into existing architecture

### Performance Conscious
- Tilemap batching reduces draw calls
- Composite colliders minimize physics overhead
- Layer masking for precise detection
- Efficient state transitions

### Developer Experience
- Clear naming conventions
- Modular components
- Reusable code patterns
- Comprehensive documentation in branches

## 🚀 Upcoming Features

### In Development
- [ ] Inventory & Equipment System
- [ ] Advanced Enemy AI (Boss behaviors)
- [ ] Special Abilities & Skills
- [ ] Level Progression System
- [ ] Save/Load System

### Planned
- [ ] Dialogue System
- [ ] Quest Management
- [ ] Audio System (SFX & Music)
- [ ] UI/HUD Implementation
- [ ] Particle Effects & Polish

## 📚 Branch Documentation

Each feature branch contains its own detailed README:

- **[Player State Machine](https://github.com/sarang595/RPG_2D/tree/Player_Statemachine?tab=readme-ov-file)** - Input, combos, animation
- **[Parallax Background](https://github.com/sarang595/RPG_2D/tree/CameraSetup-%26-Level)** - Depth, scrolling, camera
- **[Enemy State Machine](https://github.com/sarang595/RPG_2D/tree/Enemy_StateMachine)** - AI, unified architecture
- **[Combat System](https://github.com/sarang595/RPG_2D/tree/Combat_System))** - Damage, knockback, feedback

## 🤝 Contributing

This is a personal learning project, but feedback and suggestions are welcome!

## 📝 License

MIT License - Feel free to learn from and reference this code.

## 👤 Developer

**[Saran G]**
- Focused on clean architecture and scalable game systems
- Applying OOP principles and design patterns in Unity
- Building modular, maintainable code for complex gameplay

---

## 🎓 Learning Outcomes

This project demonstrates:
- ✅ Professional state machine implementation
- ✅ Unity's advanced systems (Cinemachine, New Input, Tilemap)
- ✅ Scalable architecture for complex games
- ✅ Performance optimization techniques
- ✅ Clean code principles in game development
- ✅ Modular, component-based design

---

**Status**: 🚧 Active Development | **Last Updated**: November 2025

