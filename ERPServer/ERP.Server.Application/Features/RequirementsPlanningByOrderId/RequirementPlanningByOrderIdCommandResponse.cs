using ERPServer.Domain.DTo;

namespace ERP.Server.Application.Features.RequirementsPlanningByOrderId;

public sealed record RequirementPlanningByOrderIdCommandResponse
    (
    DateOnly Date,
    string Title,
    List<ProductDto> Products
    );
