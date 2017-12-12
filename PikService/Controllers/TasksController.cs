using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic.ServiceFactory;
using BusinessLogic.DataTransferObjects;

namespace PikService.Controllers
{
    public class TasksController : BaseController
    {
        public TasksController(IServiceFactory serviceFactory) : base(serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [AllowAnonymous]
        // GET: api/Tasks
        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var result = await _serviceFactory.GetTaskService().GetAllAsync();
            return result;
        }

        /*
        // GET: api/Tasks/5
        [ResponseType(typeof(DataAccessLevel.Models.TaskDto))]
        public async TaskDto<IHttpActionResult> GetTask(int id)
        {
            DataAccessLevel.Models.TaskDto task = await db.tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public async TaskDto<IHttpActionResult> PutTask(int id, DataAccessLevel.Models.TaskDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(DataAccessLevel.Models.TaskDto))]
        public async TaskDto<IHttpActionResult> PostTask(DataAccessLevel.Models.TaskDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tasks.Add(task);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(DataAccessLevel.Models.TaskDto))]
        public async TaskDto<IHttpActionResult> DeleteTask(int id)
        {
            DataAccessLevel.Models.TaskDto task = await db.tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            db.tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.tasks.Count(e => e.TaskId == id) > 0;
        }
        */
    }
}