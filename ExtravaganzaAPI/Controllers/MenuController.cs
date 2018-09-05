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
    public class MenuController : Controller
    {
        private static MapperConfiguration m_mapperConfiguration;
        private IContainer m_container;
        private IOptions<Settings> m_settings;

        static MenuController()
        {
            m_mapperConfiguration = new MapperConfiguration(exp =>
            {
                exp.CreateMap<IMenu, Models.Menu>();
                exp.CreateMap<Models.Menu, IMenu>();
            });
        }

        public MenuController(IOptions<Settings> settings)
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
                IMenuFactory factory = scope.Resolve<IMenuFactory>();
                IEnumerable<IMenu> menus = factory.GetAll(m_settings.Value);
                IMapper mapper = new Mapper(m_mapperConfiguration);
                result = Ok(menus.Select<IMenu, Models.Menu>(m => mapper.Map<Models.Menu>(m)));
            }
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "thanksgiving-read")]
        public IActionResult Get(int id)
        {
            IActionResult result = null;
            using (ILifetimeScope scope = m_container.BeginLifetimeScope())
            {
                IMenuFactory factory = scope.Resolve<IMenuFactory>();
                IMenu menu = factory.Get(m_settings.Value, id);

                if (menu == null)
                {
                    result = NotFound();
                }

                if (result == null)
                {
                    IMapper mapper = new Mapper(m_mapperConfiguration);
                    result = Ok(mapper.Map<Models.Menu>(menu));
                }
            }
            return result;
        }

        [HttpPost()]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Create([FromBody] Models.Menu menu)
        {
            IActionResult result = null;

            if (menu == null)
            {
                result = BadRequest("Missing menu data");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IMenuFactory factory = scope.Resolve<IMenuFactory>();
                    IMenu innerMenu = factory.Create();
                    IMapper mapper = new Mapper(m_mapperConfiguration);
                    mapper.Map<Models.Menu, IMenu>(menu, innerMenu);

                    if (string.IsNullOrEmpty(innerMenu.Title))
                    {
                        result = BadRequest("Missing title");
                    }

                    if (result == null)
                    {
                        IMenuSaver saver = scope.Resolve<IMenuSaver>();
                        saver.Create(m_settings.Value, innerMenu);
                        result = Ok(mapper.Map<Models.Menu>(innerMenu));
                    }
                }
            }

            return result;
        }

        [HttpPut()]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Update([FromBody] Models.Menu menu)
        {
            IActionResult result = null;

            if (menu == null)
            {
                result = BadRequest("Missing menu data");
            }

            if (result == null)
            {
                using (ILifetimeScope scope = m_container.BeginLifetimeScope())
                {
                    IMenuFactory factory = scope.Resolve<IMenuFactory>();
                    IMenu innerMenu = factory.Get(m_settings.Value, menu.MenuId);

                    if (innerMenu == null)
                    {
                        result = NotFound();
                    }

                    if (result == null)
                    {
                        IMapper mapper = new Mapper(m_mapperConfiguration);
                        mapper.Map<Models.Menu, IMenu>(menu, innerMenu);

                        if (string.IsNullOrEmpty(innerMenu.Title))
                        {
                            result = BadRequest("Missing title");
                        }

                        if (result == null)
                        {
                            IMenuSaver saver = scope.Resolve<IMenuSaver>();
                            saver.Update(m_settings.Value, innerMenu);
                            result = Ok(mapper.Map<Models.Menu>(innerMenu));
                        }
                    }                    
                }
            }

            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "thanksgiving-write")]
        public IActionResult Delete(int id)
        {
            IActionResult result = null;
            using (ILifetimeScope scope = m_container.BeginLifetimeScope())
            {
                IMenuSaver saver = scope.Resolve<IMenuSaver>();
                saver.Delete(m_settings.Value, id);
                result = Ok();
            }
            return result;
        }
    }
}