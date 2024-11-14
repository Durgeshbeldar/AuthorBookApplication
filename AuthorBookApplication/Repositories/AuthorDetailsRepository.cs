using Microsoft.EntityFrameworkCore;
using AuthorBookApplication.Data;
using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public class AuthorDetailsRepository : IAuthorDetailsRepository
    {
        private readonly AuthorBookContext _context;

        public AuthorDetailsRepository(AuthorBookContext context)
        {
            _context = context;
        }

        // Add new author details
        public void AddAuthorDetail(AuthorDetails authorDetail)
        {
            _context.AuthorDetails.Add(authorDetail);
            _context.SaveChanges();
        }

        // Delete existing author details
        public void DeleteAuthorDetail(AuthorDetails authorDetail)
        {
            _context.AuthorDetails.Remove(authorDetail);
            _context.SaveChanges();
        }

        // Get a single author detail by id
        public AuthorDetails GetAuthorDetail(int id)
        {
            var authorDetail = _context.AuthorDetails.Find(id);
            return authorDetail;
        }

        // Get list of all author details
        public List<AuthorDetails> GetAuthorDetails()
        {
            var authorDetails = _context.AuthorDetails.ToList();
            return authorDetails;
        }

        // Update existing author details
        public bool UpdateAuthorDetail(AuthorDetails authorDetail)
        {
            var existAuthorDetail = _context.AuthorDetails.AsNoTracking().FirstOrDefault(ad => ad.Id == authorDetail.Id);
            if (existAuthorDetail == null)
                return false;

            _context.AuthorDetails.Entry(authorDetail).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
