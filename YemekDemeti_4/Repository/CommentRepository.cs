using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekDemeti_4.Data;

namespace YemekDemeti_4.Repository
{
    public class CommentRepository
    {
        YemekDemeti_4DbEntities6 _dbContext = new YemekDemeti_4DbEntities6();

        public void AddComment(Comment yorum, int submit)
        {
            _dbContext.Comments.Add(new Comment()
            {
                RestaurantID = yorum.RestaurantID,
                C_Comment = yorum.C_Comment,
                Confirm = false,
                OrderID = yorum.OrderID,
                Submitted = true,
                Score = submit
            });
        }

        public void SaveComment()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Comment>  GetAllCommentByRestaurantID(int id)
        {
            return _dbContext.Comments.Where(x => x.RestaurantID == id).ToList();
        }

        public void CommentConfirm(int id)
        {
            Comment yorum = _dbContext.Comments.FirstOrDefault(x => x.ID == id);

            yorum.Confirm = true;
        }

    }
}