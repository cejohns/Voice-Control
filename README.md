
# 🎮 Voice-Control for Unity

A Unity-based voice command system that enables developers to integrate real-time voice recognition into their games or applications. Supports customizable commands, event-driven actions, and cross-platform support via Unity's `Microphone` and speech APIs.

---

## 🔧 Built With

- **Unity Engine** (2021 or later recommended)  
- **C#** scripting  
- **UnityEngine.Windows.Speech** (for Windows platforms)  
- Optional: Third-party integrations (e.g., Google Speech-to-Text, IBM Watson)

---

## ✨ Features

- 🎙️ Voice command recognition using Unity’s built-in `KeywordRecognizer`
- ⚡ Event-driven execution of in-game actions
- 🧩 Customizable commands and callbacks
- 🧪 Lightweight and performant — no external SDKs required (by default)
- 🖥️ Works on PC (Windows); can be extended for cross-platform use

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/cejohns/Voice-Control.git
```

### 2. Import into Unity

1. Open Unity Hub  
2. Click `Add` and select the cloned folder  
3. Open the project in Unity

### 3. Usage

Attach the `VoiceControlManager.cs` script to a GameObject in your scene.

```csharp
public class GameCommandHandler : MonoBehaviour
{
    private void Start()
    {
        VoiceControlManager.Instance.RegisterCommand("jump", () => Player.Jump());
        VoiceControlManager.Instance.RegisterCommand("attack", () => Player.Attack());
        VoiceControlManager.Instance.StartRecognition();
    }

    private void OnDisable()
    {
        VoiceControlManager.Instance.StopRecognition();
    }
}
```

---

## 🛠️ Key Components

| Class / Method             | Description                                          |
|---------------------------|------------------------------------------------------|
| `VoiceControlManager`     | Singleton that manages keyword recognition           |
| `RegisterCommand(string, Action)` | Binds a spoken phrase to an in-game method     |
| `StartRecognition()`      | Begins listening for commands                        |
| `StopRecognition()`       | Stops the microphone and keyword recognizer          |

---

## 📦 Example Commands

```csharp
VoiceControlManager.Instance.RegisterCommand("pause", () => GameManager.PauseGame());
VoiceControlManager.Instance.RegisterCommand("resume", () => GameManager.ResumeGame());
VoiceControlManager.Instance.RegisterCommand("open inventory", () => UIController.ShowInventory());
```

---

## 🧪 Testing & Debugging

- Use Unity Console to verify recognition  
- Speak clearly and match registered command phrases  
- Debug output will show detected phrases

---

## 🧱 Folder Structure

```
/Assets
  /Scripts
    - VoiceControlManager.cs
    - GameCommandHandler.cs
  /Scenes
    - DemoScene.unity
```

---

## 🧑‍💻 Contributing

Contributions are welcome! Here's how:

1. Fork the repo  
2. Create your feature branch: `git checkout -b feature/my-feature`  
3. Commit your changes: `git commit -m 'Add my feature'`  
4. Push to the branch: `git push origin feature/my-feature`  
5. Submit a pull request

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙌 Acknowledgments

- Unity Documentation: [KeywordRecognizer](https://docs.unity3d.com/ScriptReference/Windows.Speech.KeywordRecognizer.html)  
- Open to integration with Google Cloud Speech, Azure, etc.

