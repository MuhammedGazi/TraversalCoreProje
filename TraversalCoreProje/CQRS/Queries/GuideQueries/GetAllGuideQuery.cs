using MediatR;
using TraversalCoreProje.CQRS.Result.GuideResult;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
