﻿namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.CustomModels;
    using Services.Implementations;

    [Route("api/rooms")]
    [ApiController]

    public class RoomController : ControllerBase
    {
        private RoomManager manager;
        public RoomController(RoomManager roomManager)
        {
            this.manager = roomManager;
        }

        [HttpGet]
        //gets all rooms
        public IActionResult AllRooms()
        {
            var all = manager.AllRooms;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        //adds room by model
        public IActionResult AddRoom(RoomModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/rooms", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //deletes hotel by id
        public IActionResult DeleteRoomByID(int id)
        {

            var res = manager.Delete(id);
            if (res.Length == 0)
            {
                return Created("api/rooms", id);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        //deletes room by model
        public IActionResult DeleteRoom(RoomModel model)
        {

            var res = manager.Delete(model);
            if (res.Length == 0)
            {
                return Created("api/rooms", model);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits room by model
        public IActionResult EditRoom([FromBody]RoomModel model)
        {

            var res = manager.Update(model);
            if (res.Length == 0)
            {
                return Created("api/rooms", model);
            }
            return BadRequest();
        }
    }
}