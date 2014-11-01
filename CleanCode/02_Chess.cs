namespace CleanCode
{
	public class Chess
	{
		private readonly Board board;

		public Chess(Board b)
		{
		    this.board = b;
		}

		public string getWhiteStatus() {
            bool check = checkForWhite();
            bool canMove = false;
            foreach (Loc locFig in board.Figures(Cell.White))
            {
                foreach (Loc moveFig in board.Get(locFig).Figure.Moves(locFig, board))
                {
                    Cell newDest = board.PerformMove(locFig, moveFig);
                    if (!checkForWhite())
                        canMove = true;
                    board.PerformUndoMove(locFig, moveFig, newDest);
                }
            }
            if (check)
                if (canMove)
                    return "check";
                else
                    return "mate";
            if (canMove) 
                return "ok";
            return "stalemate";
		}

		private bool checkForWhite()
		{
			bool isKing = false;
			foreach (Loc loc in board.Figures(Cell.Black))
			{
                var cell = board.Get(loc);
                var moves = cell.Figure.Moves(loc, board);
				foreach (Loc to in moves)
				{
					if (board.Get(to).IsWhiteKing)
						isKing = true;
				}
			}
			if (isKing) 
                return true;
			return false;
		}
	}
}