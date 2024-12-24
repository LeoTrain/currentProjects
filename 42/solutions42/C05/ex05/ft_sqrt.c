int ft_sqrt(int nb)
{
  if (nb == 1)
    return 1;
  for (int i = 0; i <= nb / 2; i++)
  {
    if (i * i == nb)
      return i;
  }
  return 0;
}
