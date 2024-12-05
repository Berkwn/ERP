using MediatR;
using TS.Result;

namespace ERP.Server.Application.Features.RequirementsPlanningByOrderId;

public sealed record  RequirementPlanningByOrderIdCommand(Guid OrderId):IRequest<Result<RequirementPlanningByOrderIdCommandResponse>>;
