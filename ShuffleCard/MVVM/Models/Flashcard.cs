using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleCard.MVVM.Models
{
    public class Flashcard
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsAnswered { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
