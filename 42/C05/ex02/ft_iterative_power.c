int ft_iterative_power(int nb, int power)
{
  if (power < 0)
    return 0;
  if (power == 0)
    return 1;
  int result = 1;
  for (int j = 0; j < power; j++)
  {
    result *= nb;
  }
  return result;
}
