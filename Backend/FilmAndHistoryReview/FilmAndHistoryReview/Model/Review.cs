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

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
    }
}
