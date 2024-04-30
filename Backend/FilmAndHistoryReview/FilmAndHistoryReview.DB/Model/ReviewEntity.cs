using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace FilmAndHistoryReview.DB.Model
{
    [Table("review")]
    public class ReviewEntity
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("comment"), DataType(DataType.Text), StringLength(255)]
        public string Comment { get; set; }

    }
}
