using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProje.CQRS.Result.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handler()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id=x.DestinationID,
                capacity=x.Capacity,
                city=x.City,
                daynight=x.DayNight,
                price=x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
