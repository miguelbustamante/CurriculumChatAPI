```markdown
# 🧠 CurriculumChatAPI

CurriculumChatAPI is a lightweight .NET Web API that serves as an AI chatbot interface for answering questions based on a professional curriculum (CV/resume). It uses ML.NET to classify user input into intents and generates tailored responses based on structured curriculum data.

---

## ✨ Features

- 🔍 ML.NET-powered **intent prediction**
- 📄 Curriculum-based chatbot responses
- ✅ REST API built with **.NET 9**
- 🌐 CORS enabled for frontend integration
- 🧪 **Swagger UI** auto-launches at root (`/`)
- 🗂️ XML comments included for rich API docs
- 🚀 Ready for deployment or integration with React/Vite frontends

---

## 📂 Project Structure

```
CurriculumChatAPI/
├── Controllers/
│   └── ChatController.cs          # Handles chat POST requests
├── Services/
│   ├── ChatbotService.cs          # A version using direct intent
│   ├── CurriculumProvider.cs      # Loads curriculum data from JSON
│   ├── IntentPredictionService.cs # Predicts user intent via ML.NET
│   └── CurriculumResponder.cs     # Maps intents to answers
├── Models/
│   ├── ChatRequest.cs             # Request DTO
│   └── ChatResponse.cs            # Response DTO
│   └── Contact.cs                 # Contact DTO
│   └── Curriculum.cs              # Curriculum DTO
│   └── Education.cs               # Education DTO
│   └── Languages.cs               # Languages DTO
│   └── ModelInput.cs              # ModelInput DTO
│   └── ModelOutput.cs             # ModelOutput DTO
│   └── Project.cs                 # Project DTO
│   └── WorkExperience.cs          # WorkExperience DTO
├── ML/
│   ├── intents.csv                # Intent training dataset
│   └── IntentClassifier.zip       # Trained ML.NET model
│   └── ModelTrainer.cs            # Provides functionality to train a machine learning model for intent classification using ML.NET.
├── curriculum.json                # Curriculum data
├── Program.cs                     # Entry point and config
├── CurriculumChatAPI.csproj       # Project config
├── appsettings.json
└── README.md
```

---

## ⚙️ Setup Instructions

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Git + IDE (e.g., Visual Studio, VS Code)

### Run Locally

```bash
git clone https://github.com/yourusername/CurriculumChatAPI.git
cd CurriculumChatAPI
dotnet restore
dotnet run
```

🌐 Navigate to: `https://localhost:5001/`  
You’ll see the Swagger UI — no need to go to `/swagger`!

---

## 📘 API Overview

### `POST /api/chat`

Processes a user message and returns a chatbot response based on predicted intent.

#### Request Body
```json
{
  "message": "What is your professional background?"
}
```

#### Successful Response (200 OK)
```json
{
  "response": "I have over 15 years of experience in backend systems, APIs, and data pipelines..."
}
```

#### Error Response (400 Bad Request)
```json
{
  "error": "Message is required."
}
```

#### Description

The endpoint uses:
- **`IIntentPredictionService`** – predicts intent from the message.
- **`ICurriculumResponder`** – retrieves a relevant answer from the CV.

---

## 🤖 ML Training

The training data lives at `ML/intents.csv`. It’s used to generate `IntentClassifier.zip` via:

```csharp
ModelTrainer.Train("ML/intents.csv", "ML/IntentClassifier.zip");
```

Training happens automatically on startup.

---

## 📦 Packages Used

| Package                              | Purpose                       |
|--------------------------------------|-------------------------------|
| `Microsoft.ML`                       | Machine learning (ML.NET)     |
| `Swashbuckle.AspNetCore.*`          | Swagger generation            |
| `Microsoft.AspNetCore.OpenApi`      | OpenAPI standard support      |

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 👤 Author

**Miguel Alfonso Bustamante Sánchez**  
💼 [miguelbustamante.github.io](https://miguelbustamante.github.io)  
📧 miguel_bustamante_84@outlook.com

---

> A minimal API that merges machine learning and self-representation — ideal for resumes, portfolios, or educational demos.
```
