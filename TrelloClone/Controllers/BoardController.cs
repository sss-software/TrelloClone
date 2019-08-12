﻿using Microsoft.AspNetCore.Mvc;
using TrelloClone.Services;
using TrelloClone.ViewModel;

namespace TrelloClone.Controllers
{
    public class BoardController : Controller
    {
        private readonly BoardService _boardService;

        public BoardController(BoardService boardService)
        {
            _boardService = boardService;
        }

        public IActionResult Index(int id)
        {
            BoardView model = _boardService.GetBoard(id);

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            return View(_boardService.GetBoard(id));
        }

        public IActionResult AddCard(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCard(AddCard viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            _boardService.AddCard(viewModel);
            return RedirectToAction(nameof(Index), new { id = viewModel.Id });

        }
    }
}