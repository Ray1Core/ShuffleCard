using ShuffleCard.MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShuffleCard.MVVM.ViewModels
{
    public class FlashcardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Flashcard> _flashcards;
        private int _currentIndex = 0;
        private string _userAnswer;
        private string _feedbackMessage;
        private bool _isFeedbackVisible;
        private bool _isAnswerRevealed;

        public ObservableCollection<Flashcard> Flashcards
        {
            get => _flashcards;
            set
            {
                _flashcards = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ProgressText));
            }
        }

        public Flashcard CurrentFlashcard => Flashcards.Count > 0 ? Flashcards[CurrentIndex] : null;

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentFlashcard));
                OnPropertyChanged(nameof(ProgressText));
                ResetAnswerState();
            }
        }

        public string UserAnswer
        {
            get => _userAnswer;
            set
            {
                _userAnswer = value;
                OnPropertyChanged();
            }
        }

        public string FeedbackMessage
        {
            get => _feedbackMessage;
            set
            {
                _feedbackMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsFeedbackVisible
        {
            get => _isFeedbackVisible;
            set
            {
                _isFeedbackVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsAnswerRevealed
        {
            get => _isAnswerRevealed;
            set
            {
                _isAnswerRevealed = value;
                OnPropertyChanged();
            }
        }

        public string ProgressText => $"Card {CurrentIndex + 1} of {Flashcards.Count}";

        public ICommand SubmitAnswerCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand ShuffleCommand { get; }

        public FlashcardViewModel()
        {
            InitializeFlashcards();

            SubmitAnswerCommand = new Command(SubmitAnswer);
            NextCommand = new Command(NextFlashcard);
            PreviousCommand = new Command(PreviousFlashcard);
            ShuffleCommand = new Command(ShuffleFlashcards);
        }

        private void InitializeFlashcards()
        {
            Flashcards = new ObservableCollection<Flashcard>
            {
                new Flashcard { Number = 1, Question = "What is the capital of Japan?", Answer = "Tokyo" },
                new Flashcard { Number = 2, Question = "Which is the largest continent?", Answer = "Asia" },
                new Flashcard { Number = 3, Question = "What is the longest river in the world?", Answer = "Nile" },
                new Flashcard { Number = 4, Question = "Which desert is the largest?", Answer = "Sahara" },
                new Flashcard { Number = 5, Question = "What is the smallest country in the world?", Answer = "Vatican City" },
                new Flashcard { Number = 6, Question = "Which country has the most population?", Answer = "China" },
                new Flashcard { Number = 7, Question = "What is the highest mountain in the world?", Answer = "Mount Everest" },
                new Flashcard { Number = 8, Question = "Which ocean is the largest?", Answer = "Pacific Ocean" },
                new Flashcard { Number = 9, Question = "Which country has the city of Istanbul?", Answer = "Turkey" },
                new Flashcard { Number = 10, Question = "What is the capital of Canada?", Answer = "Ottawa" },
            };
        }

        private void ResetAnswerState()
        {
            IsAnswerRevealed = false;
            UserAnswer = string.Empty;
        }

        private void SubmitAnswer()
        {
            if (string.IsNullOrWhiteSpace(UserAnswer) || CurrentFlashcard == null)
                return;

            var isCorrect = string.Equals(UserAnswer.Trim(), CurrentFlashcard.Answer, StringComparison.OrdinalIgnoreCase);
            CurrentFlashcard.IsCorrect = isCorrect;
            CurrentFlashcard.IsAnswered = true;
            CurrentFlashcard.IsRevealed = true;

            IsAnswerRevealed = true;

            // Show feedback
            if (isCorrect)
            {
                string[] messages = { "Great job! 🌟", "Keep it up! 👍", "You're doing amazing! 🎯", "Fantastic! 🚀", "Excellent work! 💯" };
                var rnd = new Random();
                FeedbackMessage = messages[rnd.Next(messages.Length)];
                IsFeedbackVisible = true;

                // Hide feedback after delay
                Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
                {
                    IsFeedbackVisible = false;
                    return false; // stop timer
                });
            }
        }

        private void NextFlashcard()
        {
            if (CurrentIndex < Flashcards.Count - 1)
            {
                CurrentIndex++;
            }
        }

        private void PreviousFlashcard()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
            }
        }

        private void ShuffleFlashcards()
        {
            var rnd = new Random();
            CurrentIndex = rnd.Next(0, Flashcards.Count);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}