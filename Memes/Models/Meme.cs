using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Memes.Models
{
    public class Meme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public ICollection<Meme> memes { get; set; }

        public List<Meme> displayMemes;
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string User { get; set; }
        public int Type { get; set; }

        public int pageIndex;
        public bool nextPageExists;
        public int lastPage;
    }
}
