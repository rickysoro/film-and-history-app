using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.Core.Exceptions
{
    public class TextTooShortException : Exception
    {
        public TextTooShortException() : base($"Text is too short. Insert a review at least 10-character long")
        { 
        }
    }
}
