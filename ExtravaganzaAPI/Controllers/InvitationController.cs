using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace ExtravaganzaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InvitationController : Controller
    {
        private static MapperConfiguration m_mapperConfiguration;
        private IContainer m_container;
        private IOptions<Settings> m_settings;

        static InvitationController()
        {
            m_mapperConfiguration = new MapperConfiguration(exp =>
            {
                exp.CreateMap<IInvitation, Models.Invitation>();
                exp.CreateMap<Models.Invitation, IInvitation>();
                exp.CreateMap<IInvitationResponse, Models.InvitationResponse>();
                exp.CreateMap<Models.InvitationResponse, IInvitationResponse>();
            });
        }

        public InvitationController(IOptions<Settings> settings)
        {
            m_settings = settings;
            ContainerBuilder builder = new ContainerBuilder();
            Vondra.Thanksgiving.Extravaganza.Core.DependencyContainer.Build(builder);
            m_container = builder.Build();
        }

        [HttpGet()]
        [Authorize(Policy = "thanksgiving-read")]
        public IActionResult GetAll()
        {
            IActionResult result = null;

            using (ILifetimeScope scope = m_container.BeginLifetimeScope())
            {
                IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                IEnumerable<IInvitation> invitations = factory.GetAll(m_settings.Value);
                IMapper mapper = new Mapper(m_mapperConfiguration);
                result = Ok(
                    invitations.Select<IInvitation, Models.Invitation>(i => mapper.Map<Models.Invitation>(i))
                    );
            }

            return result;  
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            IActionResult result = null;

            if (result == null && id.Equals(Guid.Empty))
            {
                result = BadRequest("Missing id");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                    IInvitation invitation = factory.Get(m_settings.Value, id);
                    if (invitation == null)
                    {
                        result = NotFound();
                    }
                    else
                    {
                        IMapper mapper = new Mapper(m_mapperConfiguration);
                        result = Ok(mapper.Map<Models.Invitation>(invitation));
                    }
                }
            }
            return result;
        }

        [HttpPost()]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Create([FromBody] Models.Invitation invitation)
        {
            IActionResult result = null;
            IMapper mapper = null;
            IInvitation innerInvitation = null;

            if (result == null && invitation == null)
            {
                result = BadRequest("Missing invitation data");
            }

            if (result == null && !invitation.EventDate.HasValue)
            {
                result = BadRequest("Missing event date");
            }

            if (result == null && !invitation.RSVPDueDate.HasValue)
            {
                result = BadRequest("Missing RSVP date");
            }

            if (result == null && string.IsNullOrEmpty(invitation.Title))
            {
                result = BadRequest("Missing title");
            }

            if (result == null && string.IsNullOrEmpty(invitation.Invitee))
            {
                result = BadRequest("Missing invitee");
            }

            if (result == null)
            {
                mapper = new Mapper(m_mapperConfiguration);
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                    innerInvitation = factory.Create();
                    mapper.Map<Models.Invitation, IInvitation>(invitation, innerInvitation);
                    IInvitationSaver saver = scope.Resolve<IInvitationSaver>();
                    saver.Create(m_settings.Value, innerInvitation);
                    invitation = mapper.Map<Models.Invitation>(innerInvitation);
                    result = Ok(invitation);
                }                
            }

            return result;
        }

        [HttpPut()]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Update([FromBody] Models.Invitation invitation)
        {
            IActionResult result = null;
            IMapper mapper = null;
            IInvitation innerInvitation = null;

            if (result == null && invitation == null)
            {
                result = BadRequest("Missing invitation data");
            }

            if (result == null && (!invitation.InvitationId.HasValue || invitation.InvitationId.Equals(Guid.Empty)))
            {
                result = BadRequest("Missing id");
            }

            if (result == null && !invitation.EventDate.HasValue)
            {
                result = BadRequest("Missing event date");
            }

            if (result == null && !invitation.RSVPDueDate.HasValue)
            {
                result = BadRequest("Missing RSVP date");
            }

            if (result == null && string.IsNullOrEmpty(invitation.Title))
            {
                result = BadRequest("Missing title");
            }

            if (result == null && string.IsNullOrEmpty(invitation.Invitee))
            {
                result = BadRequest("Missing invitee");
            }

            if (result == null)
            {
                mapper = new Mapper(m_mapperConfiguration);
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                    innerInvitation = factory.Get(m_settings.Value, invitation.InvitationId.Value);

                    if (innerInvitation == null)
                    {
                        result = NotFound();
                    }
                    else
                    {
                        mapper.Map<Models.Invitation, IInvitation>(invitation, innerInvitation);
                        IInvitationSaver saver = scope.Resolve<IInvitationSaver>();
                        saver.Update(m_settings.Value, innerInvitation);
                        invitation = mapper.Map<Models.Invitation>(innerInvitation);
                        result = Ok(invitation);
                    }                   
                }
            }
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Delete(Guid id)
        {
            IActionResult result = null;

            if (result == null && id.Equals(Guid.Empty))
            {
                result = BadRequest("Missing id");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationSaver saver = scope.Resolve<IInvitationSaver>();
                    saver.Delete(m_settings.Value, id);
                    result = Ok();
                }
            }
            return result;
        }

        [HttpPost("{id}/Response")]
        public IActionResult CreateResponse(Guid id, [FromBody] Models.InvitationResponse response)
        {
            IActionResult result = null;

            if (result == null && id.Equals(Guid.Empty))
            {
                result = BadRequest("Missing id");
            }

            if (result == null && response == null)
            {
                result = BadRequest("Missing response data");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                    IInvitation invitation = factory.Get(m_settings.Value, id);
                    if (invitation == null)
                    {
                        result = NotFound();
                    }
                    else
                    {
                        IInvitationResponse innerResponse = invitation.CreateResponse(response.IsAttending, response.AttendeeCount, response.Note);
                        IInvitationResponseSaver saver = scope.Resolve<IInvitationResponseSaver>();
                        saver.Create(m_settings.Value, innerResponse);
                        IMapper mapper = new Mapper(m_mapperConfiguration);
                        result = Ok(mapper.Map<Models.InvitationResponse>(innerResponse));
                    }
                }
            }
            return result;
        }
        [HttpGet("{id}/Response")]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult GetResponses(Guid id)
        {
            IActionResult result = null;

            if (result == null && id.Equals(Guid.Empty))
            {
                result = BadRequest("Missing invitation id");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IInvitationFactory factory = scope.Resolve<IInvitationFactory>();
                    IInvitation invitation = factory.Get(m_settings.Value, id);
                    if (invitation == null)
                    {
                        result = NotFound();
                    }
                    else
                    {
                        IEnumerable<IInvitationResponse> responses = invitation.GetResponses(m_settings.Value);
                        IMapper mapper = new Mapper(m_mapperConfiguration);
                        result = Ok(
                            responses.Select<IInvitationResponse, Models.InvitationResponse>(i => mapper.Map<Models.InvitationResponse>(i))
                            );
                    }
                }
            }
            return result;
        }
    }
}