Flashcard MVVM App - ShuffleCard
📱 Project Overview
A modern, interactive flashcard application built with .NET MAUI using the MVVM (Model-View-ViewModel) architecture pattern. Test your knowledge with geography flashcards featuring smooth animations and visual feedback.

✨ Features
Interactive Flashcards: 10 geography questions with answers

Smart Answer Verification: Case-insensitive answer checking

Visual Feedback: Color-coded responses (green for correct, red for incorrect)

Smooth Animations: Fade and rotation transitions

Navigation Controls: Previous/Next buttons for sequential navigation

Shuffle Mode: Random card selection with rotation animation

Progress Tracking: Display current card position

Encouraging Feedback: Random positive messages for correct answers

Modern UI: Clean design with gradient backgrounds and shadows

🏗️ Architecture
This project follows the MVVM (Model-View-ViewModel) pattern:

text
ShuffleCard/
├── MVVM/
│   ├── Models/           # Data models
│   │   └── Flashcard.cs
│   ├── ViewModels/       # Business logic
│   │   └── FlashcardViewModel.cs
│   └── Views/           # UI components
│       ├── ShufflePage.xaml
│       └── ShufflePage.xaml.cs
├── App.xaml             # Application resources
└── App.xaml.cs          # Application entry point
🚀 Getting Started
Prerequisites
.NET 9.0 SDK or later

Visual Studio 2022 (with MAUI workload) or VS Code

Android/iOS/Windows/macOS target platform

Installation
Clone the repository:

bash
git clone https://github.com/[your-username]/ShuffleCard.git
cd ShuffleCard
Restore NuGet packages:

bash
dotnet restore
Build the project:

bash
dotnet build
Run the application:

bash
dotnet run --framework net9.0-android
# or for Windows:
dotnet run --framework net9.0-windows
🎮 How to Use
Basic Navigation
View Question: Each card displays a geography question

Submit Answer: Type your answer in the text field and press Enter

Check Answer: The correct answer appears with color-coded feedback

Navigate Cards:

Previous: Go to the previous card

Next: Go to the next card

Shuffle: Randomly select a card with rotation animation

Answer Feedback
✅ Green background: Correct answer

❌ Red background: Incorrect answer

🌟 Encouraging messages: Random positive feedback for correct answers

🛠️ Technical Details
Models
Flashcard.cs: Data structure containing Question, Answer, IsRevealed, IsCorrect properties

ViewModels
FlashcardViewModel.cs:

Implements INotifyPropertyChanged for data binding

Manages flashcard collection and current index

Handles answer validation and navigation logic

Provides commands for UI interactions

Views
ShufflePage.xaml: UI layout with data bindings

ShufflePage.xaml.cs: Code-behind with minimal logic

Converters
AnswerBackgroundConverter: Converts boolean correctness to background color

AnswerTextColorConverter: Converts boolean correctness to text color

InverseBoolConverter: Inverts boolean values for UI visibility

📝 Customization
Adding New Flashcards
Edit the InitializeFlashcards() method in FlashcardViewModel.cs:

csharp
Flashcards = new ObservableCollection<Flashcard>
{
    new Flashcard { Question = "Your question?", Answer = "Your answer" },
    // Add more flashcards here
};
Changing UI Colors
Modify color codes in:

App.xaml.cs: Converter color values

ShufflePage.xaml: Background and text colors

Modifying Feedback Messages
Update the messages array in the SubmitAnswer() method of FlashcardViewModel.cs:

csharp
string[] messages = 
{
    "Custom message 1",
    "Custom message 2",
    // Add more messages
};
🔧 Troubleshooting
Common Issues
Build errors: Ensure .NET 9.0 MAUI workload is installed
UI not updating: Check that properties raise OnPropertyChanged()
Converters not working: Verify they're registered in App.xaml

Debug Tips
Use Debug.WriteLine() for ViewModel debugging
Check binding errors in Visual Studio's Output window
Verify data context is properly set in XAML

📱 Platform Support
✅ Android
✅ iOS
✅ Windows
✅ macOS

🤝 Contributing
Fork the repository
Create a feature branch
Commit your changes
Push to the branch
Open a Pull Request

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

🙏 Acknowledgments
Built with .NET MAUI
MVVM pattern implementation
Inspired by interactive learning apps

📧 Contact
For questions or support, please open an issue in the GitHub repository.

Happy Learning! 📚✨

