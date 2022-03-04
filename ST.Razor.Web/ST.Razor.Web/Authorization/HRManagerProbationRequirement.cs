using Microsoft.AspNetCore.Authorization;

namespace ST.Razor.Web.Authorization
{
    public class HRManagerProbationRequirement: IAuthorizationRequirement
    {
        public int ProbationMonths { get; }
        public HRManagerProbationRequirement(int probetionMonth)
        {
            ProbationMonths = probetionMonth;
        }

    }

    public class HRManagerProbationRequirementHander : AuthorizationHandler<HRManagerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
        {
           if(!context.User.HasClaim(x=> x.Type == "EmployDate"))
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmployDate").Value);
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.ProbationMonths)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }

}
