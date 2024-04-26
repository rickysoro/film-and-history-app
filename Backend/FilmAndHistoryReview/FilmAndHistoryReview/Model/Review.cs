namespace FilmAndHistoryReview.Core.Model
{
    public class Review
    {
        private int _id;
        private int _userId;
        private int _movieId;
        private string _comment;

        public Review(int id, int userId, int movieId, string comment)
        {
            _id = id;
            _userId = userId;
            _movieId = movieId;
            _comment = comment;
        }

        public int Id
        {
            get { return _id; }
        }

        public int userId
        {
            get { return userId; }
            set { _userId = value; }
        }

        public int movieId
        {
            get { return movieId; }
            set { movieId = value; }
        }

        public string comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
