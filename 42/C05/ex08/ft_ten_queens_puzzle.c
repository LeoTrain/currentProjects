#include <unistd.h>

void ft_putnbr(int nb);

int ft_is_safe(int board[], int col, int row)
{
  for (int i = 0; i < col; i++)
  {
    if (board[i] == row ||
        (col - i) == (board[i] - row) ||
        (col - i) == (row - board[i]))
            return 0;
  }
  return 1;
}

void ft_solve(int board[], int col, int size, long *count)
{
  if (col == size)
  {
        (*count)++;
        for (int i = 0; i < size; i++)
            ft_putnbr(board[i]);
        write(1, "\n", 1);
        return ;
  }

  for (int row=0; row < size; row++)
  {
    if (ft_is_safe(board, col, row))
    {
      board[col] = row;
      ft_solve(board, col + 1, size, count);
      board[col] = -1;
    }
  }
}

int ft_ten_queens_puzzle(void)
{
  int board[10];
  for (int i = 0; i < 10; i++)
    board[i] = -1;
  long count = 0;
  ft_solve(board, 0, 10, &count);

  return count;
}
