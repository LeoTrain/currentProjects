int ft_iterative_factorial(int nb)
{
  if (nb == 0)
    return 1;
  if (nb < 0)
    return 0;
  int result = 1;
  for (int i = nb; i > 0; i--)
  {
    result *= i;
  }
  return result;
}
