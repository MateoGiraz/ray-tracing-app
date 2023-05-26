using IRepository;
using Domain;
using System.Collections.Generic;
using DataBaseRepository.Exceptions;
using System.Linq;

namespace DataBaseRepository
{
    public class FigureRepository : IRepositoryFigure
    {
        private const string NotFoundFigureMessage = "Figure was not found or already deleted";

        public List<Figure> GetFiguresByClient(string username)
        {
            using (var context = new Context())
            {
                return context.Figures.Where(figure => figure.Owner.Equals(username)).ToList();
            }
        }

        public void AddFigure(Figure newFigure)
        {
            using (var context = new Context())
            {

            }
        }

        public void RemoveFigure(Figure figure)
        {
            if (!_figures.Remove(figure))
            {
                throw new NotFoundFigureException(NotFoundFigureMessage);
            }
            else
            {
                _figures.Remove(figure);
            }
        }
    }
}
