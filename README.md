# RPG Player Controller - State Machine Implementation


https://github.com/user-attachments/assets/dea4c0e8-4d02-44df-b67c-b65cbd8521ad


## 🎮 Overview

A scalable, maintainable player controller system for an RPG game, built using the **State Machine design pattern**. This architecture ensures centralized state management while allowing seamless transitions between player states without conflicts.

## 🎯 Goals

- **Readable**: Clear separation of concerns with distinct state classes
- **Maintainable**: Modular architecture using solid OOP principles
- **Scalable**: Easy to extend with new states and behaviors
- **Centralized Control**: Single source of truth for player state management
- **Conflict-Free Transitions**: Robust state switching without edge cases

## 🏗️ Architecture

### State Machine Pattern

The system divides player behavior into distinct states, each handling its own logic:

```
Idle → Move → Jump → Fall → Attack → Combo → ...
```

Each state defines:
- Entry behavior (OnEnter)
- Frame update logic (OnUpdate)
- Exit behavior (OnExit)
- Valid transitions to other states

### Core Components

#### 1. **New Input System** 🎮
- **Action-based input mapping** for flexible control schemes
- Supports multiple input devices:
  - Keyboard & Mouse 
- Centralized input handling for easy rebinding, can be scaled to other devices in future

#### 2. **Animation Events** 🎬
- Triggers combo attack logic at precise animation frames
- Perfect synchronization between animations and game logic
- Ensures attacks execute exactly when they should visually

#### 3. **Coroutines** ⏱️
- Manages time-based delays between attacks
- Uses `WaitForEndOfFrame()` for combo rhythm
- Provides smooth timing for action sequences

#### 4. **Blend Trees** 🌊
- Smooth transitions between Jump and Fall states
- Uses Y velocity as blend parameter
- Creates natural, physics-based animations

#### 5. **Sub-State Machines** 🔄
- Simplified combo attack transitions
- Entry and Exit points for cleaner workflows
- Modular structure for easy expansion

## 🥊 Combo Attack System (Personal Highlight)

The combo system merges **Sub-State Machines** and **Animation Triggers** to create:
- Seamless attack-to-attack transitions
- Expandable framework for future mechanics
- Precise timing using animation events
- Smooth visual feedback with blend trees

### How It Works

1. Player initiates attack (Input detected)
2. State machine transitions to Attack State
3. Animation plays with embedded events
4. Animation event triggers combo window
5. If input detected during window → Combo continues
6. If no input → Returns to Idle/Move state

## 🛠️ OOP Principles Applied

### Inheritance
Base `State` class provides common functionality, with specific states inheriting and extending behavior.

```
State (Base)
├── IdleState
├── MoveState
├── JumpState
├── AttackState
└── ComboState
```

### Encapsulation
Each state encapsulates its own logic, animations, and transitions, hiding implementation details.

### Abstraction
Abstract interfaces define state contracts, allowing new states to be added without modifying existing code.

## 🚀 Features

- ✅ Flexible input handling across multiple devices
- ✅ Smooth, physics-based movement
- ✅ Responsive combo attack system
- ✅ Extensible state architecture
- ✅ Clean animation integration
- ✅ Collision-free state transitions

## 📦 Future Expansion

The modular design allows easy addition of:
- Special abilities and skills
- Dodge/roll mechanics
- Weapon switching systems
- Inventory interactions
- Dialogue states
- Mount/vehicle controls

## 🎓 Key Takeaways

This implementation demonstrates:
- Proper use of design patterns in game development
- Integration of Unity's animation system with code
- Scalable architecture for complex player controllers
- Professional code organization and structure

---

**Built with**: Unity, C#, New Input System, Animator Controller

