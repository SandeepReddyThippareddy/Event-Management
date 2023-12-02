using Application.Activities;
using Domain;
using EmailHandler.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IEmailSenderService _emailSenderService;

        public ActivitiesController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetActivities([FromQuery] ActivityParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }

            var currentActivity = new EmailHandler.Models.Activity()
            {
                ActivityDate = activity.Date,
                ActivityLocation = activity.Venue,
                ActivityName = activity.Title,
                RedirectUrl = string.Format("{0}activities/{1}", uriBuilder.Uri.AbsoluteUri, activity.Id),
                UserName = User.Identity.Name
            };

            await _emailSenderService.SendEmailAsync(User.Identity.Name, string.Format("New Activity -{0}- Registration - Success", activity.Title), EmailHandler.Utilities.Enums.Mailtype.ActivityEnrollment, currentActivity);

            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Activity activity)
        {
            activity.Id = id;

            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }

            var currentActivity = new EmailHandler.Models.Activity()
            {
                ActivityDate = activity.Date,
                ActivityLocation = activity.Venue,
                ActivityName = activity.Title,
                RedirectUrl = string.Format("{0}activities/{1}", uriBuilder.Uri.AbsoluteUri, activity.Id),
                UserName = User.Identity.Name
            };

            await _emailSenderService.SendEmailAsync(User.Identity.Name, string.Format("Activity Updation -{0}- Success", activity.Title), EmailHandler.Utilities.Enums.Mailtype.ActivityEnrollment, currentActivity);



            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            var activity = await Mediator.Send(new Details.Query { Id = id });

            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }

            var currentActivity = new EmailHandler.Models.Activity()
            {
                ActivityDate = activity.Value.Date,
                ActivityLocation = activity.Value.Venue,
                ActivityName = activity.Value.Title,
                UserName = User.Identity.Name
            };

            if(activity.Value.Attendees.Where(x => x.Username.ToLower() == User.Identity.Name.ToLower()).Count() > 0)
            {
                currentActivity.RedirectUrl = string.Format("{0}activities", uriBuilder.Uri.AbsoluteUri);

                await _emailSenderService.SendEmailAsync(User.Identity.Name, string.Format("Activity -{0}- De-Registration - Success", activity.Value.Title), EmailHandler.Utilities.Enums.Mailtype.ActivityRegistrationCancellation, currentActivity);
            }
            else
            {
                currentActivity.RedirectUrl = string.Format("{0}activities/{1}", uriBuilder.Uri.AbsoluteUri, activity.Value.Id);
               
                await _emailSenderService.SendEmailAsync(User.Identity.Name, string.Format("Activity -{0}- Registration - Success", activity.Value.Title), EmailHandler.Utilities.Enums.Mailtype.ActivityRegistration, currentActivity);
            }

            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }
    }
}