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
                context.Figures.Add(newFigure);
                context.SaveChanges();
            }
        }

        public void RemoveFigure(Figure figure)
        {
            using (var context = new Context())
            {
				var figureToRemove = context.Figures.FirstOrDefault(f => f.Id.Equals(figure.Id));
				if (figureToRemove is null)
                {
					throw new NotFoundModelException(NotFoundFigureMessage);
				}
				context.Figures.Remove(figureToRemove);
				context.SaveChanges();
			}
        }
    }
}
